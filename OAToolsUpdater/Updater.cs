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
#endregion

namespace OAToolsUpdater
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
        public static readonly string m_curRevitVersion = "/2017/";

        //The Revit Addins directory for the current version of Revit
        public static readonly string m_RevitAddinDir = m_appdataRoaming + "/Autodesk/Revit/Addins/" + m_curRevitVersion;

        //-----------OA Tools Vars-----------//

        //The OA Tools Bundle Directory Name
        public static readonly string m_oatBundleName = "/OAToolsForRevit2017.bundle/";

        //The OA Tools Bundle Directory path
        public static readonly string m_oatBundleDir = m_RevitAddinDir + m_oatBundleName;

        //The OA Tools Bundle Contents folder name
        public static readonly string m_oatBundleContentsName = "/Contents/";

        //The OA Tools Bundle Contents Directory path
        public static readonly string m_oatBundleContentsDir = m_oatBundleDir + m_oatBundleContentsName;

        //The OA Tools Version file name
        public static readonly string m_oatVersionFileName = "oatVersion";

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
        public static readonly string local_applyUpdatesExe = local_bundle + "OAToolsApplyUpdate.exe";

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

        // Your version number. A series of numbers separated by periods.
        private static readonly Regex versionNumberRegex = new Regex(@"([0-9]+\.)*[0-9]+");



        //Run update
        public static void RunUpdate()
        {
            //ftp c = new ftp();
            //c.FtpUpdateAllFiles(ftp_bundle, local_bundle);

            //Check and see if an update is available and if yes then get it
            getUpdateIfAvailable();

            //System.Windows.MessageBox.Show("Download Complete! Please restart Revit to apply the update.");


        }




        //-------------SUPPORTING CODE ----------------//

        // The reason a file is used instead of checking the assembly's metadata itself
        // is because checking the metadata requires loading the assembly to check the
        // version. Once the assembly is loaded and it turns out an upgrade is available,
        // you cannot unload the assembly to overwrite the binaries. This is unfortunately
        // a general .NET restriction. 


        //--------Local----------//

        //Get the LOCAL version number
        private static string GetLocalVersionNumber()
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

        //Add refernce to the App;y updates project and fire the .exe from the end of this 


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
                System.Windows.MessageBox.Show("Error Code 102: Update failed");

                return getTheLocalAssembly();
            }

            //Get and set the LOCAL version number
            string localVersionNumber = GetLocalVersionNumber();

            //Run the checks to determine if update is required
            if (isUpdateRequired(localVersionNumber, remoteVersionNumber, shouldPromptForUpgrade) )
            {
                //An update is required so get the REMOTE assembly
                bool success = DownloadRemoteAssembly();

                //Success update the local version file
                if (success)
                {
                    updateLocalVersionFile(remoteVersionNumber);

                    //launch the Apply Updates exe
                    //System.Diagnostics.Process.Start(local_applyUpdatesExe);
                    Process p = new Process();
                    p.StartInfo.FileName = local_applyUpdatesExe;
                    p.Start();
                }
            }

            //nothing to return
            return null;
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

            return MessageBoxResult.Yes == System.Windows.MessageBox.Show(
                "There is a newer version available. Would you like to download it?", "New Version Number here...", 
                MessageBoxButton.YesNo);


        }

        //Download REMOTE assembly
        public static bool DownloadRemoteAssembly()
        {
            //Create the downloader
            //WebClient downloader = new WebClient();

            //Try to download the files
            try
            {
                //use a temporary download path in case something goes wrong, we don't want to 
                //corrupt the program and make it unusable without making the user manually delete files. 
                //string temporaryPath = m_oatLocalRibbonDLL + ".temp";

                //Determine if there are any files to clean up
                //var leftoverFiles = local_receivedUpdates + ".";
                //if (File.Exists(leftoverFiles))
                //{
                //    System.Windows.MessageBox.Show("test");
                //    //If yes then delete the files
                //    File.Delete(leftoverFiles);
                //}

                ftp c = new ftp();
                c.FtpUpdateAllFiles(ftp_bundle, local_receivedUpdates);



                //using (var client = new WebClient() )
                //{
                //    //First delete any temporary file that may already be in the directory
                //    File.Delete(temporaryPath);

                //    //Download the REMOTE assembly to the temporary path
                //    client.DownloadFile(m_oatRemoteAssembly, temporaryPath);
                //}

                ////Determine if there is an existing assembly
                //if (File.Exists(m_oatLocalRibbonDLL) )
                //{
                //    //If yes then delete it

                //    //File.Delete(m_oatLocalRibbonDLL);
                //}

                //Rename the temporary file (this is what need to go in the external .exe)

                //File.Move(temporaryPath, m_oatLocalRibbonDLL);

            }
            catch (Exception)
            {
                //So much can go wrong so just return false 
                return false;
            }

            //The update completed, return true
            return true;

        }


    }
}




