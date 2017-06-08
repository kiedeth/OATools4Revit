using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using System.Threading.Tasks;
using OATools.Main;
using System.IO;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI.Selection;
using OATools.Utilities;
using OAToolsUpdater;

namespace OATools.DNotes
{
    [Transaction(TransactionMode.Manual)]
    public class cmdDNoteLoadPlace : IExternalCommand
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/Additional"; //this gives C:\Users\<userName>\AppData\Roaming\OATools
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;

        /// <summary>
        /// Family name.
        /// </summary>
        //public const string FamilyName = "family_api_DNote";
        public const string FamilyName = "fsDNote";

        /// <summary>
        /// Family file path.
        /// Normally, you would either search the  library
        /// paths provided by Application.GetLibraryPaths 
        /// method. In this case, we store the sample 
        /// family in the same location as the add-in.
        /// </summary>
        //static string _family_folder = Path.GetDirectoryName(typeof(cmdDNoteLoadPlace).Assembly.Location) + directory;
        static string _family_folder = directory;

        /// <summary>
        /// Family filename extension RFA.
        /// </summary>
        const string _family_ext = "rfa";

        //C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\OATools\fsDNote.rfa



        /// <summary>
        /// Family file path
        /// </summary>
        static string _family_path = null;
        
        // Return complete family file path
        static string FamilyPath
        {
            get
            {
                if (null == _family_path)
                {
                    _family_path = Path.Combine(_family_folder, FamilyName);

                    _family_path = Path.ChangeExtension(_family_path, _family_ext);
                }
                return _family_path;
            }
        }
        
        // Collection of newly added family instances
        List<ElementId> _added_element_ids = new List<ElementId>();

        Family family = null;



        /// <summary>
        /// External command mainline
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Confirm App has been initialized
            Initilize c = new Initilize();
            bool success = c.IsAppInitialized();
            if (!success) return Result.Cancelled;
            
            else
            {                

                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Application app = uiapp.Application;
                Document doc = uidoc.Document;
                Selection selection = uidoc.Selection;

                //Retrieve the family if it is already present:
                FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(Family));
                Family family = a.FirstOrDefault<Element>(e => e.Name.Equals(FamilyName)) as Family;

                //Check to make sure the user is on a sheet otherwise cancel 
                View activeView = doc.ActiveView;
                if (!(activeView is ViewSheet))
                {
                    TaskDialog.Show("ERROR!", "You must be on a sheet to place DNotes");
                    return Result.Cancelled;
                }

                //Get the active sheet number
                Parameter activeSheetNumber;
                activeSheetNumber = activeView.get_Parameter(BuiltInParameter.SHEET_NUMBER);
                string sheet_number = activeSheetNumber.AsString();

                //Verify that the family path is valid and load the family
                if (null == family)
                {
                    if (!File.Exists(FamilyPath))
                    {
                        //Utilities.Util.ErrorMsg(string.Format(
                        //  "Please ensure that the DNote "
                        //  + "family file '{0}' exists in '{1}'.",
                        //  FamilyName, _family_folder));

                        OAToolsUpdater.Updater c2 = new Updater();
                        bool success2 = c2.getDNoteFile();

                        if (!success2)
                        {
                            TaskDialog.Show("ERROR!", "Cannot download the DNote .rfa file. ERROR CODE:1777");

                            return Result.Failed;
                        }
                        
                    }

                    // It is not present, so load it:
                    using (Transaction tx = new Transaction(doc))
                    {
                        tx.Start("Load Family");

                        doc.LoadFamily(FamilyPath, out family);

                        tx.Commit();
                    }
                }

                //Create the symbol var
                FamilySymbol symbol = null;

                //Retrieve the symbol id's
                //This has to happen after the family has been loaded
                ISet<ElementId> symbolIds = family.GetFamilySymbolIds();
                //Loop through the id's, There will only be one, set symbol var
                foreach (ElementId id in symbolIds)
                {
                    symbol = doc.GetElement(id) as FamilySymbol;
                }

                // Place the family symbol: 
                //Subscribe to document changed event to retrieve family instance elements added by the PromptForFamilyInstancePlacement operation:
                app.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);

                _added_element_ids.Clear();

                // PromptForFamilyInstancePlacement cannot 
                // be called inside transaction.
                uidoc.PromptForFamilyInstancePlacement(symbol);
                app.DocumentChanged -= new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);

                // Access the newly placed family instances:
                int n = _added_element_ids.Count();

                //Show the form
                frmCreateDNote form = new frmCreateDNote(sheet_number);
                form.ShowDialog();

                //Get the data from the form
                string DNoteNumberValue = string.Empty;
                DNoteNumberValue = frmCreateDNote.DNoteNumberInput;

                string DNoteSheetValue = string.Empty;
                DNoteSheetValue = frmCreateDNote.DNoteSheetInput;

                string DNoteTextValue = string.Empty;
                DNoteTextValue = frmCreateDNote.DNoteTextInput;

                using (Transaction tx = new Transaction(doc, "Set Parameter"))
                {
                    tx.Start("Set Parameters");

                    //Set the parameters

                    if (0 == symbolIds.Count)
                    {
                        TaskDialog.Show("Error", "No elements selected");
                    }
                    else
                    {
                        foreach (ElementId id in _added_element_ids)
                        {
                            //Gets the element associated with the ID
                            Element eFromId = doc.GetElement(id);

                            ParameterSet pSet = eFromId.Parameters;

                            foreach (Parameter param in pSet)
                            {
                                if (param.Definition.Name.Contains("Number"))
                                {
                                    param.Set(DNoteNumberValue);
                                }
                                if (param.Definition.Name.Contains("Sheet"))
                                {
                                    param.Set(DNoteSheetValue);
                                }
                                if (param.Definition.Name.Contains("Text"))
                                {
                                    param.Set(DNoteTextValue);
                                }
                            }
                        }
                    }

                    tx.Commit();
                }

                //Construct the message
                string msg = string.Format("Placed {0} {1} family instance{2}{3}", n, family.Name, Utilities.Util.PluralSuffix(n), Utilities.Util.DotOrColon(n));
                string ids = string.Join(", ", _added_element_ids.Select<ElementId, string>(id => id.IntegerValue.ToString()));

                //Show the message
                //Util.InfoMsg2(msg, ids);

                return Result.Succeeded;
            }
        }



        //Create a OnDocumentChanged method
        void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            _added_element_ids.AddRange(e.GetAddedElementIds());
        }

    }
}



//void SetParameter(Document doc, UIDocument uidoc, Family symbol)
//{
//    //Retrieve the symbol id's
//    //ISet<ElementId> symbolIds = family.GetFamilySymbolIds();

//    //ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

//    ICollection<ElementId> symbolIds = family.GetFamilySymbolIds();

//    if (0 == symbolIds.Count)
//    {
//        TaskDialog.Show("Error", "No elements selected");
//    }
//    else
//    {
//        foreach (ElementId id in symbolIds)
//        {
//            //Gets the element associated with the ID
//            Element eFromId = doc.GetElement(id);

//            ParameterSet pSet = eFromId.Parameters;

//            foreach (Parameter param in pSet)
//            {
//                if (param.Definition.Name.Contains("Number"))
//                {
//                    param.Set("3");
//                }
//            }
//        }
//    }

//}





