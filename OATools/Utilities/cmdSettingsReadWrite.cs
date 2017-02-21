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

        public void WriteSetting(String tag, String settingToWrite)
        {
            var path = @"C:/Users/jschaad/Documents/Visual Studio 2015/Projects/OATools/OATools/DNotes/OAToolsSettings.ini";
            //String header = "<<<THIS IS AN OA TOOLS 4 REVIT SETTINGS FILE - DO NOT EDIT MANUALLY>>>";
            //string line;



            File.WriteAllLines(path,
            //WriteAllLines takes a string[] and writes it to a file

            File.ReadAllLines(path)
            //ReadAllLines reads a string[] from a file

            .Select(x =>
            // .Select lets us transform the data... So it's going to go over each string in the array (each line in the file), and do whatever we say to do.  It's going to execute the following code for each line in the file (and the line will be stored in "x" because i said "x =>" above)

            {
                if (x.StartsWith(tag)) return tag + settingToWrite;
                   // If the line starts with "ip = ", we want to change that line...

                  //else if (x.StartsWith("name = ")) return "name = " + box2.Text;
                    // If the line starts with "name = ", we also want to change that line...

                 return x;
                 // If the line isn't one of the ones we want to change, we just return the original string (x) without making any changes

            }));


        }

    }
}


//Stream l_fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
//StreamReader l_reader = new StreamReader(l_fileStream);
//StreamWriter l_writer = new StreamWriter(l_fileStream);


//using (StreamWriter sw = new StreamWriter(path))
//{
//    String prefix = "<|";
//    String sufix = "|>";
//    String header = "<<<THIS IS AN OA TOOLS 4 REVIT SETTINGS FILE - DO NOT EDIT MANUALLY>>>";
//    sw.WriteLine(header);


//    if (settingToWrite.StartsWith(tag))
//    {
//        sw.WriteLine(tag + settingToWrite);
//    }

//}



//private static string findLine(string tag, string settingToWrite)
//{
//    // Determine whether a tag begins the string.
//    if (settingToWrite.Trim().StartsWith(tag))
//    {
//        // Find the closing tag.
//        int lastLocation = settingToWrite.IndexOf(tag);
//        // Remove the tag.
//        if (lastLocation >= 0)
//        {
//            settingToWrite = settingToWrite.Substring(lastLocation + 1);

//            // Remove any additional starting tags.
//            settingToWrite = findLine(tag, settingToWrite);
//        }
//    }

//    return settingToWrite;
//}










//public void Write()
//{

//    string[] names = new string[] { "[DNOTE SETTINGS], ", "TEST" };
//    using (StreamWriter sw = new StreamWriter("C:/Users/jschaad/Documents/Visual Studio 2015/Projects/OATools/OATools/DNotes/OAToolsSettings.ini"))
//    {

//        foreach (string s in names)
//        {
//            sw.WriteLine(s);
//        }
//    }

//    // Read and show each line from the file.
//    //string line = "";
//    //using (StreamReader sr = new StreamReader("C:/Users/jschaad/Documents/Visual Studio 2015/Projects/OATools/OATools/DNotes/OAToolsSettings.ini"))
//    //{
//    //    while ((line = sr.ReadLine()) != null)
//    //    {
//    //        Console.WriteLine(line);
//    //    }
//    //}

//    //Console.ReadKey();
//}
