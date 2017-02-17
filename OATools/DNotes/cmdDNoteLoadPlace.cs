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

namespace OATools.DNotes
{
    [Transaction(TransactionMode.Manual)]
    public class cmdDNoteLoadPlace : IExternalCommand
    {
        /// <summary>
        /// Family name.
        /// </summary>
        public const string FamilyName = "family_api_DNote";

        /// <summary>
        /// Family file path.
        /// Normally, you would either search the  library
        /// paths provided by Application.GetLibraryPaths 
        /// method. In this case, we store the sample 
        /// family in the same location as the add-in.
        /// </summary>
        //const string _family_folder = "Z:/a/rvt";
        static string _family_folder = Path.GetDirectoryName(typeof(cmdDNoteLoadPlace).Assembly.Location);

        /// <summary>
        /// Family filename extension RFA.
        /// </summary>
        const string _family_ext = "rfa";

        /// <summary>
        /// Family file path
        /// </summary>
        static string _family_path = null;

        /// <summary>
        /// Return complete family file path
        /// </summary>
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

        /// <summary>
        /// Collection of newly added family instances
        /// </summary>
        List<ElementId> _added_element_ids = new List<ElementId>();

        Family family = null;



        /// <summary>
        /// External command mainline
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;


            //Retrieve the family if it is already present:
            FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(Family));

            Family family = a.FirstOrDefault<Element>(e => e.Name.Equals(FamilyName)) as Family;

            if (null == family)
            {
                if (!File.Exists(FamilyPath))
                {
                    Util.ErrorMsg(string.Format(
                      "Please ensure that the DNote "
                      + "family file '{0}' exists in '{1}'.",
                      FamilyName, _family_folder));

                    return Result.Failed;
                }

                // It is not present, so load it:

                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Load Family");
                    doc.LoadFamily(FamilyPath, out family);

                    //Set the parameters here after loading the family but before exiting the transaction to promt for placement

                    tx.Commit();
                }
            }




            //Retrieve the symbol id's
            ISet<ElementId> symbolIds = family.GetFamilySymbolIds();

            //Create the symbol var
            FamilySymbol symbol = null;

            //Loop through the id's, There will only be one, set symbol var
            foreach (ElementId id in symbolIds)
            {
                symbol = doc.GetElement(id) as FamilySymbol;
                
            }


            /// <summary>
            /// Place the family symbol:
            /// 
            /// Subscribe to document changed event to retrieve family instance elements added by the PromptForFamilyInstancePlacement operation:
            /// </summary>
            app.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);

            _added_element_ids.Clear();

            // PromptForFamilyInstancePlacement cannot 
            // be called inside transaction.

            uidoc.PromptForFamilyInstancePlacement(symbol);

            app.DocumentChanged -= new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);

            // Access the newly placed family instances:
            int n = _added_element_ids.Count();
            

            string msg = string.Format("Placed {0} {1} family instance{2}{3}", n, family.Name, Util.PluralSuffix(n), Util.DotOrColon(n));

            string ids = string.Join(", ", _added_element_ids.Select<ElementId, string>(id => id.IntegerValue.ToString()));

            Util.InfoMsg2(msg, ids);



            

            return Result.Succeeded;

        }

        //Create a OnDocumentChanged method
        void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            _added_element_ids.AddRange(e.GetAddedElementIds());
        }




        //void SetParameter(Document doc, UIDocument uidoc)
        //{
        //    //Retrieve the symbol id's
        //    ISet<ElementId> symbolIds = family.GetFamilySymbolIds();


        //    ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

        //    if (0 == symbolIds.Count)
        //    {
        //        TaskDialog.Show("Error", "No elements selected");
        //    }
        //    else
        //    {
        //        foreach (ElementId id in selectedIds)
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



    }

}
