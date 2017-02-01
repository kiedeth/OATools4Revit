#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools.Main;
#endregion

namespace OATools
{
    class App : IExternalApplication
    {
        public Result OnStartup(ExternalCommandData commandData, ref string message, ElementSet elements, UIControlledApplication a)
        {
            //Get application and document objects
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //UIApplication uiDoc = 

            //TaskDialog.Show("Revit", "Hello World");
            CsAddPanel.OnStartup(uiApp);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }
    }
}
