#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using Autodesk.Revit.UI.Selection;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Windows;
using Autodesk.Revit.DB;
using System.Threading;
using System.Linq;
using Autodesk.Revit.UI;
#endregion

namespace OATools2018Updater
{
    //[Transaction(TransactionMode.Manual)]
    //public class Command : IExternalCommand




        //This should be turned back into external command to use as tranaction





    public class Updater
    {
        //This assembly
        System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();

        // It's always nice to ask before downloading
        private static readonly bool shouldPromptForUpgrade = true;

        // This is more or less a constant. But you could change this to read from 
        // a reg key that the user can set from an options menu or something. Options are nice. 
        private static readonly bool disableAutomaticChecking = false;

        //----------Revit vars----------//

        //The AppData Roaming Directory
        public static readonly string m_appdataRoaming = Environment.ExpandEnvironmentVariables("%appdata%");

        //The current version of Revit
        public static readonly string m_curRevitVersion = "2018/";

        //The Revit Addins directory for the current version of Revit
        public static readonly string m_RevitAddinDir = m_appdataRoaming + "/Autodesk/Revit/Addins/" + m_curRevitVersion;

        //-----------OA Tools Vars-----------//

        //The OA Tools Bundle Directory Name
        public static readonly string m_oatBundleName = "OATools2018.bundle/";

        //The OA Tools Bundle Directory path
        public static readonly string m_oatBundleDir = m_RevitAddinDir + m_oatBundleName;

        //The OA Tools Bundle Contents folder name
        public static readonly string m_oatBundleContentsName = "/Contents/";

        //The OA Tools Bundle Contents Directory path
        public static readonly string m_oatBundleContentsDir = m_oatBundleDir + m_oatBundleContentsName;

        //The OA Tools Version file name
        public static readonly string m_oatVersionFileName = "oatVersion";

        //The OA Tools Update Apply exe file name
        public static readonly string m_oatUpdateApplyExeName = "OATools2018ApplyUpdate.exe";

        //The OA Tools LOCAL Version File
        public static readonly string m_oatLocalVersionFile = m_oatBundleContentsDir + m_oatVersionFileName;

        //The OA Tools LOCAL Ribbon DLL
        public static readonly string m_oatLocalRibbonDLL = m_oatBundleContentsDir + "Ribbon.dll";

        //The OA Tools REMOTE Server address
        public static readonly string m_oatRemoteServerAddress = "http://10.10.10.54/OATools2018/";

        //The OA Tools FTP Server address
        public static readonly string ftp_FTPServerAddress = "10.10.10.54";

        //The OA Tools FTP Server bundle
        public static readonly string ftp_bundle = "/srv/ftp/OATools2018.bundle/";

        //The OA Tools FTP Server bundle
        public static readonly string ftp_bundleContents = ftp_bundle + "Contents/";

        //The OA Tools LOCAL bundle directory
        public static readonly string local_bundle = m_RevitAddinDir + m_oatBundleName;

        //The OA Tools LOCAL bundle contents directory
        public static readonly string local_bundleContents = m_RevitAddinDir + m_oatBundleName + m_oatBundleContentsName;

        //The OA Tools LOCAL apply updates exe
        public static readonly string local_additionalDirectory = local_bundle + "Additional/";

        //The OA Tools LOCAL apply updates exe
        public static readonly string local_applyUpdatesExe = local_additionalDirectory + m_oatUpdateApplyExeName;

        //The OA Tools LOCAL received updates folder
        public static readonly string local_receivedUpdates = m_RevitAddinDir + m_oatBundleName + "ReceivedUpdates/";

        //The OA Tools LOCAL received version file
        public static readonly string local_receivedVersion = local_receivedUpdates + m_oatVersionFileName;

        //The OA Tools LOCAL Ribbon assembly
        public static readonly string m_oatRibbonAssembly = local_bundleContents + "Ribbon.dll";

        //The OA Tools FTP Server bundle
        public static readonly string ftp_versionFile = "/srv/ftp/OATools2018.bundle/Contents/oatVersion";

