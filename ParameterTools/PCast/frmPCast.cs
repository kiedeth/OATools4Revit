using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using OATools.Utilities;
using OATools;
using OATools.ParameterTools;
using System.IO;

namespace OATools.ParameterTools.PCast
{
    public partial class frmPCast : System.Windows.Forms.Form
    {
        //Set the path to the template file
        static string pathToTemplate = pCastFilePathFromSettings();

        //Declare the reading class
        static clsReadTemplateFile readingClass = new clsReadTemplateFile();

        //Create the raw template file data table
        public static DataTable dt_rawTemplateFile = new DataTable();

        //Filter out the template names by removing duplicate rows
        public static DataTable dt_templateNames = new DataTable();

        //Create the mySet data table
        public static DataTable dt_mySet = new DataTable();

        //Create the mySet binding source
        public static BindingSource bs_mySet = new BindingSource();

        //Create the selected template dgv binding source
        public static BindingSource bs_selectedTemplate = new BindingSource();

        private static string pCastFilePathFromSettings()
        {
            //Read the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedPCastFilePath = cls.GetSetting("<PCAST_TEMPLATE_FILE_LOCATION>");

            //return the path
            return returnedPCastFilePath;
        }

        public frmPCast(ExternalCommandData commandData)
        {
            InitializeComponent();            

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            //Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            //Read the template file
            dt_rawTemplateFile = readingClass.GetDataSourceFromFile(pathToTemplate);

            //Set the template listbox text
            tbxTemplateFileLocation.Text = pathToTemplate;

            //set the selected bs data source to the raw template dt
            bs_selectedTemplate.DataSource = readingClass.GetDataSourceFromFile(pathToTemplate);

            //Filter the raw template file dataGrid
            dt_templateNames = readingClass.RemoveDuplicateRows(dt_rawTemplateFile, "TemplateName");

            //set the mySet binding source
            bs_mySet.DataSource = dt_mySet;

            //Fill the data grids
            fillTemplateGrid(pathToTemplate);
            fillParameterGrid(bs_selectedTemplate);
            //fillMySetGrid(bs_mySet);
        }

        //Button to set the path to the template file
        private void btnSetTemplatePath_Click(object sender, EventArgs e)
        {
            //Create the dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";

            //Set the dialog title
            openFileDialog1.Title = "Browse for pCast File";

            //Perform checks
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            //Set default extension
            openFileDialog1.DefaultExt = "txt";

            //Set the file type filter
            openFileDialog1.Filter = "pCast Files (*.txt)|*.txt";  //"Text files (*.txt)|*.txt|All files (*.*)|*.*"

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
                tbxTemplateFileLocation.Text = openFileDialog1.FileName;

                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<PCAST_TEMPLATE_FILE_LOCATION>", openFileDialog1.FileName);

                //Call the method to reload the file path from settings and put it into the box
                tbxTemplateFileLocation.Text = pCastFilePathFromSettings();

                //reload the template list
                fillTemplateGrid(pathToTemplate);

            }//if
        }//btnOpenFile_Click

        //Fill the template grid
        private void fillTemplateGrid(string path)
        {
            //Check to verify the dt is not empty
            if (dt_templateNames.Rows.Count > 0)
            {
                //set the datagridview source
                dgvTemplates.DataSource = dt_templateNames;
                //set some settings and hide columns
                dgvTemplates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTemplates.Columns[0].Visible = true;
                dgvTemplates.Columns[1].Visible = false;
                dgvTemplates.Columns[2].Visible = false;
                dgvTemplates.Columns[3].Visible = false;
                dgvTemplates.Columns[4].Visible = false;
                dgvTemplates.Columns[5].Visible = false;
                dgvTemplates.Columns[6].Visible = false;
                dgvTemplates.Columns[7].Visible = false;
                dgvTemplates.Columns[8].Visible = false;
                dgvTemplates.Columns[9].Visible = false;
                dgvTemplates.Columns[10].Visible = false;
                dgvTemplates.Columns[11].Visible = false;
                dgvTemplates.Columns[12].Visible = false;
                dgvTemplates.Columns[13].Visible = false;
                dgvTemplates.Columns[14].Visible = false;
                dgvTemplates.Columns[15].Visible = false;
                dgvTemplates.Columns[16].Visible = false;
                dgvTemplates.Columns[17].Visible = false;
                dgvTemplates.Columns[18].Visible = false;
                dgvTemplates.Columns[19].Visible = false;
                dgvTemplates.Columns[20].Visible = false;
            }
        }

