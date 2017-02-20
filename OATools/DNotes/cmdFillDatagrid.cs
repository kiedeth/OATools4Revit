using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using System.Threading.Tasks;
using OATools.Main;
using System.IO;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI.Selection;

namespace OATools.DNotes
{
    [Transaction(TransactionMode.Manual)]
    public class cmdFillDatagrid : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            throw new NotImplementedException();
        }


        private void readTextFile()
        {
            TextReader reader = new StreamReader(@"C:\Users\Alex\Documents\Visual Studio 2010\Projects\ReaderTest\orders.txt");
            string contents = reader.ReadToEnd();
            string[] myArray = { contents };
            foreach (string gotya in myArray)
            {

                //dataGridView1.Columns.Add("colname", "Name");
                //dataGridView1.Rows.Add(contents);
                //dataGridView1.DataSource = gotya;
            }

            reader.Close();
        }
    }


}