        //The OA Tools REMOTE bundle contents directory
        public static readonly string m_oatRemoteBundleContentsDir = m_oatRemoteServerAddress + m_oatBundleName + m_oatBundleContentsName;

        //The OA Tools REMOTE Version File
        public static readonly string m_oatRemoteVersionFile = m_oatRemoteBundleContentsDir + m_oatVersionFileName;

        // Your version number. A series of numbers separated by periods.
        private static readonly Regex versionNumberRegex = new Regex(@"([0-9]+\.)*[0-9]+");

        public static string localVersionNumber = null;



        //Run update
        public static void RunUpdate(int i)
        {
            if (i == 1)
            {
                getUpdateIfAvailable();
            }
            //Check and see if an update is available and if yes then get it
            if (i == 2)
            {
                bool getUpdate = updateIsRequired();
            }


        }


        //--------Local----------//

        //Get the LOCAL version number
        public static string GetLocalVersionNumber()
        {
            //Check for version info file and a current .dll
            if (File.Exists(m_oatLocalVersionFile) && File.Exists(m_oatLocalRibbonDLL))
            {
                //Read the text file and return it
                return File.ReadAllText(m_oatLocalVersionFile);
            }

            //Notify the user if not found
            //TaskDialog.Show("ERROR 101", "This installation of O/A Tools has missing files. Please re-install O/A Tools to correct the error. <ERROR 101>");

            //Return nothing
            return null;
        }

        //Get the local assembly and load it to memory
        private static Assembly getTheLocalAssembly()
        {
            //Determin if the assembly exists
            if (File.Exists(m_oatLocalRibbonDLL) )
            {
                try
                {
                    //Try to load the assembly
                    return Assembly.LoadFrom(m_oatLocalRibbonDLL);
                }
                catch (Exception) { }
            }
            return null;
        }

        //Update the local version file to the received version number
        private static void updateLocalVersionFile(string version)
        {
            File.WriteAllText(m_oatLocalVersionFile, version);
        }

        //---------Remote---------//

        /// Gets the latest version number from the server.
        public static string GetRemoteVersionNumber()
        {
            //Uri latestVersionUri = new Uri(m_oatRemoteVersionFile);
            //WebClient webClient = new WebClient();

            string receivedData = string.Empty;
            ftp ftpClass = new ftp();

            try
            {
                //In this case the received data is the version number from server
                //receivedData = webClient.DownloadString(m_oatRemoteVersionFile).Trim();

                receivedData = ftpClass.FtpGetVersionFile(ftp_versionFile, m_oatLocalVersionFile);
            }
            catch (WebException)
            {
                // server or connection is having issues
                System.Windows.MessageBox.Show("Error");
            }

            // Just in case the server returned something other than a valid version number. 
            return versionNumberRegex.IsMatch(receivedData)
                ? receivedData
                : null;
        }


        //----------Update happens here---------//

        private static Assembly getUpdateIfAvailable()
        {
            //Set a bool if the the LOCAL assembly exists
            bool localAssemblyExists = File.Exists(m_oatLocalRibbonDLL);

            //Perform checks
            if (disableAutomaticChecking && localAssemblyExists)
            {
                //Return the LOCAL assembly
                return getTheLocalAssembly();
            }

            //Get and set the REMOTE version number
            string remoteVersionNumber = GetRemoteVersionNumber();

            //Make sure you got it
            if (remoteVersionNumber == null)
            {
                //Something went wrong so return the LOCAL assembly

                //Show the user a message telling them that the update failed
                System.Windows.MessageBox.Show("Error Code U102: Could not access the remote server. Update failed");

                return getTheLocalAssembly();
            }

            //Get and set the LOCAL version number
            localVersionNumber = GetLocalVersionNumber();

            //Run the checks to determine if update is required
            if (isUpdateRequired(localVersionNumber, remoteVersionNumber, shouldPromptForUpgrade) )
            {
                bool getTheUpdate = updateIsRequired();
            }

            if (!isUpdateRequired(localVersionNumber, remoteVersionNumber, shouldPromptForUpgrade))
            {               
                TaskDialog.Show("No Update Available", "There is no update available at this time. \n Thank you for your business. \n Come back soon!");
            }
           
            //nothing to return
            return null;
        }

