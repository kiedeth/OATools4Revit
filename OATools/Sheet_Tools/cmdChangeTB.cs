#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools.Utilities;
using System.Linq;
using OATools.Utilities;
#endregion // Namespaces

namespace OATools.Sheet_Tools
{

    [Transaction(TransactionMode.Manual)]
    public class cmdChangeTB : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Show the form
            frmChangeTB frm = new frmChangeTB();
            frm.ShowDialog();

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Activate each collected sheet one at a time
            ActivateViewsheet(uidoc, doc);

            //Perform the transaction
            using (Transaction t = new Transaction(doc, "Change titleblock"))
            {
                t.Start("Change TB");
                //Do stuff here
                t.Commit();
            }
            return Result.Succeeded;
        }

        public void ActivateViewsheet(UIDocument uidoc, Document doc)
        {
            //Get the sheets
            FilteredElementCollector vsCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets);

            foreach (ViewSheet vs in vsCollector)
            {

                // find the titleblock in the active view
                FamilyInstance fi = new FilteredElementCollector(doc, doc.ActiveView.Id)
                    .OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .FirstOrDefault() as FamilyInstance;

                // find the titleblock family symbol with the desired name
                FamilySymbol fs = new FilteredElementCollector(doc)
                    .OfClass(typeof(FamilySymbol))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .FirstOrDefault(q => q.Name == "D 22 x 34 Horizontal") as FamilySymbol;

                //Activate the sheet
                uidoc.ActiveView = vs;

                //Change the TB
                //fi.Symbol = fs;

                TaskDialog.Show("Test", "This function is not legal with the API. You cannot switch the active view inside a transaction and you cannot change the TB outside a transaction.");

            }
        }

    }

}