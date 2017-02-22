using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OATools.Utilities
{
    class cmdSettingsReadWrite
    {
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/OATools";
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;



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

        public void CreateSetting(String tag, String settingToWrite)
        {

        }
    }
}




//            else
//            {


//                File.WriteAllLines(path,
//                //WriteAllLines takes a string[] and writes it to a file

//                File.ReadAllLines(path)
//                //ReadAllLines reads a string[] from a file

//                .Select(x =>
//                // .Select lets us transform the data... So it's going to go over each string in the array (each line in the file), and do whatever we say to do.  It's going to execute the following code for each line in the file (and the line will be stored in "x" because i said "x =>" above)

//                {
//    if (x.StartsWith(tag)) return tag + settingToWrite;
//    // If the line starts with "ip = ", we want to change that line...

//    //else if (x.StartsWith("name = ")) return "name = " + box2.Text;
//    // If the line starts with "name = ", we also want to change that line...

//    return x;
//    // If the line isn't one of the ones we want to change, we just return the original string (x) without making any changes

//}));