        public static bool updateIsRequired()
        {

            //An update is required so get the REMOTE assembly
            bool success = DownloadRemoteAssembly();

            //update/replace the update apply exe
            bool updateAdditional = updateTheAdditionalDirectory();

            //Thread.Sleep(3000);

            TaskDialog.Show("test", "point reached");

            System.Diagnostics.Process.Start(local_applyUpdatesExe);

            //Success update the local version file
            if (success)
            {
                //update the local version number (this is now done when the files are moved)
                //updateLocalVersionFile(remoteVersionNumber);

                TaskDialog.Show("test", "point reached");

                //launch the Apply Updates exe
                System.Diagnostics.Process.Start(local_applyUpdatesExe);
            }

            return true;
        }


        //Determine if an update is required
        private static bool isUpdateRequired(string localVersion, string remoteVersion, bool shouldAskFirst)
        {
            //Check to see if the LOCAL and REMOTE version numbers are the same
            if (localVersion == remoteVersion)
            {
                //If they are no update is required so return false
                return false;
            }

            if (!shouldAskFirst)
            {
                return true;
            }

            //Get and set the REMOTE version number
            string remoteVersionNumber = GetRemoteVersionNumber();

            //Get and set the LOCAL version number
            string localVersionNumber = GetLocalVersionNumber();

            //Show message box
            return MessageBoxResult.Yes == System.Windows.MessageBox.Show(
                "O/A Tools has an update available. \r\nWould you like to download version:" + remoteVersionNumber, "Version: " + localVersionNumber, 
                MessageBoxButton.YesNo);


        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        //Clears a directory and verifys it
        public static bool ClearTheDirectory(string path)
        {
            if (!IsDirectoryEmpty(path))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }                
            }

            if (IsDirectoryEmpty(path))
            {
                return true;
            }

            return false;
        }

        //Download REMOTE assembly
        public static bool DownloadRemoteAssembly()
        {
            //clear downloads directory
            if (ClearTheDirectory(local_receivedUpdates))
            {               
                //Try to download the files
                try
                {
                    //use FTP downloader
                    ftp c = new ftp();
                    c.FtpGetFiles(ftp_bundleContents, local_receivedUpdates, ".temp");
                }
                catch (Exception)
                {
                    //So much can go wrong so just return false 
                    return false;
                }
            }
            //The update completed, return true
            return true;
        }

        //Replace the update apply exe
        public static bool updateTheAdditionalDirectory()
        {
            //Try to download the files
            try
            {

                    //use FTP downloader
                    ftp c = new ftp();
                    c.FtpGetFiles(ftp_bundle + "Additional/", local_additionalDirectory, ".temp");

            }

            catch (Exception)
            {
                TaskDialog.Show("Error:", "Failed to download the Additional directory. Error Code: 1473");

                //So much can go wrong so just return false 
                return false;
            }
            //The update completed, return true
            return true;
        }

        //Get new settings file
        public static bool GetSettingsFile()
        {
            //Try to download the file
            try
            {
                //use FTP downloader
                ftp c = new ftp();
                c.FtpGetFile(ftp_bundle + "Additional/OATools2018_Settings.ini", local_additionalDirectory + "/OATools2018_Settings.ini");

                return true;
            }
            catch (Exception)
            {
                //So much can go wrong so just return false 
                return false;
            }
        }



        public bool getDNoteFile()
        {
            //Try to download the file
            try
            {
                //use FTP downloader

                ftp c = new ftp();

                c.FtpGetFile(ftp_bundle + "Additional/fsDNote.rfa", local_additionalDirectory + "/fsDNote.rfa");

                return true;
            }
            catch (Exception)
            {
                //So much can go wrong so just return false 
                return false;
            }

        }

    }
}




