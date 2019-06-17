#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools2018.CommonTools.AutoSectionBox;
using System.Windows.Forms;
using OATools2018.CommonTools;
using System.Data;
#endregion // Namespaces



namespace OATools2018.CommonTools.Getter
{
    public partial class frmGetter : System.Windows.Forms.Form
    {
        ExternalCommandData m_commandData;

        public frmGetter(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            InitializeComponent();

            //grab the commandData
            m_commandData = commandData;

            //Init form
            tbxSource.Text = cmdGetter.SourceProject(false, "Name");

            if (tbxSource.Text != "")
            {
                //Load the catList into the dgv
                dgvCategories.DataSource = cmdGetter.createCatDataTable();

                //Set some options
                this.dgvCategories.Columns[0].Visible = false;
            }
        }



        private void btnSetTemplatePath_Click(object sender, EventArgs e)
        {
            //set the source tbx
            tbxSource.Text = cmdGetter.SourceProject(true, "Name");

            //Load the catList into the dgv
            dgvCategories.DataSource = cmdGetter.createCatDataTable();

            //Set some options
            this.dgvCategories.Columns[0].Visible = false;
            DataGridViewColumn col = dgvCategories.Columns[1];
            col.Width = 100;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the index of selected cell
            int rowIndex = dgvCategories.CurrentCell.RowIndex;
            int columnIndex = dgvCategories.CurrentCell.ColumnIndex;

            //get the contents of the selected cell
            string selectedCat = dgvCategories.Rows[rowIndex].Cells[columnIndex].Value.ToString();

            //fill the types datagrid
            cmdGetter cmd = new cmdGetter();
            DataTable dt = cmd.getSelectedCatagory_dataTable(m_commandData);
            dgvTypes.DataSource = dt;
            //Set the column width to fill
            this.dgvCategories.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            cmdGetter cmd = new cmdGetter();
            //Create new dataTable from selected rows
            cmd._getSelectedTypes_dataTable(dgvTypes, dgvCart);


            //dgvCart.DataSource = dgvCart;
            dgvCart.Refresh();
            
        }

        private void btnGetTheTypesInCart_Click(object sender, EventArgs e)
        {
            cmdGetter cmd = new cmdGetter();

            foreach (DataGridViewRow dgvRow in dgvCart.Rows)
            {
                string currentType = dgvRow.Cells[1].Value.ToString();

                bool getCart = cmd.GetTheTypes(m_commandData, currentType);
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
