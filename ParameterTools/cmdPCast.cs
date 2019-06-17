#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools2018.ParameterTools.PCast;
using OATools2018.Utilities;
#endregion // Namespaces

namespace OATools2018.ParameterTools
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


        private List<ParameterType> getAllSharedParameters(Autodesk.Revit.ApplicationServices.Application app, Document doc)
        {
            List<ParameterType> ret = new List<ParameterType>();

            string filename = app.SharedParametersFilename;
            if (!string.IsNullOrEmpty(filename))
            {
                // get the current shared params file object:
                DefinitionFile file = app.OpenSharedParameterFile();

                if (null != file)
                {
                    foreach (var gp in file.Groups)
                    {
                        foreach (var d in gp.Definitions)
                        {
                            ret.Add(d.ParameterType);
                        }
                    }
                }
            }

            return ret;
        }

    }
}
