
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

        //This assembly
        System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();

        //----------Revit vars----------//

        //The AppData Roaming Directory
        public static readonly string m_appdataRoaming = Environment.ExpandEnvironmentVariables("%appdata%");

        //The current version of Revit
        public static readonly string m_curRevitVersion = "2017/";

        //The Revit Addins directory for the current version of Revit
        public static readonly string m_RevitAddinDir = m_appdataRoaming + "/Autodesk/Revit/Addins/" + m_curRevitVersion;

        //-----------OA Tools Vars-----------//

        //The OA Tools Bundle Directory Name
        public static readonly string m_oatBundleName = "OAToolsForRevit2017.bundle/";

        //The OA Tools Bundle Directory path
        public static readonly string m_oatBundleDir = m_RevitAddinDir + m_oatBundleName;

        //The OA Tools Bundle Contents folder name
        public static readonly string m_oatBundleContentsName = "/Contents/";

        //The OA Tools Bundle Contents Directory path
        public static readonly string m_oatBundleContentsDir = m_oatBundleDir + m_oatBundleContentsName;

        //The OA Tools Version file name
        public static readonly string m_oatVersionFileName = "oatVersion";

        //The OA Tools Update Apply exe file name
        public static readonly string m_oatUpdateApplyExeName = "OAToolsApplyUpdate.exe";

        //The OA Tools LOCAL Version File
        public static readonly string m_oatLocalVersionFile = m_oatBundleContentsDir + m_oatVersionFileName;

        //The OA Tools LOCAL Ribbon DLL
        public static readonly string m_oatLocalRibbonDLL = m_oatBundleContentsDir + "Ribbon.dll";

        //The OA Tools REMOTE Server address
        public static readonly string m_oatRemoteServerAddress = "http://10.10.10.54/oatools/";

        //The OA Tools FTP Server address
        public static readonly string ftp_FTPServerAddress = "10.10.10.54";

        //The OA Tools FTP Server bundle
        public static readonly string ftp_bundle = "/srv/ftp/OAToolsForRevit2017.bundle/Contents/";

        //The OA Tools LOCAL bundle directory
        public static readonly string local_bundle = m_RevitAddinDir + m_oatBundleName;

        //The OA Tools LOCAL bundle contents directory
        public static readonly string local_bundleContents = m_RevitAddinDir + m_oatBundleName + m_oatBundleContentsName;

        //The OA Tools LOCAL apply updates exe
        public static readonly string local_applyUpdatesExe = local_bundle + m_oatUpdateApplyExeName;

        //The OA Tools LOCAL received updates folder
        public static readonly string local_receivedUpdates = m_RevitAddinDir + m_oatBundleName + "ReceivedUpdates/";

        //The OA Tools LOCAL received version file
        public static readonly string local_receivedVersion = local_receivedUpdates + m_oatVersionFileName;

        //The OA Tools LOCAL Ribbon assembly
        public static readonly string m_oatRibbonAssembly = local_bundleContents + "Ribbon.dll";

        //The OA Tools FTP Server bundle
        public static readonly string ftp_versionFile = "/srv/ftp/OAToolsForRevit2017.bundle/Contents/oatVersion";

        //The OA Tools REMOTE bundle contents directory
        public static readonly string m_oatRemoteBundleContentsDir = m_oatRemoteServerAddress + m_oatBundleName + m_oatBundleContentsName;

        //The OA Tools REMOTE Version File
        public static readonly string m_oatRemoteVersionFile = m_oatRemoteBundleContentsDir + m_oatVersionFileName;

        //static string ribbonAssembly = m_oatRibbonAssembly;

        static string localRibbonPath = new Uri(m_oatRibbonAssembly).LocalPath;


        List<String> existingFiles = Directory.GetFiles(local_bundleContents, "*.*", SearchOption.AllDirectories).ToList();
        List<String> updatedFiles = Directory.GetFiles(local_receivedUpdates, "*.*", SearchOption.AllDirectories).ToList();


        public Form1()
        {
            InitializeComponent();

            this.Focus();

            //try to move the files
            moveFiles();
        }

        private void moveFiles()
        {
            //Check for file lock
            FileInfo fileToCheckForLock = new FileInfo(localRibbonPath);
            if (!IsFileLocked(fileToCheckForLock))
            {

                //Move the temporary files
                //Check to make sure there are updated files
                if (updatedFiles != null)
                {

                    //Delete the existing files in content directory
                    foreach (string file in existingFiles)
                    {
                        FileInfo mFile = new FileInfo(file);
                        if (new FileInfo(local_receivedUpdates + "\\" + mFile.Name).Exists == true)
                        {
                            File.Delete(local_bundleContents + "\\" + mFile.Name);
                        }
                    }

                    //move the updated files to the content directory
                    foreach (string file in updatedFiles)
                    {
                        FileInfo mFile = new FileInfo(file);
                        if (new FileInfo(local_receivedUpdates + "\\" + mFile.Name).Exists == true)
                        {
                            mFile.MoveTo(local_bundleContents + "\\" + mFile.Name);
                        }
                    }
                }

                //Close the form
                this.Close();
            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            //retry to move the files
            moveFiles();
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
