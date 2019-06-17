using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.Revitize
{
    public partial class frmCreateAddViewsToSheet : System.Windows.Forms.Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="data"></param>
        public frmCreateAddViewsToSheet(ViewsMgr data)
        {
            m_data = data;

            InitializeComponent();
        }

        private void frmCreateAddViewsToSheet_Load(object sender, EventArgs e)
        {
            allViewsTreeView.Nodes.Add(m_data.AllViewsNames);
            allViewsTreeView.TopNode.Expand();

            foreach (string s in m_data.AllTitleBlocksNames)
            {
                titleBlocksListBox.Items.Add(s);
            }
        }

        private void oKButton_Click(object sender, EventArgs e)
        {
            m_data.SelectViews();
            m_data.SheetName = sheetNameTextBox.Text;

            if (1 == titleBlocksListBox.SelectedItems.Count)
            {
                string titleBlock = titleBlocksListBox.SelectedItems[0].ToString();
                m_data.ChooseTitleBlock(titleBlock);
            }
        }

    }
}
