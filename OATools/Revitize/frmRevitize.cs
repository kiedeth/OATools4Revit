using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools.Revitize
{
    public partial class frmRevitize : Form
    {
        public frmRevitize()
        {
            InitializeComponent();

            //Set the drop downs
            this.cmbColors.SelectedIndex = 0;
            this.cmbInsertType.SelectedIndex = 0;
            this.cmbPositioning.SelectedIndex = 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select DWG files to import";
            openFileDialog1.Multiselect = true;

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "DWG Files (*.dwg)|*.dwg";
            openFileDialog1.FilterIndex = 1;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //update listbox with filenames
            foreach (string curFile in openFileDialog1.FileNames)
            {
                //add the filename to the listbox
                lbFilesToImport.Items.Add(curFile);
            }
        }

        public List<string> getSelectedDWGs()
        {
            List<string> DWGList = new List<string>();

            //return list of selected DWGs
            for (int i = 0; i <= lbFilesToImport.Items.Count - 1; i++)
            {
                //add current DWG to the list
                DWGList.Add(lbFilesToImport.Items[i].ToString());
            }
            return DWGList;
        }

        public string getColorSetting()
        {
            return cmbColors.SelectedItem.ToString();
        }

        public string getPosSetting()
        {
            return cmbPositioning.SelectedItem.ToString();
        }

        public string getInsertType()
        {
            return cmbInsertType.SelectedItem.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
