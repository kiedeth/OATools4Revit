using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools.ViewFilters
{
    public partial class frmProjectParameters : Form
    {


        public frmProjectParameters(ExternalCommandData commandData)
        {
            InitializeComponent();

            DataSet ds = Convert(commandData, "myTable", "\t");

            dgvProjectParameters.DataSource = ds.Tables["myTable"];

        }

        public frmProjectParameters()
        { }

        /// <summary>
        /// Converts a given delimited file into a dataset. 
        /// Assumes that the first line    
        /// of the text file contains the column names.
        /// </summary>
        /// <param name="File">The name of the file to open</param>    
        /// <param name="TableName">The name of the 
        /// Table to be made within the DataSet returned</param>
        /// <param name="delimiter">The string to delimit by</param>
        /// <returns></returns>  
        public static DataSet Convert(ExternalCommandData commandData, string TableName, string delimiter)
        {
            //The DataSet to Return
            DataSet result = new DataSet();

            //Instantiate the class
            clsGetProjectParameters c = new clsGetProjectParameters();

            //Get the parameters
            String myString = c.ReturnParameters(commandData).ToString();

            //Split the first line into the columns @ the defined delimiter      
            string[] columns = myString.Split(delimiter.ToCharArray());

            //Add the new DataTable to the RecordSet
            result.Tables.Add(TableName);

            //Cycle the colums, adding those that don't exist yet and sequencing the ones that do.
            foreach (string col in columns)
            {
                bool added = false;
                string next = "";
                int i = 0;
                while (!added)
                {
                    //Build the column name and remove any unwanted characters.
                    string columnname = col + next;
                    columnname = columnname.Replace("#", "");
                    columnname = columnname.Replace("'", "");
                    columnname = columnname.Replace("&", "");

                    //See if the column already exists
                    if (!result.Tables[TableName].Columns.Contains(columnname))
                    {
                        //if it doesn't then we add it here and mark it as added
                        result.Tables[TableName].Columns.Add(columnname);
                        added = true;
                    }
                    else
                    {
                        //if it did exist then we increment the sequencer and try again.
                        i++;
                        next = "_" + i.ToString();
                    }
                }
            }

            //Read the rest of the data in the file.        
            string AllData = myString;

            //Split off each row at the Carriage Return/Line Feed
            //Default line ending in most windows exports.  
            //You may have to edit this to match your particular file.
            //This will work for Excel, Access, etc. default exports.
            string[] rows = AllData.Split("\r\n".ToCharArray());

            //Now add each row to the DataSet        
            foreach (string r in rows)
            {
                //Split the row at the delimiter.
                string[] items = r.Split(delimiter.ToCharArray());

                //Add the item
                result.Tables[TableName].Rows.Add(items);
            }

            //Return the imported data.        
            return result;
        }
    }
}
