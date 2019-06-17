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

    public static class clsReadSharedParamFile
    {



        public static DataTable ReadSharedParamFile(string fileName)
        {
            
            //Create the dt
            DataTable datatable = new DataTable();

            using (StreamReader reader = new StreamReader(fileName))
            {
                //string line = null;
                long count = 0;
                string line = reader.ReadLine();
                var lines = File.ReadAllLines(fileName);
                DataTable dt = new DataTable("Parameters");
                string[] columns = null;

                char[] delimiter = new char[] { '\t' };
                string[] columnheaders = line.Split(delimiter);

                long headerRow = 0;

                foreach (var l in lines)
                {
                    headerRow++;

                    if (l.StartsWith("*PARAM"))
                    {
                        break;
                    }                    
                }

                if (lines.Count() > 0)
                    {
                        columns = lines[headerRow-1].Split(delimiter);

                        foreach (var column in columns) dt.Columns.Add(column);
                    }


                //if (!String.IsNullOrEmpty(line) && line.StartsWith("PARAM"))
                //{

                for (long i = headerRow; i < lines.Count(); i++)
                {
                    DataRow dr = dt.NewRow();
                    string[] values = lines[i].Split(delimiter);

                    for (int j = 0; j < values.Count() && j < columns.Count(); j++) dr[j] = values[j];

                    dt.Rows.Add(dr);
                }



                //    //TaskDialog.Show("test", "test");

                //    //DataRow datarow = datatable.NewRow();

                //    //string[] values = line[i].Split(delimiter);

                //    //datarow.ItemArray = values;

                //    //datatable.Rows.Add(datarow);
                //}

                //else
                //{
                //    line = reader.ReadLine();
                //}





                reader.Dispose();
                reader.Close();
                return dt;
            }

        }

        //public static DataTable ReadSharedParamFile2(string fileName)
        //{

        //    //Create the dt
        //    DataTable datatable = new DataTable();

        //    using (StreamReader reader = new StreamReader(fileName))
        //    {
        //        //string line = null;
        //        long count = 0;
        //        string line = reader.ReadLine();

        //        while (line != null)
        //        {

        //            char[] delimiter = new char[] { '\t' };
        //            string[] columnheaders = line.Split(delimiter);

        //            //Find the col header line
        //            if (!String.IsNullOrEmpty(line) && line.StartsWith("*PARAM"))
        //            {
        //                //The header row is found, do something with it here

        //                //TaskDialog.Show("test", "Found header row");
        //                foreach (string columnheader in columnheaders)
        //                {
        //                    datatable.Columns.Add(columnheader); // i've added the column headers here.
        //                }

        //                line = null;

        //            }

        //            line = reader.ReadLine();

        //            //string[] parameterRow = line.Split(delimiter);

        //            //Read the parameters
        //            if (!String.IsNullOrEmpty(line) && line.StartsWith("PARAM"))
        //            {
        //                //The parameter rows are found, do something with them here
        //                count++;

        //                //TaskDialog.Show("test", "Parameter row");

        //                long inter = 0;


        //                while (inter <= count)
        //                {
        //                    //datatable.Columns.Add(row); 

        //                    DataRow datarow = datatable.NewRow();
        //                    datarow.ItemArray = reader.ReadLine().Split(delimiter);
        //                    datatable.Rows.Add(datarow);

        //                    inter++;
        //                }

        //                line = null;
        //            }

        //            count++;
        //        }


        //        reader.Dispose();
        //        reader.Close();
        //        return datatable;
        //    }

        //}



    }

}



