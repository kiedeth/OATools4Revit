using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.Settings
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            //Get the local version number and set the textbox text to it
            tbxVersionNumber.Text = OATools2018Updater.Updater.GetLocalVersionNumber();
        }

        private void btn_chech4update_Click(object sender, EventArgs e)
        {
            cmdAbout.GetUpdate(1);
        }

        private void btn_forceUpdate_Click(object sender, EventArgs e)
        {
            cmdAbout.GetUpdate(2);
        }

        public static ResultFromFrmAbout Execute()
        {
            using (var f = new frmAbout())
            {
                var result = new ResultFromFrmAbout();
                result.Result = f.ShowDialog();
                if (result.Result == DialogResult.Retry)
                {
                    // fill other values
                }

                return result;
            }
        }
    }

    public class ResultFromFrmAbout
    {
        public DialogResult Result { get; set; }
        public int UpdateResult { get; set; }
    }
}
