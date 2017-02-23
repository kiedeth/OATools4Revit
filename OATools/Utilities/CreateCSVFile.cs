using Autodesk.Revit.UI;
using System;
using System.IO;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Data;
using System.Linq;

namespace OATools.Utilities
{
    public static class CreateCSVFile
    {

        public static DataTable CreateDefaultDNoteDataTable()
        {
            DataTable table = new DataTable();
            //columns  
            //table.Columns.Add("NUMBER", typeof(int));
            table.Columns.Add("NOTE TEXT", typeof(string));

            //data  
            table.Rows.Add("This is the default DNotes File created when OA Tools was initialized.");
            table.Rows.Add("Use Create New File to create your own file.");

            return table;
        }

        public static DataTable CreateDNoteDataTable()
        {
            DataTable table = new DataTable();
            //columns  
            //table.Columns.Add("NUMBER", typeof(int));
            table.Columns.Add("NOTE TEXT", typeof(string));

            //data (at least one row has to be added for the reader to load the file)
            table.Rows.Add("");

            return table;
        }

        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

        }//ToCSV
    }//CreateCSVFile
}//OATools.Utilities
