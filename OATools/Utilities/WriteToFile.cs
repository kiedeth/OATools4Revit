using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OATools.Utilities
{
    class WriteToFile
    {

        public void AppendLineToDNoteFile(string text2write)
        {
            //Get the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedDNoteFilePath = cls.GetSetting("<DNOTE_FILE_PATH>");

            var filePath = returnedDNoteFilePath;
            // Initialise stream object with file
            using (var wr = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                // Collection of book titles
                var row = new List<string>();


                // insert Username to Excel
                if (text2write != null)
                {
                    row.Add(text2write);
                }
                else
                {
                    
                }

                //row.Add("");

                var sb = new StringBuilder();

                foreach (string value in row)
                {
                    // Add a comma before each string
                    // this adds a comma before the book title
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb = sb.Clear();
                    sb.Append(value);
                    wr.WriteLine(sb.ToString());
                }
            }
        }
    }
}
