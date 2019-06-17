using System;
using System.Threading;
using System.Windows.Forms;

namespace OATools2018.CommonTools
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



//=========================================\\
//-----------------Ussage------------------\\
//=========================================\\

//frmProgress progressDialog = new frmProgress();
//private bool showProgress()
//{
//    Thread backgroundThread1 = new Thread(new ThreadStart(() =>
//    {
//        for (int i = 0; i < 100; i++)
//        {
//            Thread.Sleep(50);
//            progressDialog.UpdateProgress(i);
//        }
//        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));

//    }));
//    backgroundThread1.Start();

//    progressDialog.ShowDialog();

//    return true;
//}

//=========================================\\
//-----------------Ussage------------------\\
//=========================================\\