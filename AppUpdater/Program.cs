using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace AppUpdater
{
    public class Program
    {
        // It's always nice to ask before downloading
        private static readonly bool shouldPromptForUpgrade = true;

        // This is more or less a constant. But you could change this to read from 
        // a reg key that the user can set from an options menu or something. Options are nice. 
        private static readonly bool disableAutomaticChecking = false;

        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming

        static string curVersionFilePath = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/";        

        // The name of the local file where the binaries are saved and read from. 
        private static readonly string assemblyFilePath = appData + "/Autodesk/Revit/Addins/2017/OAToolsForRevit2017.bundle/OATools.dll";

        // The name of the class in your binaries that implements ILauncher.
        private static readonly string launcherClassName = "Binaries.Launcher";

        // Your version number. A series of numbers separated by periods.
        private static readonly Regex versionNumberRegex = new Regex(@"([0-9]+\.)*[0-9]+");

        // The URL that returns the version number of the latest release.
        private static readonly string latestVersionNumberUrl = "http://10.10.10.54/oatools/version";


        // The URL of the actual file for the latest version.
        private static readonly string latestVersionAssembly = "http://10.10.10.54/oatools/OATools.dll";

        // The name of the file that will store the latest version. 
        private static readonly string latestVersionInfoFile = curVersionFilePath + "version";


        [STAThread]
        public static void Main()
        {

            Assembly binaries = GetAssembly();



            if (binaries == null)
            {
                MessageBox.Show( "Everything is up to date");
            }
            else
            {

            }
        }

        // The reason a file is used instead of checking the assembly's metadata itself
        // is because checking the metadata requires loading the assembly to check the
        // version. Once the assembly is loaded and it turns out an upgrade is available,
        // you cannot unload the assembly to overwrite the binaries. This is unfortunately
        // a general .NET restriction. 
        private static string GetLocalVersionNumber()
        {
            if (File.Exists(latestVersionInfoFile) && File.Exists(assemblyFilePath))
            {
                return File.ReadAllText(latestVersionInfoFile);
            }

            MessageBox.Show("Cannot load the local version number");

            return null;
        }

        //Write the version number to local file
        private static void SetLocalVersionNumber(string version)
        {
            File.WriteAllText(latestVersionInfoFile, version);
        }

        /// <summary>
        /// Gets the latest version number from the server.
        /// </summary>
        public static string GetLatestVersion()
        {
            Uri latestVersionUri = new Uri(latestVersionNumberUrl);
            WebClient webClient = new WebClient();
            string receivedData = string.Empty;

            try
            {
                //In this case the received data is the version number from server
                receivedData = webClient.DownloadString(latestVersionNumberUrl).Trim();
            }
            catch (WebException)
            {
                // server or connection is having issues
            }

            // Just in case the server returned something other than a valid version number. 
            return versionNumberRegex.IsMatch(receivedData)
                ? receivedData
                : null;
        }

        private static Assembly GetLocalAssembly()
        {
            if (File.Exists(assemblyFilePath))
            {
                try
                {
                    return Assembly.LoadFrom(assemblyFilePath);
                    
                }
                catch (Exception) { }
            }

            return null;
        }

        private static Assembly GetAssembly()
        {
            bool localAssemblyExists = File.Exists(assemblyFilePath);

            if (disableAutomaticChecking && localAssemblyExists)
            {
                return GetLocalAssembly();
            }

            string latestVersion = GetLatestVersion();

            if (latestVersion == null)
            {
                // Something wrong with connection/server.
                // Just go with the local assembly. 

                MessageBox.Show("Cannot connect to /srv/www/oatools to get the latest version number");

                return GetLocalAssembly();
            }

            string localVersion = GetLocalVersionNumber();

            if (ShallIDownloadTheLatestBinaries(localVersion, latestVersion, shouldPromptForUpgrade))
            {
                bool success = DownloadLatestAssembly();
                if (success)
                {
                    SetLocalVersionNumber(latestVersion);
                }
            }

            return GetLocalAssembly();
        }

        private static bool ShallIDownloadTheLatestBinaries(string localVersion, string latestVersion, bool shouldAskFirst)
        {
            if (localVersion == latestVersion)
            {
                return false;
            }

            if (!shouldAskFirst)
            {
                return true;
            }

            return MessageBoxResult.Yes == MessageBox.Show(
                "There is a newer version available. Would you like to download it?",
                "New Version Number here...",
                MessageBoxButton.YesNo);
        }

        private static bool DownloadLatestAssembly()
        {
            WebClient downloader = new WebClient();
            try
            {
                //byte[] latestVersionBytes = downloader.DownloadData(latestVersionAssembly);


                // use a temporary download location in case something goes wrong, we don't want to 
                // corrupt the program and make it unusable without making the user manually delete files. 
                string temporaryPath = assemblyFilePath + ".temp";

                using (var client = new WebClient())
                {
                     client.DownloadFile(latestVersionAssembly, temporaryPath);
                    
                }


                //System.IO.File.WriteAllBytes(temporaryPath, latestVersionBytes);

                if (File.Exists(assemblyFilePath))
                {
                    //int milliseconds = 10000;
                    //Thread.Sleep(milliseconds);

                    File.Delete(assemblyFilePath);

                }

                //while (IsFileLocked(file))
                //    Thread.Sleep(1000);
                //file.Delete();

                File.Move(temporaryPath, assemblyFilePath);
            }
            catch (Exception)
            {
                // so much can go wrong
                return false;
            }
            return true;
        }
    }
}































