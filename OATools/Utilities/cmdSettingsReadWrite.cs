using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OATools.Utilities
{
    public class cmdSettingsReadWrite
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/Additional"; //this gives C:\Users\<userName>\AppData\Roaming\OATools
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;

        //static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        //static string directory = appData + "/OATools";
        //static string fileName = "OATools_Settings";
        //static string fileType = "ini";
        //public static string path = directory + "/" + fileName + "." + fileType;
        //public static string defaultPath = directory + "/" + "DNotes_default_CSVFile" + "." + fileType;



        public void UpdateSetting(String tag, String settingToWrite)
        {

            //Check for file
            if (!File.Exists(path))
            {
                //if no file exists tell user to initialize the app
                TaskDialog.Show("Message", "Please initialize OA Tools");
            }

            else
            {
                //WriteAllLines takes a string[] and writes it to a file
                //ReadAllLines reads a string[] from a file
                File.WriteAllLines(path, File.ReadAllLines(path).Select(x =>

                    {
                    // If the line starts with the tag, we want to change that line
                    if (x.StartsWith(tag)) return tag + settingToWrite;                      

                    // If the line isn't one of the ones we want to change, return the original string (x) without making any changes
                    return x;

                    }));
            }
        }




        public string GetSetting(string tag)
        {
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string rawLine;
                while ((rawLine = streamReader.ReadLine()) != null)
                {
                    if (rawLine.StartsWith(tag))
                    {

                        rawLine = rawLine.Replace(tag, "");

                        return rawLine;
                    }
                    //return line;
                }

                

                return rawLine;
            }
        }

    }
}

