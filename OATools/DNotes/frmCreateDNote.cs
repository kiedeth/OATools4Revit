/// <summary>
/// On form initialize:
/// First get the stored setting in the settings file
/// Then set the datagrid source to this returned file
/// put the path in the textbox for visual feedback 
/// reload the grid by setting its datasource
/// </summary>


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
using OATools.Utilities;

namespace OATools.DNotes
{
    public partial class frmCreateDNote : System.Windows.Forms.Form
    {
        //String textFilePath;

        void GetDNoteFilePathFromSettings()
        {
            //Set the class
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();

            //Get the path from the settings file
            string returnedDNoteFilePath = cls.GetSetting("<DNOTE_FILE_PATH>");

            //Read the CSV file
            ReadCSV(returnedDNoteFilePath);

            //Set the textbox text to the returned path for visual feedback 
            tbxFilePath.Text = returnedDNoteFilePath;                                  
            
        }

        //Make the datagrid visible 
        public DataGridView NotesFromFile
        {
            get { return this.dgvNotesFromFile; }
        }

        //InitializeComponent
        public frmCreateDNote(string sheetNumber)
        {
            InitializeComponent();

            //Get the text file path from the settings file
            GetDNoteFilePathFromSettings();

            //Set sheet number textbox to returned sheet number
            SetSheetNumber(sheetNumber);
        }

        //OK btn click
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        //Set sheet number (called from cmd class)
        public void SetSheetNumber(string v)
        {
            tbxSheet_number.Text = v;
        }

        //Declare Static variables
        public static string DNoteFilePathInput = string.Empty;
        public static string DNoteNumberInput = string.Empty;
        public static string DNoteSheetInput = string.Empty;
        public static string DNoteTextInput = string.Empty;

        //Set textBox Value to this variable on any event to be passed to the cmd class
        private void tbxFilePath_TextChanged(object sender, EventArgs e)
        {
            ////Set the var to the textbox value
            //DNoteFilePathInput = tbxFilePath.Text;

            ////Write the path in the textbox to settings file
            //cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            //cls.UpdateSetting("<DNOTE_FILE_PATH>", tbxFilePath.Text);

            ////Read the new CSV file everytime the textbox changes 
            //ReadCSV(textFilePath);
        }

        private void tbxDNoteNumber_TextChanged(object sender, EventArgs e)
        {
            DNoteNumberInput = tbxDNoteNumber.Text;
        }

        private void tbxSheet_number_TextChanged(object sender, EventArgs e)
        {
            DNoteSheetInput = tbxSheet_number.Text;
        }

        private void txbDNoteText_TextChanged(object sender, EventArgs e)
        {
            DNoteTextInput = tbxDNoteText.Text;
        }



        private DataTable ReadCSV(string textFilePath)
        {
            if (textFilePath == null)
            {
                //This value will always be null when the form is initialized because the path has not been read from the settings file yet
            }

            DataTable csvDataTable = new DataTable();
            try
            {
                //no try/catch - add these in yourselfs or let exception happen
                String[] csvData = File.ReadAllLines(textFilePath);

                //if no data
                if (csvData.Length == 0)
                {
                    return csvDataTable;
                }

                String[] headings = csvData[0].Split(';');

                //for each heading
                for (int i = 0; i < headings.Length; i++)
                {
                    ////replace spaces with underscores for column names
                    //headings[i] = headings[i].Replace(" ", "_");

                    //add a column for each heading
                    csvDataTable.Columns.Add(headings[i]);

                }

                //populate the DataTable
                for (int i = 1; i < csvData.Length; i++)
                {
                    //create new rows
                    DataRow row = csvDataTable.NewRow();

                    for (int j = 0; j < headings.Length; j++)
                    {
                        //fill them
                        row[j] = csvData[i].Split(';')[j];

                    }

                    //add rows to over DataTable

                    csvDataTable.Rows.Add(row);
                    dgvNotesFromFile.DataSource = csvDataTable.DefaultView;

                }
            }

            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
            }
            //return the CSV DataTable

            return csvDataTable;


        }

        private void dgvNotesFromFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string jobId = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;

            string DNoteTextFromFile = dgvNotesFromFile.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            //string DNoteTextFromFile = dgvNotesFromFile.SelectedCells.ToString();

            tbxDNoteText.Text = DNoteTextFromFile;
        }

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //Create the dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";

            //Set the dialog title
            openFileDialog1.Title = "Browse for DNote CSV File";

            //Perform checks
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            //Set default extension
            openFileDialog1.DefaultExt = "csv";

            //Set the file type filter
            openFileDialog1.Filter = "DNote Files (*.csv)|*.csv";  //"Text files (*.txt)|*.txt|All files (*.*)|*.*"

            openFileDialog1.FilterIndex = 2;

            //Open to last directory
            openFileDialog1.RestoreDirectory = true;

            //Include readOnly files
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            //If the user clicks ok show the path in the textbox
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Set the text box to the returned path
                //tbxFilePath.Text = openFileDialog1.FileName;

                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<DNOTE_FILE_PATH>", openFileDialog1.FileName);

                //Call the method to reload the file path from settings and put it into the grid
                GetDNoteFilePathFromSettings();
            }//if

        }//btnOpenFile_Click


        private void btnNewCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = @"C:\";

            saveFileDialog1.Title = "Save DNote File";

            saveFileDialog1.CheckFileExists = false;

            saveFileDialog1.CheckPathExists = true;

            saveFileDialog1.DefaultExt = "csv";

            saveFileDialog1.Filter = "DNote files (*.csv)|*.csv";

            saveFileDialog1.FileName = "DNotes";

            saveFileDialog1.FilterIndex = 2;

            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = false;


            


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {
                //Create the DNotes datatable
                DataTable dt = CreateCSVFile.CreateDNoteDataTable();

                //Get the filepath from the save dialog
                String filePath = saveFileDialog1.FileName;

                //Send the datatable to the CSV writer
                dt.ToCSV(filePath);

                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<DNOTE_FILE_PATH>", filePath);

                //Call the method to reload the updated file path from settings
                GetDNoteFilePathFromSettings();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Write textbox text to DNote file
            WriteToFile cls = new WriteToFile();
            cls.AppendLineToDNoteFile(tbxDNoteText.Text);

            //Call the method to reload the updated file path from settings
            GetDNoteFilePathFromSettings();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}

