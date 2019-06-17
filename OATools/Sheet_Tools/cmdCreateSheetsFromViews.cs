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
    public class cmdCreateSheetsFromViews : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;



            using (Transaction t = new Transaction(doc, "Create Sheets"))
            {
                t.Start();


                t.Commit();
            }

            return Result.Succeeded;
        }

    }

}