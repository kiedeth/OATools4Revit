//#region Namespaces
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Diagnostics;
//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.DB.Events;
//using Autodesk.Revit.UI;
//using Autodesk.Revit.DB.Structure;
//using OATools.Commands;
//using System.IO;
//using OATools.Main;
//#endregion // Namespaces


//namespace OATools.DNoter
//{
//    public partial class frmDNoter : System.Windows.Forms.Form
//    {

//        #region Class Member Variables
//        /// <summary>
//        /// Revit active document
//        /// </summary>
//        //Autodesk.Revit.DB.Document document;
//        //Autodesk.Revit.DB.Document m_doc;
//        //Autodesk.Revit.UI.UIApplication uiapp;
//        //Autodesk.Revit.UI.UIDocument uidoc;
//        //Autodesk.Revit.DB.Document doc;
//        //Autodesk.Revit.ApplicationServices.Application app;
//        //List<ElementId> _added_element_ids = new List<ElementId>();
//        #endregion

//        /// <summary>
//        /// Family name.
//        /// </summary>
//        public const string FamilyName = "family_api_table";

//        /// <summary>
//        /// Family file path.
//        /// Normally, you would either search the  library
//        /// paths provided by Application.GetLibraryPaths 
//        /// method. In this case, we store the sample 
//        /// family in the same location as the add-in.
//        /// </summary>
//        //const string _family_folder = "Z:/a/rvt";
//        static string _family_folder
//          = Path.GetDirectoryName(
//            typeof(frmDNoter)
//              .Assembly.Location);

//        /// <summary>
//        /// Family filename extension RFA.
//        /// </summary>
//        const string _family_ext = "rfa";

//        /// <summary>
//        /// Family file path
//        /// </summary>
//        static string _family_path = null;

//        /// <summary>
//        /// Return complete family file path
//        /// </summary>
//        static string FamilyPath
//        {
//            get
//            {
//                if (null == _family_path)
//                {
//                    _family_path = Path.Combine(
//                      _family_folder, FamilyName);

//                    _family_path = Path.ChangeExtension(
//                      _family_path, _family_ext);
//                }
//                return _family_path;
//            }
//        }

//        /// <summary>
//        /// Collection of newly added family instances
//        /// </summary>
//        List<ElementId> _added_element_ids
//          = new List<ElementId>();

//        /// <summary>
//        /// External command mainline
//        /// </summary>
//        public Result Execute(
//          ExternalCommandData commandData,
//          ref string message,
//          ElementSet elements)
//        {
//            UIApplication uiapp = commandData.Application;
//            UIDocument uidoc = uiapp.ActiveUIDocument;
//            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
//            Document doc = uidoc.Document;

//            // Retrieve the family if it is already present:

//            Family family = Util.FindElementByName(
//              doc, typeof(Family), FamilyName) as Family;

//            if (null == family)
//            {
//                // It is not present, so check for 
//                // the file to load it from:

//                if (!File.Exists(FamilyPath))
//                {
//                    Util.ErrorMsg(string.Format(
//                      "Please ensure that the sample table "
//                      + "family file '{0}' exists in '{1}'.",
//                      FamilyName, _family_folder));

//                    return Result.Failed;
//                }

//                // Load family from file:

//                using (Transaction tx = new Transaction(doc))
//                {
//                    tx.Start("Load Family");
//                    doc.LoadFamily(FamilyPath, out family);
//                    tx.Commit();
//                }
//            }

//            // Determine the family symbol

//            FamilySymbol symbol = null;

//            foreach (FamilySymbol s in family.Symbols)
//            {
//                symbol = s;

//                // Our family only contains one
//                // symbol, so pick it and leave

//                break;
//            }

//            // Place the family symbol:

//            // Subscribe to document changed event to
//            // retrieve family instance elements added by the 
//            // PromptForFamilyInstancePlacement operation:

//            app.DocumentChanged
//              += new EventHandler<DocumentChangedEventArgs>(
//                OnDocumentChanged);

//            _added_element_ids.Clear();

//            // PromptForFamilyInstancePlacement cannot 
//            // be called inside transaction.

//            uidoc.PromptForFamilyInstancePlacement(symbol);

//            app.DocumentChanged
//              -= new EventHandler<DocumentChangedEventArgs>(
//                OnDocumentChanged);

//            // Access the newly placed family instances:

//            int n = _added_element_ids.Count();

//            string msg = string.Format(
//              "Placed {0} {1} family instance{2}{3}",
//              n, family.Name,
//              Util.PluralSuffix(n),
//              Util.DotOrColon(n));

//            string ids = string.Join(", ",
//              _added_element_ids.Select<ElementId, string>(
//                id => id.IntegerValue.ToString()));

//            Util.InfoMsg2(msg, ids);

//            return Result.Succeeded;
//        }

//        void OnDocumentChanged(
//          object sender,
//          DocumentChangedEventArgs e)
//        {
//            _added_element_ids.AddRange(
//              e.GetAddedElementIds());
//        }
//    }
//}


//        public frmDNoter(Autodesk.Revit.UI.ExternalCommandData commandData)
//        {
//            //InitializeComponent();
//            //uiapp = commandData.Application;
//            //uidoc = uiapp.ActiveUIDocument;
//            //app = uiapp.Application;
//            //doc = uidoc.Document;
//            //document = commandData.Application.ActiveUIDocument.Document;
//            //m_doc = commandData.Application.ActiveUIDocument.Document;

//        }

//        public frmDNoter(Document document)
//        {
//            this.document = document;

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            insertDNote();
//            //insertNote();

//        }


//        public void insertDNote()
//        {
//            //Set the path of the family to load
//            String fileName = @"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\fsDNote.rfa";

