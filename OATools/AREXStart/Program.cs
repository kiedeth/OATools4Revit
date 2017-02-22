using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.REX.Framework;

namespace REX.Start
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

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);


            RunExtension(@"C:\Users\jschaad\Documents\visual studio 2015\Projects\OATools\OATools\bin\Debug\OATools.dll", "2017");
        }

        static System.Reflection.Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Autodesk.REX.Framework.REXAssemblies.Resolve(sender, args, "2017", System.Reflection.Assembly.GetExecutingAssembly());
        }

        static void RunExtension(string FullPath, string VersionName)
        {
            REXApplicationInstance applicationInstance = new REXApplicationInstance();
            if (applicationInstance.LoadExtension(FullPath, "REX.StartupProject.Application"))
            {
                REXContext context = new REXContext();

                context.Control.Mode = REXMode.Dialog;
                context.Control.ControlMode = REXControlMode.ModalDialog;
                context.Product.Type = REXInterfaceType.Common;
                context.Control.Parent = null;

                REXEnvironment environment = new REXEnvironment(VersionName);
                if (environment.LoadEngine(ref context))
                {
                    if (applicationInstance.Extension.Create(ref context))
                        applicationInstance.Extension.Show();
                }
            }
        }
    }
}