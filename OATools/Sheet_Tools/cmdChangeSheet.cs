
#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools2018.Utilities;
using System.Linq;
#endregion // Namespaces

namespace OATools2018.Sheet_Tools
{

    [Transaction(TransactionMode.Manual)]
    public class cmdChangeSheet : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;
            

            // find the titleblock in the active view
            FamilyInstance fi = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault() as FamilyInstance;

            // find the titleblock family symbol with the desired name
            FamilySymbol fs = new FilteredElementCollector(doc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault(q => q.Name == "E1 30x42 Horizontal") as FamilySymbol;

            using (Transaction t = new Transaction(doc, "Change titleblock2"))
            {
                t.Start();
                fi.Symbol = fs;
                t.Commit();
            }            

            return Result.Succeeded;
        }

    }

}