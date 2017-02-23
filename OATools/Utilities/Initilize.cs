using Autodesk.Revit.UI;
using System;
using System.IO;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Data;

namespace OATools.Utilities
{
    [Transaction(TransactionMode.Manual)]
    public class Initilize : IExternalCommand
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/OATools";
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;
        public static string defaultDNotesFilePath = directory + "/" + "DNotes_default_CSVFile" + "." + "csv";



        //Perform a series of checks and perform the required tasks
        public void initializeApp()
        {
            //Check for directory if null create it
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            //Check for settings file if null create it
            if (!File.Exists(path)) CreateSettingsFile();

            //Check for DNotes file if null create it
            if (!File.Exists(defaultDNotesFilePath)) CreateDefaultDNotesFile();




            //Else show message
            else TaskDialog.Show("Message", "OA Tools has already been initialized.");
            
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
                String t2 = "<NEW_TAG>";
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
}//OATools.Utilities
