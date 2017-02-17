

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

        //static AddInId m_appId = new AddInId(new Guid("F86FDA67-5090-4FF4-A837-088E6B907D5F"));

            

        // get the absolute path of this assembly
        string thisAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        private AppDocEvents m_appDocEvents;


        public Result OnShutdown(UIControlledApplication application)
        {
            RemoveAppDocEvents();
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            CreateTab(application);
            
            AddAppDocEvents(application.ControlledApplication);
            return Result.Succeeded;
        }

        private void AddAppDocEvents(ControlledApplication app)
        {
            m_appDocEvents = new AppDocEvents(app);
            m_appDocEvents.EnableEvents();
        }

        private void RemoveAppDocEvents()
        {
            m_appDocEvents.DisableEvents();
        }

        public void CreateTab(UIControlledApplication application)
        {
            //Create a ribbon Tab
            String tabName = Util.Caption;
            application.CreateRibbonTab(tabName);

            // Add the 1st ribbon panel
            RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Common Tools");

            // Create push button to trigger a command
            PushButtonData a1 = new PushButtonData("Text 2 Upper", "Text 2 Upper", thisAssemblyPath, "OATools.ConvertTextNotes.cmdConvertTextNotes");
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

            // Add the 3rd ribbon panel
            RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(tabName, "Sheet Tools");

            // Create push button to trigger a command
            PushButtonData c1 = new PushButtonData("cmdChangeSheet", "Change Sheet", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeSheet");
            c1.ToolTip = "Load the DNote family and " + "place DNote instances";
            Uri uriImagec1 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-text.ico");
            BitmapImage largeImagec1 = new BitmapImage(uriImageb1);
            c1.LargeImage = largeImagec1;
            //Add the button to ribbon
            PushButton pushButtonc1 = ribbonPanel3.AddItem(c1) as PushButton;

            // Create push button to trigger a command
            PushButtonData c2 = new PushButtonData("cmdChangeTB", "Change TitleBlocks", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeTB");
            c2.ToolTip = "Load the DNote family and " + "place DNote instances";
            Uri uriImagec2 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-text.ico");
            BitmapImage largeImagec2 = new BitmapImage(uriImageb1);
            c2.LargeImage = largeImagec2;
            //Add the button to ribbon
            PushButton pushButtonc2 = ribbonPanel3.AddItem(c2) as PushButton;

        }
    }
}