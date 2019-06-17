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

    public class clsReadTemplateFile
    {


        public DataTable GetDataSourceFromFile(string fileName)
        {
            
            //Create the dt
            DataTable datatable = new DataTable();
            using (StreamReader streamreader = new StreamReader(fileName))
            {
                char[] delimiter = new char[] { '\t' };
                string[] columnheaders = streamreader.ReadLine().Split(delimiter);
                foreach (string columnheader in columnheaders)
                {
                    datatable.Columns.Add(columnheader); // I've added the column headers here.
                }

                while (streamreader.Peek() > 0)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
                    datatable.Rows.Add(datarow);
                }

                streamreader.Dispose();
                streamreader.Close();                
            }
            
            return datatable;
        }

      


        public DataTable RemoveDuplicateRows(DataTable table, string DistinctColumn)
        {
            try
            {
                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Check if records is already added to UniqueRecords otherwise,
                // Add the records to DuplicateRecords
                foreach (DataRow dRow in table.Rows)
                {
                    if (UniqueRecords.Contains(dRow[DistinctColumn]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[DistinctColumn]);
                }

                // Remove duplicate rows from DataTable added to DuplicateRecords
                foreach (DataRow dRow in DuplicateRecords)
                {
                    table.Rows.Remove(dRow);
                }

                // Return the clean DataTable which contains unique records.
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetSelectedTemplateRows_dt(DataTable rawTable, string templateName)
        {
            //Create the dt
            DataTable selectedRows_dt = new DataTable();

            foreach (var row in rawTable.Rows)
            {
                //see if the row starts with the template name
                if (row.ToString().StartsWith(templateName))
                {
                    //Add the passed row to the new dt
                    selectedRows_dt.Rows.Add(row);
                }
            }

            return selectedRows_dt;

        }

        public bool DeleteTemplate(string fileName, string tag)
        {
            string strFilePath = fileName;
            string strSearchText = tag;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(strFilePath, n);

            return true;
        }



    }

}



//public DataTable ConvertToDataTable (string filePath, int numberOfColumns)
//{
//    DataTable tbl = new DataTable();

//    for (int col = 0; col < numberOfColumns; col++)
//        tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));

//    string[] lines = System.IO.File.ReadAllLines(filePath);

//    foreach (string line in lines)
//    {
//        var cols = line.Split(':');

//        DataRow dr = tbl.NewRow();
//        for(int cIndex=0; cIndex < 3; cIndex++)
//        {
//            dr[cIndex] = cols[cIndex];
//        }

//        tbl.Rows.Add(dr);
//    }

//    return tbl;
//}


//public DataTable GetDataSourceFromFile(string fileName)
//{
//    //Create the dt
//    DataTable dt = new DataTable("TextFile");

//    string[] columns = null;

//    //Read the text file
//    var lines = File.ReadAllLines(fileName);

//    // assuming the first row contains the columns information
//    if (lines.Count() > 0)
//    {
//        columns = lines[0].Split(new char[] { '\t' });

//        foreach (var column in columns)
//            dt.Columns.Add(column, typeof(string));
//    }

//    // reading rest of the data
//    for (int i = 1; i < lines.Count(); i++)
//    {
//        DataRow dr = dt.NewRow();
//        string[] values = lines[i].Split(new char[] { '\t' });

//        for (int j = 0; j < values.Count() && j < columns.Count(); j++)
//            dr[j] = values[j];

//        dt.Rows.Add(dr);
//    }



//    //return the dt
//    return dt;
//}