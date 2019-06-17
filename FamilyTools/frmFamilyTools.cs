using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.FamilyTools
{
    public partial class frmFamilyTools : Form
    {
        public frmFamilyTools()
        {
            InitializeComponent();
        }

        private void frmFamilyTools_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteBackupFiles_Click(object sender, EventArgs e)
        {
            frmDeleteBackupFiles frm = new frmDeleteBackupFiles();
            frm.ShowDialog();
            this.Close();
        }
    }
}
