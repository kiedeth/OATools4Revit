using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OATools.Utilities;

namespace OATools.Revitize
{
    public partial class frmViewImport : Form
    {
        public frmViewImport()
        {
            InitializeComponent();


        }

        void GetFilePathFromSettings()
        {
            //Get the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedFilePath = cls.GetSetting("<IMPORT_VIEW_FILE_PATH>");

            //Read the CSV file
            //ReadCSV(returnedDNoteFilePath);

            //Set the textbox text to the returned path for visual feedback 
            tbxFilePath.Text = returnedFilePath;

        }

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //Create the dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";

            //Set the dialog title
            openFileDialog1.Title = "Browse for DNote CSV File";

            //Perform checks
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            //Set default extension
            openFileDialog1.DefaultExt = "rvt";

            //Set the file type filter
            openFileDialog1.Filter = "Revit Files (*.rvt)|*.rvt";  //"Text files (*.txt)|*.txt|All files (*.*)|*.*"

            openFileDialog1.FilterIndex = 2;

            //Open to last directory
            openFileDialog1.RestoreDirectory = true;

            //Include readOnly files
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            //If the user clicks ok show the path in the textbox
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Test", "OK");

                //Set the text box to the returned path
                tbxFilePath.Text = openFileDialog1.FileName;

                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<IMPORT_VIEW_FILE_PATH>", openFileDialog1.FileName);

                //Call the method to reload the file path from settings and put it into the grid
                GetFilePathFromSettings();
            }//if

        }//btnOpenFile_Click        

        private void tbxFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
