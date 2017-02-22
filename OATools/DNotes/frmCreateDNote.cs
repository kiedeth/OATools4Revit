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
        //Make the datagrid visible 
        public DataGridView NotesFromFile
        {
            get { return this.dgvNotesFromFile; }
        }

        //InitializeComponent
        public frmCreateDNote(string sheetNumber)
        {
            InitializeComponent();

            ReadCSV(DNoteFilePathInput);

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

        //Set textBox Value to this variable on any event

        private void tbxFilePath_TextChanged(object sender, EventArgs e)
        {
            DNoteFilePathInput = tbxFilePath.Text;
            dgvNotesFromFile.Refresh();
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



        private DataTable ReadCSV(string FileName)
        {
            if (FileName == null)
            {
                TaskDialog.Show("Error", "Please set a file path");
            }

            DataTable csvDataTable = new DataTable();
            try
            {
                //no try/catch - add these in yourselfs or let exception happen
                String[] csvData = File.ReadAllLines(FileName);

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
                System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();



            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "Browse Text Files";



            openFileDialog1.CheckFileExists = true;

            openFileDialog1.CheckPathExists = true;



            openFileDialog1.DefaultExt = "csv";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;

            openFileDialog1.RestoreDirectory = true;



            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                tbxFilePath.Text = openFileDialog1.FileName;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            cls.WriteSetting("<DNOTE_TEXTFILE_PATH>", "C:/Users/jschaad/Documents/Visual Studio 2015/Projects/OATools/OATools/DNotes/test");

            //cls.WriteSetting("<TEST_SETTING>", "TEST");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Initilize cls = new Initilize();
            cls.initializeApp();
        }
    }
}

