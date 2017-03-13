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
#endregion // Namespaces

namespace OATools.Revitize
{
    [Transaction(TransactionMode.Manual)]
    class cmdDWG2DrafingView : IExternalCommand
    {

        public void ImportDWGsToDraftingViews()
        {
            


        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;            
            Document doc = uidoc.Document;

            //Set counter 
            int counter = 0;


            //Open the form
            using (frmRevitize curForm = new frmRevitize())
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
                                View curView = ViewDrafting.Create(doc, curVFT);

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


                    //expolde the DWGs here after the transaction has committed by subscribing to the DocumentChanged event

                }
            }

            //alert user
            TaskDialog.Show("Complete", "Inserted " + counter + " DWG Files.");
            return Result.Succeeded;


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

