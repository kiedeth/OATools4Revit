
using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using System.Collections.Generic;
using System.Text;
using OAToolsUpdater;
using OATools.Utilities;

namespace OATools.Settings
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class cmdCheckForUpdates : IExternalCommand
    {


        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        //static string addinsLocation = appData + "/Autodesk/Revit/Addins/2017";
        //static string appUpdater = addinsLocation + "/" + "OAToolsForRevit2017.bundle" + "/" + "AppUpdater.exe";


        // The main Execute method (inherited from IExternalCommand) must be public
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //Confirm App has been initialized
            Initilize c = new Initilize();
            bool success = c.IsAppInitialized();
            if (!success) return Result.Cancelled;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Make call to check for updates in AppUpdater project
            //AppUpdater.Program.Main();

            //System.Diagnostics.Process.Start(appUpdater);

            //using (Transaction transaction = new Transaction(doc, "Creating Note BLock"))

            using (Transaction tx = new Transaction(doc, "Update"))
            {
                tx.Start();

                OAToolsUpdater.Updater.RunUpdate();

                tx.Commit();
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }

    }
}

