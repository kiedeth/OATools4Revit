
#region Namespaces
using System;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;
#endregion // Namespaces

namespace OATools2018.CommonTools
{
    public partial class frmListDialog : System.Windows.Forms.Form
    {
        public string ReturnValue1 { get; set; }

        public frmListDialog(List<String> data)
        {
            InitializeComponent();

            listBox1.DataSource = data;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = listBox1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
