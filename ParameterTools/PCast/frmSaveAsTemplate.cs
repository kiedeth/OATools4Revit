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

namespace OATools2018.ParameterTools.PCast
{
    public partial class frmSaveAsTemplate : Form
    {
        //Declare the mySet DataTable as public
        public DataTable setToWrite = new DataTable();
        public string pathToTemplateFile;
        private StreamWriter m_outputFile;
        private string m_templateFileName;
        private static ExternalCommandData commandData;
        string delimitator = "\t";
        

        public frmSaveAsTemplate(string pathToTemplateFile, DataTable mySet)
        {
            InitializeComponent();

            //Set the set to write
            setToWrite = mySet;
            
            //Set the textbox to the template file path
            tbxTemplateToWriteInto.Text = pathToTemplateFile;

            //Set the template file path
            m_templateFileName = pathToTemplateFile;
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxTemplateName.Text == "")
            {
                TaskDialog.Show("Error", "Please enter a template name.");
            }
            else
            {
                try
                {
                    writeDataToFile(setToWrite, m_templateFileName, tbxTemplateName.Text);
                }
                catch (System.ArgumentNullException) // oh, come on.
                {
                    TaskDialog.Show("FindImports",
                      "That's just not fair. Null argument for StreamWriter()");
                }               
            }
        }

        private void writeDataToFile(DataTable submittedDataTable, string submittedFilePath, string templateName)
        {
            int columnCount = 9;

            if (!File.Exists(submittedFilePath))
            {
                File.Create(submittedFilePath);
            }
            if (new FileInfo(submittedFilePath).Length == 0)
            {
                bool notEmpty = clsVerifyPCastTemplate.createEmptyTemplateFile();
            }
            if (new FileInfo(submittedFilePath).Length > 0)
            {
                using (StreamWriter writer = new StreamWriter(submittedFilePath, true))
                {

                    for (int row = 0; row < submittedDataTable.Rows.Count; row++)
                    {

                        for (int col = 0; col < columnCount; col++)
                        {
                            if (col == 0)
                            {
                                writer.Write(templateName + delimitator);
                            }
                            else
                            {
                                writer.Write(submittedDataTable.Rows[row][col]);

                                if (col < columnCount - 1)
                                {
                                    writer.Write(delimitator);
                                }
                                else
                                {
                                    writer.Write("\r\n");
                                }
                            }

 

                        }
                    }

                    writer.Close();
                    writer.Dispose();

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}


//private void writeDataToFile(DataTable submittedDataTable, string submittedFilePath, string templateName)
//{
//    int i = 0;

//    using (StreamWriter writer = new StreamWriter(submittedFilePath, true))
//    {

//    }

//    StreamWriter sw = null;
//    sw = new StreamWriter(submittedFilePath, true);

//    if (!File.Exists(submittedFilePath))
//    {
//        File.Create(submittedFilePath);
//    }
//    if (new FileInfo(submittedFilePath).Length == 0)
//    {
//        for (i = 0; i < submittedDataTable.Columns.Count - 1; i++)
//        {
//            sw.Write(submittedDataTable.Columns[i].ColumnName + "\t");
//        }
//        sw.Write(submittedDataTable.Columns[i].ColumnName);
//        sw.WriteLine();
//    }
//    else
//    {
//        for (int i2 = 1; i2 < submittedDataTable.Rows.Count; i2++)
//        {
//            submittedDataTable.Rows[i2]["TemplateName"] = templateName;
//        }
//        sw.Write(submittedDataTable.Columns[i].ColumnName);
//        sw.WriteLine();
//        foreach (DataRow row in submittedDataTable.Rows)
//        {
//            object[] array = row.ItemArray;
//            for (i = 0; i < array.Length - 1; i++)
//            {
//                sw.Write(array[i].ToString() + "\t");
//            }
//            sw.Write(array[i].ToString());
//            sw.WriteLine();
//        }
//    }
//    sw.Close();
//    sw.Dispose();
//}