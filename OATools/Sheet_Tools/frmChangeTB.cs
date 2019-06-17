using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OATools2018.Utilities;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections;

namespace OATools2018.Sheet_Tools
{
    public partial class frmChangeTB : System.Windows.Forms.Form
    {
        private cmdChangeTB cls = new cmdChangeTB();

        public frmChangeTB()
        {
            InitializeComponent();

            


            string[] myList = new string[4];

            myList[0] = "One";
            myList[1] = "Two";
            myList[2] = "Three";
            myList[3] = "Four";

            lbxNewTB.Items.AddRange(myList);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
