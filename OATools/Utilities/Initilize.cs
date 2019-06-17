using Autodesk.Revit.UI;
using System;
using System.IO;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Data;

namespace OATools2018.Utilities
{
    [Transaction(TransactionMode.Manual)]
    public class Initilize : IExternalCommand
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/Autodesk/Revit/Addins/2018/OATools2018.bundle/Additional"; 
        static string fileName = "OATools2018_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;
        public static string defaultDNotesFilePath = directory + "/" + "DNotes_default_CSVFile" + "." + "csv";

        //Confirm initialize
        public bool IsAppInitialized()
        {
            //Check for settings file
            if (!File.Exists(path))
            {
                TaskDialog.Show("Error!", "Please Initialize OA Tools!");

                return false;
            }

            return true;
        }

        //Perform a series of checks and perform the required tasks
        public void initializeApp()
        {
            if (!File.Exists(path))
            {
                //Download Settings File
                bool sucess = OATools2018Updater.Updater.GetSettingsFile();

                if (sucess)
                {
                    TaskDialog.Show("Success", "OA Tools has been sucessfully initialized.");
                }
                else
                {
                    TaskDialog.Show("Error", "Something went wrong! ERROR CODE:1776.");
                }
            }

            else
            {
                TaskDialog.Show("Message", "OA Tools has already been initialized.");
            }

            //Check for directory if null create it
            //if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            ////Check for settings file if null create it
            //if (!File.Exists(path)) CreateSettingsFile();

            ////Check for DNotes file if null create it
            //if (!File.Exists(defaultDNotesFilePath)) CreateDefaultDNotesFile();

            ////Else show message
            //else TaskDialog.Show("Message", "OA Tools has already been initialized.");

            //Return back
            return;

        }//initializeApp

        //Create a default settings file
        public void CreateSettingsFile()
        {
            //Use the streamwriter the write into the file (this also creates the file if none exists)
            using (StreamWriter sw = new StreamWriter(path))
            {
                //Construct the lines
                String h1 = "<OA TOOLS 4 REVIT SETTINGS FILE - DO NOT EDIT MANUALLY>";
                String h2 = "<THIS APP WAS INITIALIZED ON:" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ">";
                String h3 = "<SETTINGS TO FOLLOW:>";

                //Create blank setting tags
                String t1 = "<DNOTE_FILE_PATH>" + defaultDNotesFilePath;
                String t2 = "<IMPORT_VIEW_FILE_PATH>";
                String t3 = "<NEW_TAG>";
                String t4 = "<NEW_TAG>";

                //Write the lines
                sw.WriteLine(h1);
                sw.WriteLine(h2);
                sw.WriteLine(h3);

                //Write the tags
                sw.WriteLine(t1);
                sw.WriteLine(t2);
                sw.WriteLine(t3);
                sw.WriteLine(t4);

                //Close the streamwriter
                sw.Close();
            }//Using
        }//CreateSettingsFile

        public void CreateDefaultDNotesFile()
        {

            DataTable dt = CreateCSVFile.CreateDefaultDNoteDataTable();

            dt.ToCSV(defaultDNotesFilePath);
        }

        //Execute the command
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            using (Transaction tx = new Transaction(doc, "Initialize App"))
            {   
                //Start transaction
                tx.Start();

                //Initialize
                initializeApp();

                //Commit the transaction
                tx.Commit();

            }//Using
          return Result.Succeeded;

        }//Execute

    }//Initilize
}//OATools2018.Utilities
