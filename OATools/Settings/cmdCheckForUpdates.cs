
using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using System.Collections.Generic;
using System.Text;

namespace OATools.Settings
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class cmdCheckForUpdates : IExternalCommand
    {


        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string addinsLocation = appData + "/Autodesk/Revit/Addins/2017";
        static string appUpdater = addinsLocation + "/" + "OAToolsForRevit2017.bundle" + "/" + "AppUpdater.exe";


        // The main Execute method (inherited from IExternalCommand) must be public
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            //Make call to check for updates in AppUpdater project
            //AppUpdater.Program.Main();

            System.Diagnostics.Process.Start(appUpdater);

            return Autodesk.Revit.UI.Result.Succeeded;
        }

    }
}

