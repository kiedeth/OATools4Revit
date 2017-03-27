using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OAToolsUpdater;
using System.IO;

namespace OAToolsApplyUpdates
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //The temporary path to rename
            string temporaryPath = Updater.m_oatLocalRibbonDLL + ".temp";

            //Determine if there is an existing assembly
            if (File.Exists(Updater.m_oatLocalRibbonDLL))
            {
                //If yes then delete it
                File.Delete(Updater.m_oatLocalRibbonDLL);
            }

            //Rename the temporary file 
            if (File.Exists(temporaryPath) )
            {
                File.Move(temporaryPath, Updater.m_oatLocalRibbonDLL);
            }
            

        }
    }
}
