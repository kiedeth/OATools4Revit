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

namespace OATools2018.FamilyTools
{
    public partial class frmDeleteBacksConfirm : Form
    {
        public frmDeleteBacksConfirm(string numberOfBackups)
        {
            InitializeComponent();

            lblNumberOfBackups.Text = numberOfBackups;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            bool progress = showProgress();

            this.Close();
        }

        frmProgress progressDialog = new frmProgress();
        private bool showProgress()
        {
            Thread backgroundThread1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    progressDialog.UpdateProgress(i);
                }
                progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));

            }));
            backgroundThread1.Start();

            progressDialog.ShowDialog();

            return true;
        }
    }
}


