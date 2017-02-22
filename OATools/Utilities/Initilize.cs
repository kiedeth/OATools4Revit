using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;

namespace OATools.Utilities
{
    [Transaction(TransactionMode.Manual)]
    public class Initilize : IExternalCommand
    {

        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/OATools";
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;


        public void initializeApp()
        {
            //Check for directory if null create it
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            //Check for settings file if null create it
            if (!File.Exists(path)) CreateSettingsFile();

            else TaskDialog.Show("Message", "OA Tools has already been initialized");
            

            return;
        }

        public void CreateSettingsFile()
        {
            //Set the file path
            var path = directory + "/OATools_Settings.ini";
            //var path = @"C:/Users/jschaad/Documents/Visual Studio 2015/Projects/OATools/OATools/DNotes/OAToolsSettings.ini";

            using (StreamWriter sw = new StreamWriter(path))
            {
                String h1 = "<OA TOOLS 4 REVIT SETTINGS FILE - DO NOT EDIT MANUALLY>";
                String h2 = "<THIS APP WAS INITIALIZED ON:" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ">";
                String h3 = "<SETTINGS TO FOLLOW:>";
                sw.WriteLine(h1);
                sw.WriteLine(h2);
                sw.WriteLine(h3);
                sw.Close();
            }
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            using (Transaction tx = new Transaction(doc, "Initialize App"))
            {
                tx.Start();

                initializeApp();

                tx.Commit();
            }
          return Result.Succeeded;
        }
    }


}
