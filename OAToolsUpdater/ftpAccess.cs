using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;
using System.Windows;

namespace OAToolsUpdater
{
    class ftp
    {
        String Host = "10.10.10.54";
        int Port = 22;
        String Username = "ftp";
        String Password = "zyynxdnm";
        
        public string FtpGetVersionFile(string source, string destination)
        {            
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                try
                {
                    sftp.Connect();

                    string receivedData = sftp.ReadAllText(source);

                    sftp.Disconnect();

                    return receivedData;
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void FtpUpdateAllFiles(string source, string destination)
        {
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();

                var files = sftp.ListDirectory(source);
                

                foreach (var file in files)
                {
                    string localFileName = destination + file.Name;

                    if (!file.Name.StartsWith(".") )
                    {
                        string remoteFileName = file.Name;

                        using (var fileStream = File.OpenWrite(destination + file.Name))
                        {
                            sftp.DownloadFile(source + file.Name, fileStream);
                        }
                        
                    }
                    
                    //if (file.Name == "OAToolsApplyUpdate.exe")
                    //{
                    //    try
                    //    {
                    //        File.Delete(Updater.local_bundle + "\\" + file.Name);
                    //        file.MoveTo(Updater.local_bundle + "\\" + file.Name);
                    //    }
                    //    catch (Exception)
                    //    {

                    //        return;
                    //    }
                        
                    //}

                }

                sftp.Disconnect();
            }
        }

    }
}


//FileInfo mFile = new FileInfo(file);
//                            if (new FileInfo(receivedUpdatesDirectory + "\\" + mFile.Name).Exists == true)
//                            {
//                                mFile.MoveTo(localBundleContentsDirectory + "\\" + mFile.Name);
//                            }

//public void FtpGetVersionFile(string source, string destination)
//{
//    using (var sftp = new SftpClient(Host, Port, Username, Password))
//    {
//        sftp.Connect();

//        using (var fileStream = File.OpenWrite(destination))
//        {
//            sftp.DownloadFile(source, fileStream);
//        }

//        sftp.Disconnect();
//    }
//}


//private static void DownloadFile(SftpClient client, SftpFile file, string directory)
//{
//    Console.WriteLine("Downloading {0}", file.FullName);
//    using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
//    {
//        client.DownloadFile(file.FullName, fileStream);
//    }
//}








