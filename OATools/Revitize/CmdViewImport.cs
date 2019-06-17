#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
#endregion // Namespaces

namespace OATools2018.Revitize
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class CmdViewImport : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            //// Find target document - it must be the only other open document in session
            //Document toDocument = null;
            //IEnumerable<Document> documents = app.Documents.Cast<Document>();
            //if (documents.Count<Document>() != 2)
            //{
            //    TaskDialog.Show("No target document",
            //                    "This tool can only be used if there are two documents (a source document and target document).");
            //    return Result.Cancelled;
            //}
            //foreach (Document loadedDoc in documents)
            //{
            //    if (loadedDoc.Title != doc.Title)
            //    {
            //        toDocument = loadedDoc;
            //        break;
            //    }
            //}

            //// Collect schedules and drafting views
            //FilteredElementCollector collector = new FilteredElementCollector(doc);

            //List<Type> viewTypes = new List<Type>();
            //viewTypes.Add(typeof(ViewSchedule));
            //viewTypes.Add(typeof(ViewDrafting));
            //ElementMulticlassFilter filter = new ElementMulticlassFilter(viewTypes);
            //collector.WherePasses(filter);

            //collector.WhereElementIsViewIndependent(); // skip view-specfic schedules (e.g. Revision Schedules);
            //                                           // These should not be copied as they are associated to another view that cannot be copied

            //// Copy all schedules together so that any dependency elements are copied only once
            //IEnumerable<ViewSchedule> schedules = collector.OfType<ViewSchedule>();
            //DuplicateViewUtils.DuplicateSchedules(doc, schedules, toDocument);
            //int numSchedules = schedules.Count<ViewSchedule>();

            //// Copy drafting views together
            //IEnumerable<ViewDrafting> draftingViews = collector.OfType<ViewDrafting>();
            //int numDraftingElements =
            //    DuplicateViewUtils.DuplicateDraftingViews(doc, draftingViews, toDocument);
            //int numDrafting = draftingViews.Count<ViewDrafting>();

            //// Show results
            //TaskDialog.Show("Statistics",
            //       String.Format("Copied: \n" +
            //                    "\t{0} schedules.\n" +
            //                    "\t{1} drafting views.\n" +
            //                    "\t{2} new drafting elements created.",
            //       numSchedules, numDrafting, numDraftingElements));

            //Perform the transaction
            using (Transaction t = new Transaction(doc, "Import Views"))
            {
                t.Start();

                bool formSuccess = showTheForm();

                t.Commit();
            }
            return Result.Succeeded;
        }

        private bool showTheForm()
        {
            frmViewImport form = new frmViewImport();
            form.ShowDialog();
            return true;
        }



        private bool importViews(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            // Find target document - it must be the only other open document in session
            Document toDocument = null;
            IEnumerable<Document> documents = app.Documents.Cast<Document>();
            if (documents.Count<Document>() != 2)
            {
                TaskDialog.Show("No target document",
                                "This tool can only be used if there are two documents (a source document and target document).");

                return false;
            }
            foreach (Document loadedDoc in documents)
            {
                if (loadedDoc.Title != doc.Title)
                {
                    toDocument = loadedDoc;
                    break;
                }
            }

            // Collect schedules and drafting views
            FilteredElementCollector collector = new FilteredElementCollector(doc);

            List<Type> viewTypes = new List<Type>();
            viewTypes.Add(typeof(ViewSchedule));
            viewTypes.Add(typeof(ViewDrafting));
            ElementMulticlassFilter filter = new ElementMulticlassFilter(viewTypes);
            collector.WherePasses(filter);

            collector.WhereElementIsViewIndependent(); // skip view-specfic schedules (e.g. Revision Schedules);
                                                       // These should not be copied as they are associated to another view that cannot be copied

            // Copy all schedules together so that any dependency elements are copied only once
            IEnumerable<ViewSchedule> schedules = collector.OfType<ViewSchedule>();
            DuplicateViewUtils.DuplicateSchedules(doc, schedules, toDocument);
            int numSchedules = schedules.Count<ViewSchedule>();

            // Copy drafting views together
            IEnumerable<ViewDrafting> draftingViews = collector.OfType<ViewDrafting>();
            int numDraftingElements =
                DuplicateViewUtils.DuplicateDraftingViews(doc, draftingViews, toDocument);
            int numDrafting = draftingViews.Count<ViewDrafting>();

            // Show results
            TaskDialog.Show("Statistics",
                   String.Format("Copied: \n" +
                                "\t{0} schedules.\n" +
                                "\t{1} drafting views.\n" +
                                "\t{2} new drafting elements created.",
                   numSchedules, numDrafting, numDraftingElements));


            return true;
        }

    }
}
