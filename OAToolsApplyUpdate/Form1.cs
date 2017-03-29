using OAToolsUpdater;
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

namespace OAToolsApplyUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Focus();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            //clsApplyUpdate.RunApplyUpdate();

            //The temporary path to rename
            //string temporaryPath = Updater.m_oatLocalRibbonDLL + ".temp";

            //The LOCAL vars
            string receivedUpdatesDirectory = Updater.local_receivedUpdates;
            string receivedVersionFile = Updater.local_receivedVersion;
            string localBundleContentsDirectory = Updater.local_bundleContents;
            string ribbonAssembly = Updater.m_oatRibbonAssembly;
            string localRibbonPath = new Uri(ribbonAssembly).LocalPath;

            ////Determine if there is an existing assembly
            //if (File.Exists(Updater.m_oatLocalRibbonDLL))
            //{
            //    //If yes then delete it
            //    File.Delete(Updater.m_oatLocalRibbonDLL);
            //}

            List<String> existingFiles = Directory.GetFiles(localBundleContentsDirectory, "*.*", SearchOption.AllDirectories).ToList();
            List<String> updatedFiles = Directory.GetFiles(receivedUpdatesDirectory, "*.*", SearchOption.AllDirectories).ToList();



            //Check for file lock
            FileInfo fileToCheckForLock = new FileInfo(localRibbonPath);
            while (IsFileLocked(fileToCheckForLock))
            {
                //MessageBox.Show("Please close Revit");

                Thread.Sleep(1000);

            }

            //if (!IsFileLocked(fileToCheckForLock))
            //{

                //Move the temporary files
                if (existingFiles != null)
                {
                    //Check to make sure there are updated files
                    if (updatedFiles != null)
                    {
                        //Delete the existing files in content directory
                        foreach (string file in existingFiles)
                        {
                            File.Delete(file);
                        }

                        //move the updated files to the content directory
                        foreach (string file in updatedFiles)
                        {
                            FileInfo mFile = new FileInfo(file);

                            if (new FileInfo(receivedUpdatesDirectory + "\\" + mFile.Name).Exists == true)
                            {
                                mFile.MoveTo(localBundleContentsDirectory + "\\" + mFile.Name);
                            }
                        }
                    }


                //}


                Thread.Sleep(3000);

                this.Close();
            }

        }


        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }


    }
}
