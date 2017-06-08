#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools.ParameterTools.PCast;
using OATools.Utilities;
#endregion // Namespaces

namespace OATools.ParameterTools
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class cmdPCast : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Confirm App has been initialized
            Initilize c = new Initilize();
            bool success = c.IsAppInitialized();
            if (!success) return Result.Cancelled;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;            

            frmPCast f = new frmPCast(commandData);
            f.ShowDialog();

            return Result.Succeeded;
        }
    }
}
