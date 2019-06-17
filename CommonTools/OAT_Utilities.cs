using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.CommonTools
{
    public static class OAT_Utilities
    {
        public static string oat_OpenFileDialog(string fileExt)
        {
            //Create the dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";
            //Set the dialog title
            openFileDialog1.Title = "Browse for ." + fileExt + " Files";
            //Perform checks
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //Set default extension
            openFileDialog1.DefaultExt = fileExt;
            //Set the file type filter
            openFileDialog1.Filter = "pCast Templates (*." + fileExt +")|*."+fileExt;  //"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 2;
            //Open to last directory
            openFileDialog1.RestoreDirectory = true;
            //Include readOnly files
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            //If the user clicks ok show the path in the textbox
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }//if

            return null;
        }

    }
}
