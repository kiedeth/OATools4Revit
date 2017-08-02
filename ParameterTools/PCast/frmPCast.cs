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
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/Additional"; //this gives C:\Users\<userName>\AppData\Roaming\OATools
        static string fileName = "OATools_pCast_mySet_dump";
        static string fileType = "txt";
        static string mySetDumpFile = directory + "/" + fileName + "." + fileType;

        // the active Revit application
        private Autodesk.Revit.UI.UIApplication m_app;

        //Declare the template path var
        static string verifiedPCastTemplate = null;

        //Create the reading class
        static clsReadTemplateFile readingClass = new clsReadTemplateFile();

        //Create the raw template file data table
        public static DataTable dt_rawTemplateFile = new DataTable();

        //Create the template names data table
        public static DataTable dt_templateNames = new DataTable();

        //Create the mySet data table
        public static DataTable dt_mySet = new DataTable();

        //Create the fromFile data table
        public static DataTable dt_fromFile = new DataTable();

        //Create the mySet binding source
        public static BindingSource bs_mySet = new BindingSource();

        //Create the selected template dgv binding source
        public static BindingSource bs_selectedTemplateSet = new BindingSource();

        //----MAIN-----//
        public frmPCast(ExternalCommandData commandData)
        {
            InitializeComponent();

            m_app = commandData.Application;

            //Clear out any misc. data
            PerformReset();

            //Verify the template file and set its path
            verifiedPCastTemplate = clsVerifyPCastTemplate.pCastFilePathFromSettings();

            //Fill the grids
            if (fillTheGrids())
            {
                //set the mySet binding source if the grids fill
                bs_mySet.DataSource = dt_mySet;
            }

        }

        //Reset
        public void PerformReset()
        {
            //perform reset
            dgvTemplates.DataSource = null;
            dgvParameters.DataSource = null;
            dgvMySet.DataSource = null;
            bs_selectedTemplateSet.DataSource = null;
            dt_rawTemplateFile = null;
            dt_templateNames = null;
        }

        //fill the data grids
        private bool fillTheGrids()
        {
            //Reset
            PerformReset();

            //Fill the grids starting w/ the template grid
            if (fillTemplateGrid())
            {
                //if true fill parameter grid
                //if (fillParameterGrid(bs_selectedTemplateSet))

                if (ClsInitDGVs.initDGV(dgvParameters, bs_selectedTemplateSet))
                {
                    //if true clone the column headers to the mySet grid
                    if (cloneParameterGridColumns(dgvMySet))
                    {
                        //Nothing to do here so just refresh the grids for the hell of it
                        dgvTemplates.Refresh();
                        dgvParameters.Refresh();
                        dgvMySet.Refresh();

                        string returnedPath = clsVerifyPCastTemplate.sharedParamFileFromSettings();
                        if (returnedPath != "")
                        {
                            tbxSharedParameterFilePath.Text = returnedPath;
                   
                            fillParamatersFromFileGrid(returnedPath);
                        }
                    }
                }
            }

            //the grids faild to be filled
            return false;
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
            openFileDialog1.Filter = "pCast Templates (*.pct)|*.pct";  //"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 2;
            //Open to last directory
            openFileDialog1.RestoreDirectory = true;
            //Include readOnly files
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            //If the user clicks ok show the path in the textbox
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<PCAST_TEMPLATE_FILE_LOCATION>", openFileDialog1.FileName);
                //Verify the template file and set its path
                verifiedPCastTemplate = clsVerifyPCastTemplate.pCastFilePathFromSettings();
                //Read the template file
                dt_rawTemplateFile = readingClass.GetDataSourceFromFile(openFileDialog1.FileName);
                //Set the template textbox
                tbxTemplateFileLocation.Text = verifiedPCastTemplate;
                //Call the method to reload the file path from settings and put it into the box
                tbxTemplateFileLocation.Text = verifiedPCastTemplate;
                //reload the template list
                if (fillTheGrids())
                {
                    //nothing to do here but the grids are filled
                }
            }//if
        }//btnOpenFile_Click

        private void btnSetParametersFromFilePath_Click(object sender, EventArgs e)
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
                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<PCAST_PARAMETER_FROM_FILE_PATH>", openFileDialog1.FileName);

                fillParamatersFromFileGrid(openFileDialog1.FileName);

                //Set the template textbox
                tbxSharedParameterFilePath.Text = openFileDialog1.FileName;


            }//if
        }

        //Filter the parameters grid by the selected template
        private void dgvTemplates_SelectionChanged(object sender, EventArgs e)
        {
            //get the selected cell value
            string selectedCell = dgvTemplates.CurrentCell.Value.ToString();

            //create a filter and use the selected cell text to filter by
            bs_selectedTemplateSet.Filter = string.Format("TemplateName LIKE '*{0}*'", selectedCell);
        }

        //Fill the template grid
        public bool fillTemplateGrid()
        {
            //Set the template listbox text
            tbxTemplateFileLocation.Text = verifiedPCastTemplate;

            //Remove duplicate rows
            dt_templateNames = readingClass.RemoveDuplicateRows(readingClass.GetDataSourceFromFile(verifiedPCastTemplate), "TemplateName");
            
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

                dgvTemplates.Refresh();

                return true;
            }
            return false;
        }

        private bool fillParameterGrid(BindingSource path)
        {
            //set the selected bs data source to the raw template dt
            path.DataSource = readingClass.GetDataSourceFromFile(verifiedPCastTemplate);

            //Check to verify the template dt is not empty
            if (dt_templateNames.Rows.Count > 0)
            {
                //set the datagridview source
                dgvParameters.DataSource = path;
                
                dgvParameters.AutoGenerateColumns = false;

                dgvParameters.Columns[0].Visible = false;
                dgvParameters.Columns[1].Visible = false;
                dgvParameters.Columns[2].Visible = true;
                dgvParameters.Columns[3].Visible = true;
                dgvParameters.Columns[4].Visible = false;
                dgvParameters.Columns[5].Visible = false;
                dgvParameters.Columns[6].Visible = false;
                dgvParameters.Columns[7].Visible = false;
                dgvParameters.Columns[8].Visible = false;
                dgvParameters.Columns[9].Visible = false;
                dgvParameters.Columns[10].Visible = false;
                dgvParameters.Columns[11].Visible = false;
                dgvParameters.Columns[12].Visible = false;
                dgvParameters.Columns[13].Visible = false;
                dgvParameters.Columns[14].Visible = false;
                dgvParameters.Columns[15].Visible = false;
                dgvParameters.Columns[16].Visible = false;
                dgvParameters.Columns[17].Visible = false;
                dgvParameters.Columns[18].Visible = false;
                dgvParameters.Columns[19].Visible = false;
                dgvParameters.Columns[20].Visible = false;

                return true;
            }

            return false;
        }



        //Clone the parameter grid columns to the myset grid
        private bool cloneParameterGridColumns(DataGridView cloneTo)
        {
            try
            {
                //Clone the columns to the mySet gird
                foreach (DataGridViewColumn c in dgvParameters.Columns)
                {
                    cloneTo.Columns.Add(c.Clone() as DataGridViewColumn);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        //fill the parameters from file grid
        private bool fillParamatersFromFileGrid(string filePath)
        {

            dt_fromFile = clsReadSharedParamFile.ReadSharedParamFile(filePath);

            //dgv.Columns[2].Visible = true;




            dgvParametersFromFile.DataSource = dt_fromFile;

            int colCount = dgvParametersFromFile.ColumnCount;
            for (int i = 0; i < colCount; i++)
            {
                dgvParametersFromFile.Columns[i].Visible = false;
            }
            dgvParametersFromFile.Columns[2].Visible = true;
            dgvParametersFromFile.Columns[3].Visible = true;

            return true;
        }

        //The Parameter Search box
        private void tbxParameterSearch_TextChanged(object sender, EventArgs e)
        {
            //create a filter and use the textbox text to filter by
            bs_selectedTemplateSet.Filter = string.Format("Name LIKE '*{0}*'", tbxParameterSearch.Text);
        }

        //Add to mySet button
        private void btnAddToMySet_Click(object sender, EventArgs e)
        {
            if (tabControl1.Controls[0] == tabControl1.SelectedTab)
            {

                foreach (DataGridViewRow sRow in this.dgvParameters.SelectedRows)
                {
                    //Get the GUID
                    string sGUID = sRow.Cells[1].Value.ToString();

                    //If the mySet is empty
                    if (dgvMySet.Rows.Count == 0)
                    {
                        object[] rowData = new object[sRow.Cells.Count];
                        for (int i = 0; i < rowData.Length; ++i)
                        {
                            rowData[i] = sRow.Cells[i].Value;
                        }
                        this.dgvMySet.Rows.Add(rowData);
                    }

                    //if mySet is not empty
                    if (dgvMySet.Rows.Count != 0)
                    {
                        int counter = 0;
                        int rowCount = dgvMySet.Rows.Count;
                        foreach (DataGridViewRow dRow in dgvMySet.Rows)
                        {
                            string dGUID = dRow.Cells[1].Value.ToString();
                            counter++;
                            if (sGUID == dGUID)
                            {
                                break;
                                //counter++;
                            }
                            if (rowCount == counter)
                            {
                                object[] rowData = new object[sRow.Cells.Count];
                                for (int i = 0; i < rowData.Length; ++i)
                                {
                                    rowData[i] = sRow.Cells[i].Value;
                                }
                                this.dgvMySet.Rows.Add(rowData);
                            }
                        }
                    }
                }

                dgvMySet.AllowUserToAddRows = false;
                dgvMySet.Refresh();
            }

            if (tabControl1.Controls[1] == tabControl1.SelectedTab)
            {

                foreach (DataGridViewRow sRow in this.dgvParametersFromFile.SelectedRows)
                {
                    //Get the GUID
                    string sGUID = sRow.Cells[1].Value.ToString();

                    //If the mySet is empty
                    if (dgvMySet.Rows.Count == 0)
                    {
                        object[] rowData = new object[sRow.Cells.Count];
                        for (int i = 0; i < rowData.Length; ++i)
                        {
                            rowData[i] = sRow.Cells[i].Value;
                        }
                        this.dgvMySet.Rows.Add(rowData);
                    }

                    //if mySet is not empty
                    if (dgvMySet.Rows.Count != 0)
                    {
                        int counter = 0;
                        int rowCount = dgvMySet.Rows.Count;
                        foreach (DataGridViewRow dRow in dgvMySet.Rows)
                        {
                            string dGUID = dRow.Cells[1].Value.ToString();
                            counter++;
                            if (sGUID == dGUID)
                            {
                                break;
                                //counter++;
                            }
                            if (rowCount == counter)
                            {
                                object[] rowData = new object[sRow.Cells.Count];
                                for (int i = 0; i < rowData.Length; ++i)
                                {
                                    rowData[i] = sRow.Cells[i].Value;
                                }
                                this.dgvMySet.Rows.Add(rowData);
                            }
                        }
                    }
                }

                dgvMySet.AllowUserToAddRows = false;
                dgvMySet.Refresh();
            }
        }

        //Create backup file button
        private void btnCreateBackup_Click(object sender, EventArgs e)
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

        //Create a dataTable from dgvMySet
        private DataTable createDataTableFromMySet()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvMySet.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgvMySet.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }

                dt.Rows.Add(dRow);                
            }
            return dt;
        }

        //Save mySet as template button
        private void btnSaveAsTemplate_Click(object sender, EventArgs e)
        {
            //Reset the datagrids
            PerformReset();

            //Template Name dialog
            frmSaveAsTemplate form = new frmSaveAsTemplate(verifiedPCastTemplate, createDataTableFromMySet());
            form.ShowDialog();

            //reload the grids to show the template you just created
            fillTemplateGrid();
            fillParameterGrid(bs_selectedTemplateSet);
        }

        //Clear mySet button
        private void btnClearMySet_Click(object sender, EventArgs e)
        {
            //Clear mySet dgv
            dgvMySet.DataSource = null;
            dgvMySet.Rows.Clear();
            dgvMySet.Refresh();
        }

        //add the parameters to memory to be written to a template
        private bool addParametersToMemory()
        {
            Document doc = m_app.ActiveUIDocument.Document;

            if (null == doc)
            {
                MessageManager.MessageBuff.Append("There's no available document. \n");
                return false;
            }

            if (!doc.IsFamilyDocument)
            {
                MessageManager.MessageBuff.Append("The active document is not a family document. \n");
                return false;
            }

            FamilyParameterAssigner assigner = new FamilyParameterAssigner(m_app.Application, doc);
            // the parameters to be added are defined and recorded in a text file, read them from that file and load to memory
            bool succeeded = assigner.LoadParametersFromFile();
            if (!succeeded)
            {
                return false;
            }

            Transaction t = new Transaction(doc, Guid.NewGuid().GetHashCode().ToString());
            t.Start();
            succeeded = assigner.AddParameters();
            if (succeeded)
            {
                t.Commit();
                return true;
            }
            else
            {
                t.RollBack();
                return false;
            }
        }

        //Build the mySet array to be written to the text file
        private string[,] buildMySetArray()
        {
            int m_rowCount = dgvMySet.RowCount;
            int m_colCount = dgvMySet.ColumnCount;
            string[,] parameterArray;
            parameterArray = new string[m_rowCount, 9];
            for (int row = 0; row < m_rowCount; row++)
            {
                //Type out the string
                parameterArray[row, 0] = "PARAM";

                //GUID
                parameterArray[row, 1] = dgvMySet.Rows[row].Cells[1].Value.ToString();

                //Name
                parameterArray[row, 2] = dgvMySet.Rows[row].Cells[2].Value.ToString();

                //DataType
                parameterArray[row, 3] = dgvMySet.Rows[row].Cells[3].Value.ToString();

                //GroupNumber
                parameterArray[row, 4] = dgvMySet.Rows[row].Cells[4].Value.ToString();

                //GroupName (dont show)
                //parameterArray[row, 5] = dgvMySet.Rows[row].Cells[5].Value.ToString();

                //Visible
                parameterArray[row, 5] = dgvMySet.Rows[row].Cells[6].Value.ToString();

                //InstanceOrType
                parameterArray[row, 6] = "1";

                //GroupUnder (dont show)
                //parameterArray[row, 7] = dgvMySet.Rows[row].Cells[8].Value.ToString();


                parameterArray[row, 8] = "1";

                //parameterArray[row, 10] = dgvMySet.Rows[row].Cells[10].Value.ToString();
                //parameterArray[row, 11] = dgvMySet.Rows[row].Cells[11].Value.ToString();
                //parameterArray[row, 12] = dgvMySet.Rows[row].Cells[12].Value.ToString();
                //parameterArray[row, 13] = dgvMySet.Rows[row].Cells[13].Value.ToString();
                //parameterArray[row, 14] = dgvMySet.Rows[row].Cells[14].Value.ToString();
                //parameterArray[row, 15] = dgvMySet.Rows[row].Cells[15].Value.ToString();
                //parameterArray[row, 16] = dgvMySet.Rows[row].Cells[16].Value.ToString();
                //parameterArray[row, 17] = dgvMySet.Rows[row].Cells[17].Value.ToString();
            }
            //return the array
            return parameterArray;
        }

        //new parameter button
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Show the form
            frmNewSharedParameter f = new frmNewSharedParameter();
            f.ShowDialog();
            //Create the datagridview row to be added
            DataGridViewRow row = (DataGridViewRow)dgvMySet.RowTemplate.Clone();
            row.CreateCells(dgvMySet, "", "", "", "", "", "", "", "");
            //Set the value of the cells
            row.Cells[0].Value = "";
            row.Cells[1].Value = f.newGUID;
            row.Cells[2].Value = f.newParameterName;
            row.Cells[3].Value = f.newDataType;
            row.Cells[4].Value = f.NewGroupID;
            row.Cells[5].Value = "";
            row.Cells[6].Value = "1";
            row.Cells[7].Value = "Instance";
            row.Cells[8].Value = "MECHANICAL";
            row.Cells[9].Value = "";
            row.Cells[10].Value = "";
            //add the row to the grid
            dgvMySet.Rows.Add(row);
        }

        //add mySet parameters to the family button
        private void btnAddToFamily_Click(object sender, EventArgs e)
        {
            //Send the MySetArray to the SP writer
            clsWriteParametersToFile c = new clsWriteParametersToFile();
            c.WriteParametersToFile(mySetDumpFile, buildMySetArray());

            if (addParametersToMemory())
            {
                TaskDialog.Show("pCast", "Parameters have been added to family");
            }
            else
            {
                TaskDialog.Show("pCast", "The operation faild Error Code:2212");
            }
        }

        //delete template button
        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            string templateToDelete = dgvTemplates.SelectedCells[0].Value.ToString();

            if (templateToDelete != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete the " + templateToDelete + " template?", "Delete Template?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    clsReadTemplateFile c = new clsReadTemplateFile();
                    c.DeleteTemplate(verifiedPCastTemplate, templateToDelete);

                    fillTemplateGrid();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }

            else
            {
                TaskDialog.Show("Error", "Please select a template to delete!");
            }






        }
    }
    /// <summary>
    /// store the warning/error messeges when executing the sample
    /// </summary>
    static class MessageManager
    {
        static StringBuilder m_messageBuff = new StringBuilder();
        /// <summary>
        /// store the warning/error messages
        /// </summary>
        public static StringBuilder MessageBuff
        {
            get
            {
                return m_messageBuff;
            }
            set
            {
                m_messageBuff = value;
            }
        }
    }
}




//private string[] createMySetArray()
//{
//    string[] parameterArray;
//    parameterArray = new string[dgvMySet.ColumnCount];

//    for (int i = 0; i < dgvMySet.RowCount; i++)
//    {
//       //parameterArray[i] = dgvMySet.Rows[i].Cells[1].Value.ToString().Trim();

//        for (int i2 = 0; i2 < dgvMySet.Columns.Count; i2++)
//        {
//            parameterArray[i] = dgvMySet.Rows[i].Cells[i2].Value.ToString().Trim();
//        }
//    }           
//    return parameterArray;
//}

//private List<string> listOfMySet()
//{
//    List<string> parameterCells = new List<string>();
//    List<string> parameterRows = new List<string>();


//    foreach (DataGridViewRow row in dgvMySet.Rows)
//    {
//        string cellValue = null;

//        foreach (DataGridViewCell cell in row.Cells)
//        {
//            string cellString = cell.Value.ToString();

//            parameterCells.Add(cellString);


//        }

//        parameterRows.Add(parameterCells.ToString());

//    }
//    return parameterRows;
//}
