#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections;
#endregion // Namespaces

namespace OATools2018.ParameterTools
{
    class clsWriteParametersToFile
    {
        ////Set some static vars
        //static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        //static string directory = appData + "/Autodesk/Revit/Addins/2018/OATools2018.bundle/Additional"; //this gives C:\Users\<userName>\AppData\Roaming\OATools2018
        //static string fileName = "OATools2018_pCast_mySet_dump";
        //static string fileType = "txt";
        //public static string mySetDumpFile = directory + "/" + fileName + "." + fileType;

        List<string> mySet;


        public void WriteParametersToFile(string filePath, string[,] myArray)
        {
            bool header = writeHeader(filePath);

            if (header)
            {
                bool mySet = writeParameters(filePath, myArray);
            }
            
            //mySet = mySetListOfStrings;
        }

        private bool writeHeader(string filePath)
        {
            //Build the header
            var header = new StringBuilder();
            header.AppendLine("# This is a Revit shared parameter file.");
            header.AppendLine("# Do not edit manually.");
            header.AppendLine("*META" + "\t" + "VERSION	MINVERSION");
            header.AppendLine("META" + "\t" + "2" + "\t" + "1");
            header.AppendLine("*GROUP" + "\t" + "ID" + "\t" + "NAME");
            header.AppendLine("GROUP" + "\t" + "1" + "\t" + "Exported Parameters");
            header.AppendLine("*PARAM" + "\t" + "GUID" + "\t" + "NAME" + "\t" + "DATATYPE" + "\t" + "DATACATEGORY" + "\t" + "GROUP" + "\t" + "VISIBLE" + "\t" + "DESCRIPTION" + "\t" + "USERMODIFIABLE");

            //Store the header in memory
            var myString = header.ToString();
            var myByteArray = System.Text.Encoding.UTF8.GetBytes(myString);
            var ms = new MemoryStream(myByteArray);
            
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            ms.WriteTo(file);
            file.Close();
            ms.Close();

            return true;
        }

        private bool writeParameters(string filePath, string[,] myArray)
        {
            int m_rowCount = myArray.GetLength(0);
            int m_colCount = myArray.GetLength(1);

            FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(file);

            for (int i = 0; i < m_rowCount; i++)
            {
                //sw.Write("PARAM");

                for (int j = 0; j < m_colCount; j++)
                {
                    myArray[i, 3] = convertParameter(myArray[i, 3]);

                    string dataType = myArray[i, 3];

                    sw.Write(myArray[i, j] + "\t");
                }
                sw.Write("\r\n");
            }

            sw.Flush();
            sw.Close();

            //mySet.ForEach(sw.WriteLine);



            return true;
        }

        private string toUnderscoreCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        private string convertParameter(string param)
        {
            if (param == ParameterType.HVACAirflow.ToString()) param = "HVAC_AIR_FLOW";

            return param;
        }

    }
}


//private bool writeParameters(string[,] myArray)
//{
//    FileStream file = new FileStream("C:/Users/jschaad/Desktop/OATools2018/pCastTest.txt", FileMode.Append, FileAccess.Write);

//    StreamWriter sw = new StreamWriter(file);

//    foreach (string i in myArray)
//    {
//        sw.WriteLine(i);
//    }

//    sw.Close();

//    //mySet.ForEach(sw.WriteLine);



//    return true;
//}