//            using (Transaction tx = new Transaction(doc))
//                tx.Start("Load Family");

//            Family family = null;
//            doc.LoadFamily(fileName, out family);            
//        }

//        public Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, ElementSet elements)
//        {
//            InitializeComponent();
//            uiapp = commandData.Application;
//            uidoc = uiapp.ActiveUIDocument;
//            app = uiapp.Application;
//            doc = uidoc.Document;
//            document = commandData.Application.ActiveUIDocument.Document;
//            m_doc = commandData.Application.ActiveUIDocument.Document;


//            // Retrieve the family if it is already present:

//            Family family = Util.FindElementByName(
//              doc, typeof(Family), FamilyName) as Family;

//            if (null == family)
//            {
//                // It is not present, so check for 
//                // the file to load it from:

//                if (!File.Exists(FamilyPath))
//                {
//                    Util.ErrorMsg(string.Format(
//                      "Please ensure that the sample table "
//                      + "family file '{0}' exists in '{1}'.",
//                      FamilyName, _family_folder));

//                    return Result.Failed;
//                }

//                // Load family from file:

//                using (Transaction tx = new Transaction(doc))
//                {
//                    tx.Start("Load Family");
//                    doc.LoadFamily(FamilyPath, out family);
//                    tx.Commit();
//                }
//            }
//        }


//    }
//}


//        public void loadDNote()
//        {
//            try
//            {
//                //Set the path of the family to load
//                String fileName = @"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\fsDNote.rfa";

//                // try to load family
//                Family family = null;
//                if (!document.LoadFamily(fileName, out family))
//                {
//                    //Retun if the family is already loaded
//                    return; 
//                }



//                FilteredElementCollector collector = new FilteredElementCollector(doc);
//                collector.OfCategory(BuiltInCategory.OST_GenericAnnotation);
//                collector.OfClass(typeof(FamilySymbol));

//                //Grab the first collected symbol and set the symbol var to it
//                FamilySymbol symbol = collector.FirstElement() as FamilySymbol;

//                //Clear all other elements ID's
//                _added_element_ids.Clear();

//                this.Hide();

//                using (SubTransaction subtr_fam = new SubTransaction(m_doc))
//                {
//                    try
//                    {
//                        app.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);
//                        uidoc.PromptForFamilyInstancePlacement(symbol);

//                        app.DocumentChanged -= new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);

//                        int n = _added_element_ids.Count;
//                    }

//                    catch (Exception e)
//                    {
//                        Console.WriteLine(e.StackTrace.ToString());
//                    }
//                }



//            }
//            catch (Exception ex)
//            {
//                // If there is something wrong, give error information and return failed
//                throw new Exception("Unable to load family" + ex);
//            }
//        }//LoadNote

//        void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
//        {
//            // this does not work, because the handler will 
//            // be called each time a new instance is added, 
//            // overwriting the previous ones recorded:
//            //
//            //_added_element_ids = e.GetAddedElementIds();

//            _added_element_ids.AddRange(e.GetAddedElementIds());
//        }



//        public void insertNote()
//        {

//            FilteredElementCollector collector = new FilteredElementCollector(document);
//            collector.OfCategory(BuiltInCategory.OST_GenericAnnotation);
//            collector.OfClass(typeof(FamilySymbol));

//            //Grab the first collected symbol and set the symbol var to it
//            FamilySymbol symbol = collector.FirstElement() as FamilySymbol;

//            //Clear all other elements ID's
//            _added_element_ids.Clear();

//            //app.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(OnDocumentChanged);
//            uidoc.PromptForFamilyInstancePlacement(symbol);



//        }//InsetNote
//    }
//}


//throw new Exception("Unable to load " + fileName);               
//TaskDialog.Show("Error", "Family already loaded"); 


//namespace OATools.Commands
//{
//    [Transaction(TransactionMode.Manual)]
//    [Regeneration(RegenerationOption.Manual)]
//    class CmdPlaceFamilyInstance : IExternalCommand
//    {
//        List<ElementId> _added_element_ids = new List<ElementId>();

//        public Result Execute(
//          ExternalCommandData commandData,
//          ref string message,
//          ElementSet elements)
//        {
//            UIApplication uiapp = commandData.Application;
//            UIDocument uidoc = uiapp.ActiveUIDocument;
//            Application app = uiapp.Application;
//            Document doc = uidoc.Document;

//            FilteredElementCollector collector
//              = new FilteredElementCollector(doc);

//            collector.OfCategory(BuiltInCategory.OST_GenericAnnotation);
//            collector.OfClass(typeof(FamilySymbol));

//            FamilySymbol symbol = collector.FirstElement() as FamilySymbol;

//            _added_element_ids.Clear();

//            app.DocumentChanged
//              += new EventHandler<DocumentChangedEventArgs>(
//                OnDocumentChanged);

//            uidoc.PromptForFamilyInstancePlacement(symbol);

//            app.DocumentChanged
//              -= new EventHandler<DocumentChangedEventArgs>(
//                OnDocumentChanged);

//            int n = _added_element_ids.Count;

//            TaskDialog.Show(
//              "Place Family Instance",
//              string.Format(
//                "{0} D-Note{1} added.", n,
//                ((1 == n) ? "" : "s")));

//            return Result.Succeeded;
//        }

//        void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
//        {
//            // this does not work, because the handler will 
//            // be called each time a new instance is added, 
//            // overwriting the previous ones recorded:
//            //
//            //_added_element_ids = e.GetAddedElementIds();

//            _added_element_ids.AddRange(e.GetAddedElementIds());
//        }
//    }
//}
