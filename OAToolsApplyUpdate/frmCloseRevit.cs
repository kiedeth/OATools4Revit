using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018ApplyUpdate
{
    public partial class frmCloseRevit : Form
    {
        public frmCloseRevit()
        {
            InitializeComponent();
         
        }

        private bool canClose()
        {
            clsApply c = new clsApply();

            if (c.moveFiles())
            {               
                return true;
            }

            return false;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            clsApply c = new clsApply();

            if (c.moveFiles())
            {
                this.Close();
            }
        }

        private void frmCloseRevit_Load(object sender, EventArgs e)
        {

        }
    }
}
