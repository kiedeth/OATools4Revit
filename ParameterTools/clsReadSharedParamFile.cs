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

namespace OATools.ParameterTools
{

    public static class clsReadSharedParamFile
    {



        public static DataTable ReadSharedParamFile(string fileName)
        {
            string line = null;
            //Create the dt
            DataTable datatable = new DataTable();

            using (StreamReader reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    while (!line.StartsWith("GROUP"))
                    {
                        continue;
                    }
                    char[] delimiter = new char[] { '\t' };
                    string[] columnheaders = reader.ReadLine().Split(delimiter);
                    foreach (string columnheader in columnheaders)
                    {
                        datatable.Columns.Add(columnheader); // i've added the column headers here.
                    }

                    while (reader.Peek() > 0)
                    {
                        DataRow datarow = datatable.NewRow();

                        datarow.ItemArray = reader.ReadLine().Split(delimiter);

                        datatable.Rows.Add(datarow);
                    }
                }
                reader.Dispose();
                reader.Close();
                return datatable;
            }




            ////Create the dt
            //DataTable datatable = new DataTable();

            //using (StreamReader streamreader = new StreamReader(fileName))
            //{

            //    while ((!streamreader.ReadLine().StartsWith("GROUP")))
            //    {
            //        continue;
            //    }

            //    char[] delimiter = new char[] { '\t' };
            //    string[] columnheaders = streamreader.ReadLine().Split(delimiter);
            //    foreach (string columnheader in columnheaders)
            //    {
            //        datatable.Columns.Add(columnheader); // I've added the column headers here.
            //    }

            //    while (streamreader.Peek() > 0)
            //    {
            //        DataRow datarow = datatable.NewRow();
            //        datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
            //        datatable.Rows.Add(datarow);
            //    }

            //    streamreader.Dispose();
            //    streamreader.Close();
            //}

            //return datatable;


        }


    }

}



