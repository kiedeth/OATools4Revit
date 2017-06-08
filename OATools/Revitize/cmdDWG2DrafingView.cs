#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using OATools.Utilities;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.IO;
#endregion // Namespaces

namespace OATools.Revitize
{
    [Transaction(TransactionMode.Manual)]
    class cmdDWG2DrafingView : IExternalCommand
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/Additional"; //this gives C:\Users\<userName>\AppData\Roaming\OATools
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;

        //public ExternalCommandData commandData { get; set; }

        //create empty list to receive the views to be passed out of this 
        private ViewSet createdViewList = new ViewSet();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (null == commandData)
            {
                throw new ArgumentNullException("commandData");
            }

            Initilize c = new Initilize();
            bool success = c.IsAppInitialized();
            if (!success)
            {
                return Result.Cancelled;
            }


            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;            
            Document doc = uidoc.Document;

            
            //Set counter 
            int counter = 0;


            //Open the form
            using (frmRevitize curForm = new frmRevitize(commandData))
            {
                //Show the form
                curForm.ShowDialog();

                if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    //The user canceled
                    return Result.Cancelled;
                }
                else
                {
                    //Get the selected DWG files
                    List<string> drawingList = curForm.getSelectedDWGs();

                    using (Transaction tx = new Transaction(doc, "Import DWGs to Drafting Views"))
                    {
                        if (tx.Start() == TransactionStatus.Started)
                        {
                            //Loop through DWGs, create Drafting View and insert
                            foreach (string curDWG in drawingList)
                            {
                                

                                //get family type for drafting view
                                ElementId curVFT = getDraftingViewFamilyType(doc);

                                //create drafting view
                                Autodesk.Revit.DB.View curView = ViewDrafting.Create(doc, curVFT);

                                //add the view to the list to be passed out of this
                                createdViewList.Insert(curView);


                                //rename the view to the DWG filename
                                string tmpName = getFilenameFromPath(curDWG);
                                string viewName = tmpName.Substring(0, tmpName.Length - 4);

                                try
                                {
                                    curView.Name = viewName;
                                }
                                catch (Exception ex)
                                {
                                    TaskDialog.Show("Error", "These is already a Drafting View named " + viewName + "in this project file. The view will be named " + curView.Name + " instead.");
                                    throw;
                                }

                                //set insert settings
                                DWGImportOptions curImportOptions = new DWGImportOptions();

                                

                                switch (curForm.getColorSetting())
                                {
                                    case "Invert":
                                        curImportOptions.ColorMode = ImportColorMode.Inverted;
                                        break;
                                    case "Preserve":
                                        curImportOptions.ColorMode = ImportColorMode.Preserved;
                                        break;
                                    default:
                                        curImportOptions.ColorMode = ImportColorMode.BlackAndWhite;
                                        break;
                                }

                                switch (curForm.getPosSetting())
                                {
                                    case "Origin to Origin":
                                        curImportOptions.Placement = ImportPlacement.Origin;
                                        break;
                                    case "Center to Center":
                                        curImportOptions.Placement = ImportPlacement.Centered;
                                        break;
                                }

                                //import / link current DWG to current view
                                ElementId curLinkID = null;
                                

                                if (curForm.getInsertType() == "Link")
                                {
                                    doc.Link(curDWG, curImportOptions, curView, out curLinkID);
                                    counter = counter + 1;
                                }
                                else
                                {
                                    doc.Import(curDWG, curImportOptions, curView, out curLinkID);

                                    counter = counter + 1;
                                }

                                
                            }

                            
                        }
                        

                        //commit changes
                        tx.Commit();
                    }

   

                }
            }
            
            

            //ask user if they want to create a sheet
            string summeryMessage = " Inserted " + counter + " DWG Files.";
            bool createSheet = createSheetYesNo(summeryMessage);
            frmRevitize f1 = new frmRevitize(commandData);
            f1.Close();

            if (createSheet)
            {
                cmdSheetsFromViews cmd = new cmdSheetsFromViews();
                cmd.Execute(commandData, ref message, elements, createdViewList);
            }

            return Result.Succeeded;
        }


        //public List<Autodesk.Revit.DB.View> collectedCreatedViews()
        //{
        //    List<Autodesk.Revit.DB.View> theList = createdViewList;

        //    return theList;
        //}


        private bool createSheetYesNo(string message)
        {



            //Create the message box
            message += "\n\n Would you like to create a sheet and add these views to it?";
            string title = "Complete";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string getFilenameFromPath(string filePath)
        {
            //split the string on the backslash char
            string[] parts = filePath.Split(new char[] { '\\' });

            //loop through result strings with for each
            string fileName = parts[parts.Count() - 1];

            return fileName;           
        }

        public List<ViewFamilyType> getAllViewTypes(Document doc)
        {
            //get list of all view types
            FilteredElementCollector m_colVT = new FilteredElementCollector(doc);
            m_colVT.OfClass(typeof(ViewFamilyType));

            List<ViewFamilyType> m_vt = new List<ViewFamilyType>();
            foreach (ViewFamilyType x in m_colVT.ToElements())
            {
                m_vt.Add(x);
            }
            return m_vt;
        }

        public ElementId getDraftingViewFamilyType(Document doc)
        {
            ElementId functionReturnValue = null;
            //get list of view types
            List<ViewFamilyType> vTypes = getAllViewTypes(doc);

            foreach (ViewFamilyType x in vTypes)
            {
                if (x.ViewFamily == ViewFamily.Drafting)
                {
                    return x.Id;
                    return functionReturnValue;
                }
            }

            return null;
            return functionReturnValue;
        }




    }
}

