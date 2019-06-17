using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.CommonTools
{
    public partial class frmConfirm : Form
    {
        public frmConfirm(string message)
        {
            InitializeComponent();


            //set the message
            lblInfo.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
