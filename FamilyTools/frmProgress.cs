using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace OATools2018.FamilyTools
{
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();

            progressBar1.Value = 0;
        }

        private void frmProgSearchForBackups_Load(object sender, EventArgs e)
        {

        }

        public void UpdateProgress(int progress)
        {
            progressBar1.BeginInvoke(
                new Action(() =>
                {
                    progressBar1.Value = progress;
                }
                ));
        }
    }
}
