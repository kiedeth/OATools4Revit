//using System;
//using System.Reflection;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using System.Windows.Media.Imaging;
//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.UI.Events;
//using System.Collections.Generic;

//namespace OATools
//{
//    /// <remarks>
//    /// This application's main class. The class must be Public.
//    /// </remarks>
//    public class App : IExternalApplication
//    {
//        public Result OnShutdown(UIControlledApplication application)
//        {
//            return Result.Succeeded;
//        }

//        public Result OnStartup(UIControlledApplication application)
//        {
//            //Creates the Tab
//            clsCreateTab tab = new clsCreateTab();
//            tab.CreateTab(application);

//            //formTest form = new formTest();
//            //form.ShowDialog();

//            return Result.Succeeded;
//        }
//    }
//}

#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;
//using Autodesk.Windows; // RibbonTab class
//using RibbonPanel = Autodesk.Windows.RibbonPanel; // ambiguous, exists in Autodesk.Revit as well as Autodesk.Windows
using OATools.Main;
#endregion

namespace OATools
{
    public class App : IExternalApplication
    {
        //Get the assembly path
        string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

        public void CreateTab(UIControlledApplication application)
        {
            //Create a ribbon Tab
            String tabName = Util.Caption;
            application.CreateRibbonTab(tabName);

            // Add the 1st ribbon panel
            RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Common Tools");

            // Create push button to trigger a command
            PushButtonData a1 = new PushButtonData("cmdConvertTextNotes", "Text To Upper", thisAssemblyPath, "OATools.clsHelloWorld");
            a1.ToolTip = "Load the table family and " + "place table instances";
            Uri uriImagea1 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-text.ico");
            BitmapImage largeImagea1 = new BitmapImage(uriImagea1);
            a1.LargeImage = largeImagea1;
            //Add the button to ribbon
            PushButton pushButtona1 = ribbonPanel1.AddItem(a1) as PushButton;

            // Add the 2nd ribbon panel
            RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(tabName, "DNotes");

            // Create push button to trigger a command
            PushButtonData b1 = new PushButtonData("cmdDNoteLoadPlace", "Create DNote", thisAssemblyPath, "OATools.DNotes.cmdDNoteLoadPlace");
            b1.ToolTip = "Load the DNote family and " + "place DNote instances";
            Uri uriImageb1 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-text.ico");
            BitmapImage largeImageb1 = new BitmapImage(uriImageb1);
            b1.LargeImage = largeImageb1;
            //Add the button to ribbon
            PushButton pushButtonb1 = ribbonPanel2.AddItem(b1) as PushButton;

        }
        

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            CreateTab(application);
            return Result.Succeeded;
        }
    }
}