//        [STAThread]
//        public static void Main() //string[] args
//        {
//            Assembly binaries = GetAssembly();

//            if (binaries == null)
//            {
//                MessageBox.Show(
//                    "First-time download of binaries failed.\n\n" +
//                    "This could either be because the server is down or your\n" +
//                    "internet connection is being silly.",
//                    "FAIL");
//            }
//            else
//            {
//                //MessageBox.Show("Everything up to date");

//                //ILauncher launcher = binaries.CreateInstance(launcherClassName) as ILauncher;
//                //launcher.Launch();
//            }
//        }

//        //Compair version numbers
//        // Get current and updated assemblies
//        public void CompareVersions()
//        {
//            AssemblyName currentAssemblyName = AssemblyName.GetAssemblyName(assemblyFilePath);
//            AssemblyName updatedAssemblyName = AssemblyName.GetAssemblyName(latestVersionDownload);            

//            if (updatedAssemblyName.Version.CompareTo(currentAssemblyName.Version) <= 0)
//            {
//                MessageBox.Show("Nothing to update!");
//                return;
//            }
//        }





//        // The reason a file is used instead of checking the assembly's metadata itself
//        // is because checking the metadata requires loading the assembly to check the
//        // version. Once the assembly is loaded and it turns out an upgrade is available,
//        // you cannot unload the assembly to overwrite the binaries. This is unfortunately
//        // a general .NET restriction. 
//        private static string GetLocalVersionNumber()
//        {

//            if (File.Exists(latestVersionInfoFile) && File.Exists(assemblyFilePath))
//            {
//                return File.ReadAllText(latestVersionInfoFile);
//            }

//            MessageBox.Show("Cannot load the local version number");

//            return null;
//        }

//        //Write the version number to local file
//        private static void SetLocalVersionNumber(string version)
//        {
//            File.WriteAllText(latestVersionInfoFile, version);
//        }

//        /// <summary>
//        /// Gets the latest version number from the server.
//        /// </summary>
//        public static string GetLatestVersion()
//        {
//            Uri latestVersionUri = new Uri(latestVersionUrl);
//            WebClient webClient = new WebClient();
//            string receivedData = string.Empty;

//            try
//            {
//                receivedData = webClient.DownloadString(latestVersionUrl).Trim();
//            }
//            catch (WebException)
//            {
//                // server or connection is having issues
//            }

//            // Just in case the server returned something other than a valid version number. 
//            return versionNumberRegex.IsMatch(receivedData)
//                ? receivedData
//                : null;
//        }

//        private static Assembly GetLocalAssembly()
//        {
//            if (File.Exists(assemblyFilePath))
//            {
//                try
//                {
//                    return Assembly.LoadFrom(assemblyFilePath);
//                }
//                catch (Exception) { }
//            }

//            return null;
//        }

//        private static Assembly GetAssembly()
//        {
//            bool localAssemblyExists = File.Exists(assemblyFilePath);

//            if (disableAutomaticChecking && localAssemblyExists)
//            {
//                return GetLocalAssembly();
//            }

//            string latestVersion = GetLatestVersion();

//            if (latestVersion == null)
//            {
//                // Something wrong with connection/server.
//                // Just go with the local assembly. 

//                MessageBox.Show("Cannot connect to /srv/www/oatools to get the latest version number");

//                return GetLocalAssembly();
//            }

//            string localVersion = GetLocalVersionNumber();

//            if (ShallIDownloadTheLatestBinaries(localVersion, latestVersion, shouldPromptForUpgrade))
//            {
//                bool success = DownloadLatestAssembly();
//                if (success)
//                {
//                    SetLocalVersionNumber(latestVersion);

//                }
//            }

//            return GetLocalAssembly();
//        }

//        private static bool ShallIDownloadTheLatestBinaries(string localVersion, string latestVersion, bool shouldAskFirst)
//        {
//            if (localVersion == latestVersion)
//            {
//                return false;
//            }

//            if (!shouldAskFirst)
//            {
//                return true;
//            }

//            return MessageBoxResult.Yes == MessageBox.Show(
//                "There is a newer version available. Would you like to download it?",
//                "New Version Number here...",
//                MessageBoxButton.YesNo);
//        }

//        private static bool DownloadLatestAssembly()
//        {
//            WebClient downloader = new WebClient();
//            try
//            {
//                byte[] latestVersionBytes = downloader.DownloadData(latestVersionDownload);

//                // use a temporary download location in case something goes wrong, we don't want to 
//                // corrupt the program and make it unusable without making the user manually delete files. 
//                string temporaryPath = "t_" + assemblyFilePath;
//                System.IO.File.WriteAllBytes(temporaryPath, latestVersionBytes);

//                if (File.Exists(assemblyFilePath))
//                {
//                    MessageBox.Show("Deleting file");
//                    File.Delete(assemblyFilePath);
//                }

//                File.Move(temporaryPath, assemblyFilePath);
//            }
//            catch (Exception)
//            {
//                // so much can go wrong
//                return false;
//            }
//            return true;
//        }
//    }
//}