        private void fillParameterGrid(BindingSource path)
        {
            //Check to verify the template dt is not empty
            if (dt_templateNames.Rows.Count > 0)
            {
                //set the datagridview source
                dgvParameters.DataSource = path;
                //set some settings and hide columns
                //dgvParameters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvParameters.AutoGenerateColumns = false;                

                //dgvParameters.Columns.Add("TemplateName", "TemplateName");
                //dgvParameters.Columns["TemplateName"].Visible = true;
                //dgvParameters.Columns.Add("GUID", "GUID");
                //dgvParameters.Columns["GUID"].Visible = true;
                //dgvParameters.Columns.Add("Name", "Name");
                //dgvParameters.Columns["Name"].Visible = true;
                //dgvParameters.Columns.Add("DataType", "DataType");
                //dgvParameters.Columns["DataType"].Visible = true;
                //dgvParameters.Columns.Add("GroupNumber", "GroupNumber");
                //dgvParameters.Columns["GroupNumber"].Visible = true;
                //dgvParameters.Columns.Add("GroupName", "GroupName");
                //dgvParameters.Columns["GroupName"].Visible = true;
                //dgvParameters.Columns.Add("Visible", "Visible");
                //dgvParameters.Columns["Visible"].Visible = true;
                //dgvParameters.Columns.Add("InstanceOrType", "InstanceOrType");
                //dgvParameters.Columns["InstanceOrType"].Visible = true;
                //dgvParameters.Columns.Add("GroupUnder", "GroupUnder");
                //dgvParameters.Columns["GroupUnder"].Visible = true;
                //dgvParameters.Columns.Add("Source", "Source");
                //dgvParameters.Columns["Source"].Visible = true;
                //dgvParameters.Columns.Add("ParamToReplace", "ParamToReplace");
                //dgvParameters.Columns["ParamToReplace"].Visible = true;
                //dgvParameters.Columns.Add("MapToElecConnector", "MapToElecConnector");
                //dgvParameters.Columns["MapToElecConnector"].Visible = true;
                //dgvParameters.Columns.Add("Value", "Value");
                //dgvParameters.Columns["Value"].Visible = true;
                //dgvParameters.Columns.Add("Formula", "Formula");
                //dgvParameters.Columns["Formula"].Visible = true;
                //dgvParameters.Columns.Add("SortOrder", "SortOrder");
                //dgvParameters.Columns["SortOrder"].Visible = true;
                //dgvParameters.Columns.Add("ToolTip", "ToolTip");
                //dgvParameters.Columns["ToolTip"].Visible = true;
                //dgvParameters.Columns.Add("Column17", "Test");
                //dgvParameters.Columns["Column17"].Visible = true;
                //dgvParameters.Columns.Add("Column18", "Test");
                //dgvParameters.Columns["Column18"].Visible = true;
                //dgvParameters.Columns.Add("Column19", "Test");
                //dgvParameters.Columns["Column19"].Visible = true;
                //dgvParameters.Columns.Add("Column20", "Test");
                //dgvParameters.Columns["Column20"].Visible = true;
                //dgvParameters.Columns.Add("Column21", "Test");
                //dgvParameters.Columns["Column21"].Visible = true;

                //Clone the columns to the mySet gird
                foreach (DataGridViewColumn c in dgvParameters.Columns)
                {
                    dgvMySet.Columns.Add(c.Clone() as DataGridViewColumn);
                }
            }
        }

