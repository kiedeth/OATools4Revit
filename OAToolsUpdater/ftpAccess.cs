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
    public class ftp
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

        // FtpGetFiles ussage (source = remote server path, destination = the local path to write into, 
        // tempName = a tempory suffix that is added until the files and confirmed to have downloaded
        public void FtpGetFiles(string source, string destination, string tempName)
        {
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();

                var files = sftp.ListDirectory(source);

                foreach (var file in files)
                {
                    string localFileName = destination + file.Name + tempName;

                    if (!file.Name.StartsWith(".") )
                    {
                        string remoteFileName = file.Name;

                        using (var fileStream = File.OpenWrite(localFileName))
                        {
                            sftp.DownloadFile(source + file.Name, fileStream);
                        }

                        if (tempName != null)
                        {
                            //Get the local file 
                            FileInfo mFile = new FileInfo(localFileName);

                            //Delete the file we are replacing
                            File.Delete(destination + file.Name);

                            //remove the suffix by renaming the file
                            mFile.MoveTo(destination + file.Name);
                        }

                    }                    

                }

                sftp.Disconnect();
            }
        }


        // FtpGetFiles ussage (source = remote server path, destination = the local path to write into, 
        // tempName = a tempory suffix that is added until the files and confirmed to have downloaded
        public void FtpGetFile(string source, string destination)
        {
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();

                using (var fileStream = File.OpenWrite(destination))
                {
                    sftp.DownloadFile(source, fileStream);
                }


                sftp.Disconnect();
            }
        }
    }
}




