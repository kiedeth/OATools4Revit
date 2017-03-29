using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OAToolsUpdater;
using System.IO;

namespace OAToolsApplyUpdates
{
    class clsApplyUpdate
    {
        public static void RunApplyUpdate()
        {

            ////The temporary path to rename
            ////string temporaryPath = Updater.m_oatLocalRibbonDLL + ".temp";

            ////The LOCAL vars
            //string receivedUpdatesDirectory = Updater.local_receivedUpdates;
            //string receivedVersionFile = Updater.local_receivedVersion;
            //string localBundleContentsDirectory = Updater.local_bundleContents;

            //////Determine if there is an existing assembly
            ////if (File.Exists(Updater.m_oatLocalRibbonDLL))
            ////{
            ////    //If yes then delete it
            ////    File.Delete(Updater.m_oatLocalRibbonDLL);
            ////}

            //List<String> existingFiles = Directory.GetFiles(localBundleContentsDirectory, "*.*", SearchOption.AllDirectories).ToList();
            //List<String> updatedFiles = Directory.GetFiles(receivedUpdatesDirectory, "*.*", SearchOption.AllDirectories).ToList();


            ////Rename the temporary file 
            //if (existingFiles != null)
            //{
            //    //Check to make sure there are updated files
            //    if (updatedFiles != null)
            //    {
            //        //Delete the existing files in content directory
            //        foreach (string file in existingFiles)
            //        {
            //            File.Delete(file);
            //        }

            //        //move the updated files to the content directory
            //        foreach (string file in updatedFiles)
            //        {
            //            FileInfo mFile = new FileInfo(file);

            //            if (new FileInfo(receivedUpdatesDirectory + "\\" + mFile.Name).Exists == true)
            //            {
            //                mFile.MoveTo(localBundleContentsDirectory + "\\" + mFile.Name);
            //            }
            //        }
            //    }


            //}

        }
    }
}
