using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using System.Collections.Generic;

namespace OATools
{
    /// <remarks>
    /// This application's main class. The class must be Public.
    /// </remarks>
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {

            clsCreateTab tab = new clsCreateTab();
            tab.CreateTab(application);

            return Result.Succeeded;
        }
    }
}