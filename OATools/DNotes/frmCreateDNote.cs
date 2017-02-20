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

namespace OATools.DNotes
{
    public partial class frmCreateDNote : System.Windows.Forms.Form
    {

        public DataGridView NotesFromFile
        {
            get { return this.dgvNotesFromFile; }
        }

        public frmCreateDNote(string sheetNumber)
        {
            InitializeComponent();

            ReadCSV("C:/Users/jschaad/documents/visual studio 2015/Projects/OATools/OATools/DNotes/DNotesCSVFile.csv");

            SetSheetNumber(sheetNumber);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void SetSheetNumber(string v)
        {
            tbxSheet_number.Text = v;
        }

        //Declare a Static variable
        public static string DNoteNumberInput = string.Empty;
        public static string DNoteSheetInput = string.Empty;
        public static string DNoteTextInput = string.Empty;

        //Set textBox Value to this variable on any event


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
    }
}


//int i = 0;
//foreach( string gotya in myArray )
//{
//  string[] values = gotya.Split(' ');

//int j = 0;
//  foreach( string value in values)
//  {
//    dataGridView1.Rows.Add();
//    dataGridView1.Rows[i].Cells[j]).Value = value;
//    j++
//  }
//  i++;
//}