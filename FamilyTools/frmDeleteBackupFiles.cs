using OATools2018.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.FamilyTools
{
    public partial class frmDeleteBackupFiles : Form
    {
        string pathToFamily = null;
        string[] getFiles = null;
        string fileCount;

        public frmDeleteBackupFiles()
        {
            InitializeComponent();

            //Check the settings file for a path and set the textbox value to it
            checkSettingsFileForFamilyPath();
            //tbxStartingDirectory.Text = null;

        }


        private string checkSettingsFileForFamilyPath()
        {
            //Read the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedFamilyPath = cls.GetSetting("<FAMILY_TOOLS_DELETE_BACKUPS_FAMILY_PATH>");
            if (returnedFamilyPath != "")
            {
                //Set the value of the var
                pathToFamily = returnedFamilyPath;

                //Set value of textbox
                tbxStartingDirectory.Text = returnedFamilyPath;

                //return the value
                return returnedFamilyPath;
            }
            else
            {
                returnedFamilyPath = @"C:\";

                return returnedFamilyPath;
            }
        }


        private void btnSetPathToFamily_Click(object sender, EventArgs e)
        {
            //Create the dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //Set the initial directory
            openFileDialog1.InitialDirectory = @"C:\";
            //Set the dialog title
            openFileDialog1.Title = "Set path to family";
            //Perform checks
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //Set default extension
            openFileDialog1.DefaultExt = "rfa";
            //Set the file type filter
            openFileDialog1.Filter = "RFA File (*.rfa)|*.rfa";
            openFileDialog1.FilterIndex = 2;
            //Open to last directory
            openFileDialog1.RestoreDirectory = true;
            //Include readOnly files
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            //If the user clicks ok show the path in the textbox
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Write the new path to the settings file
                cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
                cls.UpdateSetting("<FAMILY_TOOLS_DELETE_BACKUPS_FAMILY_PATH>", openFileDialog1.FileName);

                //Reread the settings file and set textbox value and update the value of the var
                checkSettingsFileForFamilyPath();

                //Reset the file count
                tbxNumberOfFilesSelected.Text = null;
                //fileCount = null;

            }//if
        }

        //Change the search option depending of the checkbox
        private SearchOption allDirs()
        {
            if (cbxIncludeSubFolders.Checked)
            {
                return SearchOption.AllDirectories;
            }
            else
            {
                return SearchOption.TopDirectoryOnly;
            }
        }

        private void cbxIncludeSubFolders_CheckedChanged(object sender, EventArgs e)
        {
            //Reset the file count if the checkbox is changed
            tbxNumberOfFilesSelected.Text = null;
            //fileCount = null;
        }


        private bool isProcessRunning = false;
        private void btnSearchForBackups_Click(object sender, EventArgs e)
        {
            if (checkSettingsFileForFamilyPath() == @"C:\")
            {
                MessageBox.Show("Please select a Family to start the search at.");
                return;
            }

            if (isProcessRunning)
            {
                MessageBox.Show("A process is already running.");
                return;
            }

            frmProgress progressDialog = new frmProgress();

            //Get the files
            Thread backgroundThread1 = new Thread(
                new ThreadStart(() =>
                {
                    isProcessRunning = true;
                    //int status = 10;
                    //Count the number of backup files
                    string sourceDir = returnDirectoryPath();
                    getFiles = Directory.GetFiles(sourceDir, "*.0???.rfa", allDirs());
                    //pause for one second
                    Thread.Sleep(100);
                    //get the number of selected files
                    fileCount = getFiles.Length.ToString();
                    for (int n = 0; n < 100; n++)
                    {
                        Thread.Sleep(50);
                        progressDialog.UpdateProgress(n); // Update progress in progressDialog
                    }
                    progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));                   
                    updateFileCount(fileCount);
                    isProcessRunning = false;
                    }
                ));
            backgroundThread1.Start();


            progressDialog.ShowDialog();
        }

        private void updateFileCount(string count)
        {
            tbxNumberOfFilesSelected.BeginInvoke(
                new Action(() =>
                {
                    tbxNumberOfFilesSelected.Text = count;
                }
                ));
        }



        private void countFiles()
        {
            //Count the number of backup files
            string sourceDir = returnDirectoryPath();
            getFiles = Directory.GetFiles(sourceDir, "*.0???.rfa", allDirs());
            tbxNumberOfFilesSelected.Text = getFiles.Length.ToString();
        }

        private string returnDirectoryPath()
        {
            string directoryPath = Path.GetDirectoryName(pathToFamily);

            return directoryPath;
        }

        private void deleteBackupFilesCurrentDir()
        {
            if (tbxNumberOfFilesSelected.Text == null)
            {
                MessageBox.Show("No files selected. Please Scan for files to delete.");

                return;
            }

            //Check to make sure that no more than 100 files will be deleted
            if (getFiles.Length >= 500)
            {
                MessageBox.Show("The number of backup files selected to delete exceeds 500 files; this is not allowed as a safety precaution. Please select another starting point lower in the directory structure.");

                return;
            }

            string sourceDir = returnDirectoryPath();

            using (var form = new frmDeleteBacksConfirm(fileCount))
            {
                //show confirm form
                var result = form.ShowDialog();

                //if the result from confirm form is OK
                if (result == DialogResult.OK)
                {
                    try
                    {
                        string[] getFiles = Directory.GetFiles(sourceDir, "*.0???.rfa", allDirs());

                        foreach (string f in getFiles)
                        {
                            try
                            {
                                File.Delete(f);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void runProgressBar()
        {
            
        }










        //private string returnFileName()
        //{
        //    string rawPath = checkSettingsFileForFamilyPath();
        //    string parsedName;

        //    parsedName = Path.GetFileName(rawPath);

        //    return parsedName;
        //}

        //private string returnFileExtension()
        //{
        //    string extension = Path.GetExtension(returnFileName());

        //    return null;
        //}

        //private string returnFileNameWithoutExtension()
        //{
        //    string name = Path.GetFileNameWithoutExtension(returnFileName());

        //    return name;
        //}







        //private string returnPathToFamily()
        //{
        //    string rawPath = checkSettingsFileForFamilyPath();

        //    return null;
        //}

        //private string parseFileName()
        //{
        //    string fileName = returnFileName();
            
        //    return null;
        //}






        //private string parseFamilyName()
        //{

        //    //string str = "123.1.1.QWE";
        //    //int index = str.LastIndexOf(".");
        //    //string[] seqNum = new string[] { str.Substring(0, index), str.Substring(index + 1) };

        //    string str = "123.1.1.QWE";
        //    string[] seqnum = new string[2];
        //    foreach (char ch in str)
        //    {
        //        if (char.IsNumber(ch) || ch == '.')
        //        {

        //        }
        //        else
        //        {
        //            int indx = str.IndexOf(ch);
        //            seqnum[0] = str.Substring(0, indx).ToString();
        //            seqnum[1] = str.Substring(indx, str.Length - indx).ToString();
        //            break;
        //        }
        //    }

        //    return str;
        //}

        private void tbxParsedFileName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            deleteBackupFilesCurrentDir();
        }

        private void frmDeleteBackupFiles_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbxNumberOfFilesSelected_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
