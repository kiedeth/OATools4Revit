
using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using System.Collections.Generic;
using System.Text;
using OATools2018Updater;
using OATools2018.Utilities;
//using System.Windows.Forms;

namespace OATools2018.Settings
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class cmdAbout : IExternalCommand
    {


        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        //static string addinsLocation = appData + "/Autodesk/Revit/Addins/2018";
        //static string appUpdater = addinsLocation + "/" + "OATools2018.bundle" + "/" + "AppUpdater.exe";


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

            using (Transaction tx = new Transaction(doc, "Update"))
            {
                tx.Start();

                //OATools2018Updater.Updater.RunUpdate();

                try
                {
                    eventToCallForm();
                }
                catch (Exception)
                {

                    throw;
                }

                tx.Commit();
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }

        public static void GetUpdate(int i)
        {

            OATools2018Updater.Updater.RunUpdate(i);

            //if (i == 1)
            //{
            //    OATools2018Updater.Updater.RunUpdate(1);
            //}
            //if (i == 2)
            //{
            //    OATools2018Updater.Updater.RunUpdate(2);
            //}
        }


        public void eventToCallForm()
        {
            var result = frmAbout.Execute();
            if (result.Result == System.Windows.Forms.DialogResult.Retry)
            {
                //TaskDialog.Show("test", "test");
            }
        }

    }
}