        //Set some myGrid settings
        private void startMySetGrid()
        {
            //Check to verify the template dt is not empty
            if (dgvParameters.SelectedRows.Count > 0)
            {
                //set the datagridview source
                //dgvMySet.DataSource = path;
                //set some settings and hide columns
                dgvMySet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgvMySet.Columns.Add("Column1", "TemplateName");
                //dgvMySet.Columns[0].Visible = false;
                //dgvMySet.Columns.Add("Column2", "GUID");
                //dgvMySet.Columns[1].Visible = false;
                //dgvMySet.Columns.Add("Column3", "Name");
                //dgvMySet.Columns[2].Visible = true;
                //dgvMySet.Columns.Add("Column4", "DataType");
                //dgvMySet.Columns[3].Visible = true;
                //dgvMySet.Columns.Add("Column5", "GroupNumber");
                //dgvMySet.Columns[4].Visible = false;
                //dgvMySet.Columns.Add("Column6", "GroupName");
                //dgvMySet.Columns[5].Visible = false;
                //dgvMySet.Columns.Add("Column7", "Visible");
                //dgvMySet.Columns[6].Visible = false;
                //dgvMySet.Columns.Add("Column8", "InstanceOrType");
                //dgvMySet.Columns[7].Visible = false;
                //dgvMySet.Columns.Add("Column9", "GroupUnder");
                //dgvMySet.Columns[8].Visible = false;
                //dgvMySet.Columns.Add("Column10", "Source");
                //dgvMySet.Columns[9].Visible = false;
                //dgvMySet.Columns.Add("Column11", "ParamToReplace");
                //dgvMySet.Columns[10].Visible = false;
                //dgvMySet.Columns.Add("Column12", "MapToElecConnector");
                //dgvMySet.Columns[11].Visible = false;
                //dgvMySet.Columns.Add("Column13", "Value");
                //dgvMySet.Columns[12].Visible = false;
                //dgvMySet.Columns.Add("Column14", "Formula");
                //dgvMySet.Columns[13].Visible = false;
                //dgvMySet.Columns.Add("Column15", "SortOrder");
                //dgvMySet.Columns[14].Visible = false;
                //dgvMySet.Columns.Add("Column16", "ToolTip");
                //dgvMySet.Columns[15].Visible = false;
                //dgvMySet.Columns.Add("Column17", "Test");
                //dgvMySet.Columns[16].Visible = false;
                //dgvMySet.Columns.Add("Column18", "Test");
                //dgvMySet.Columns[17].Visible = false;
                //dgvMySet.Columns.Add("Column19", "Test");
                //dgvMySet.Columns[18].Visible = false;
                //dgvMySet.Columns.Add("Column20", "Test");
                //dgvMySet.Columns[19].Visible = false;
                //dgvMySet.Columns.Add("Column21", "Test");
                //dgvMySet.Columns[20].Visible = false;

                dgvMySet.Refresh();
            }
        }


        //Filter the parameters grid by the selected template
        private void dgvTemplates_SelectionChanged(object sender, EventArgs e)
        {
            //get the selected cell location (old way)
            int selectedRow = dgvTemplates.CurrentCell.RowIndex;
            int selectedCol = dgvTemplates.CurrentCell.ColumnIndex;
            string selectedTemplateName = dgvTemplates.Rows[selectedRow].Cells[selectedCol].Value.ToString();
            //get the selected cell location (new way)
            string selectedCell = dgvTemplates.CurrentCell.Value.ToString();

            //create a filter and use the selected cell text to filter by
            bs_selectedTemplate.Filter = string.Format("TemplateName LIKE '*{0}*'", selectedCell);

        }

        //The Parameter Search box
        private void tbxParameterSearch_TextChanged(object sender, EventArgs e)
        {
            //create a filter and use the textbox text to filter by
            bs_selectedTemplate.Filter = string.Format("Name LIKE '*{0}*'", tbxParameterSearch.Text);
        }

        //Add to mySet button
        private void btnAddToMySet_Click(object sender, EventArgs e)
        {
            //startMySetGrid();

            foreach (DataGridViewRow row in this.dgvParameters.SelectedRows)
            {

                //get the selected cell location (new way)
                string selectedCell = dgvTemplates.CurrentCell.Value.ToString();

                object[] rowData = new object[row.Cells.Count];

                for (int i = 0; i < rowData.Length; ++i)
                {

                    rowData[i] = row.Cells[i].Value;
                }
                this.dgvMySet.Rows.Add(rowData);

                
            }

            dgvMySet.AllowUserToAddRows = false;
            dgvMySet.Refresh();
        }

        private void btnSaveAsTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            // setup for export
            dgvMySet.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvMySet.SelectAll();
            // hiding row headers to avoid extra \t in exported text
            var rowHeaders = dgvMySet.RowHeadersVisible;
            dgvMySet.RowHeadersVisible = false;

            // ! creating text from grid values
            string content = dgvMySet.GetClipboardContent().GetText();

            // restoring grid state
            dgvMySet.ClearSelection();
            dgvMySet.RowHeadersVisible = rowHeaders;

            System.IO.File.WriteAllText(dialog.FileName, content);
            MessageBox.Show(@"Text file was created.");
        }


    }
    
}



