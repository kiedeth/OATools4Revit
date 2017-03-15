

#region Namespaces
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
//using Autodesk.Windows; // RibbonTab class
//using RibbonPanel = Autodesk.Windows.RibbonPanel; // ambiguous, exists in Autodesk.Revit as well as Autodesk.Windows
using OATools.Main;
using OATools.Test;
using OATools.Utilities;
using System.Drawing;
#endregion

namespace OATools
{
    public class App : IExternalApplication
    {
        //Set some static vars
        static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        static string directory = appData + "/OATools"; //this gives C:\Users\<userName>\AppData\Roaming\OATools
        static string fileName = "OATools_Settings";
        static string fileType = "ini";
        public static string path = directory + "/" + fileName + "." + fileType;

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
            //Try to build the ribbon tab and load all resources 
            try
            {
                //return the assembly
                System.Reflection.Assembly thisExe;
                thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                //return the class
                clsLoadIcon loadIconCls = new clsLoadIcon();

                //Create a ribbon Tab
                String tabName = Main.Util.Caption;
                application.CreateRibbonTab(tabName);

                // Add the 1st ribbon panel
                RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Common Tools");

                //Set the icon folder path
                //String iconFlderPath = directory + "/" + "Icons";
                String iconFlderPath = directory + "/" + "Resources" + "/" + "Icons";


                // Create push button to trigger a command
                PushButtonData a1 = new PushButtonData("Text 2 Upper", "Text 2 Upper", thisAssemblyPath, "OATools.ConvertTextNotes.cmdConvertTextNotes");
                a1.ToolTip = "Load the table family and " + "place table instances";
                a1.LargeImage = loadIconCls.NewBitmapImage(thisExe, "icon-text.ico");
                //Add the button to ribbon
                PushButton pushButtona1 = ribbonPanel1.AddItem(a1) as PushButton;

                // Add the 2nd ribbon panel
                RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(tabName, "DNotes");

                // Create push button to trigger a command
                PushButtonData b1 = new PushButtonData("cmdDNoteLoadPlace", "Create DNote", thisAssemblyPath, "OATools.DNotes.cmdDNoteLoadPlace");
                b1.ToolTip = "Load the DNote family and " + "place DNote instances";
                b1.LargeImage = loadIconCls.NewBitmapImage(thisExe, "dnote_icon.ico");
                //Add the button to ribbon
                PushButton pushButtonb1 = ribbonPanel2.AddItem(b1) as PushButton;

                // Create push button to trigger a command
                PushButtonData b2 = new PushButtonData("CmdCreateDNoteLegend", "DNote Legend", thisAssemblyPath, "OATools.DNotes.CmdCreateDNoteLegend");
                b2.ToolTip = "Load the DNote family and " + "place DNote instances";
                b2.LargeImage = loadIconCls.NewBitmapImage(thisExe, "dnote_icon.ico");
                //Add the button to ribbon
                PushButton pushButtonb2 = ribbonPanel2.AddItem(b2) as PushButton;

                // Add the 3rd ribbon panel
                RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(tabName, "Sheet Tools");

                // Create push button to trigger a command
                PushButtonData c1 = new PushButtonData("cmdChangeSheet", "Change Sheet", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeSheet");
                c1.ToolTip = "Load the DNote family and " + "place DNote instances";
                c1.LargeImage = loadIconCls.NewBitmapImage(thisExe, "icon-grid.ico");
                //Add the button to ribbon
                PushButton pushButtonc1 = ribbonPanel3.AddItem(c1) as PushButton;

                // Create push button to trigger a command
                PushButtonData c2 = new PushButtonData("cmdChangeTB", "Change TitleBlocks", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeTB");
                c2.ToolTip = "Load the DNote family and " + "place DNote instances";
                c2.LargeImage = loadIconCls.NewBitmapImage(thisExe, "icon-grid.ico");
                //Add the button to ribbon
                PushButton pushButtonc2 = ribbonPanel3.AddItem(c2) as PushButton;

                // Add the 4th ribbon panel
                RibbonPanel ribbonPanel5 = application.CreateRibbonPanel(tabName, "Revitize");

                // Create push button to trigger a command
                PushButtonData e1 = new PushButtonData("DWG to Drafting View", "DWG to Drafting View", thisAssemblyPath, "OATools.Revitize.cmdDWG2DrafingView");
                e1.ToolTip = "Load the DNote family and " + "place DNote instances";
                e1.LargeImage = loadIconCls.NewBitmapImage(thisExe, "drafting_icon.ico");
                //Add the button to ribbon
                PushButton pushButtone1 = ribbonPanel5.AddItem(e1) as PushButton;

                // Add the 5th ribbon panel
                RibbonPanel ribbonPanel4 = application.CreateRibbonPanel(tabName, "Settings");
                // Create push button to trigger a command
                PushButtonData d1 = new PushButtonData("Initilize", "Initilize", thisAssemblyPath, "OATools.Utilities.Initilize");
                d1.ToolTip = "Initialize O/A Tools";
                d1.LargeImage = loadIconCls.NewBitmapImage(thisExe, "icon-initialize.ico");
                //Add the button to ribbon
                PushButton pushButtond1 = ribbonPanel4.AddItem(d1) as PushButton;

            }
            catch
            {
                //show errer if no icon can be loaded
                TaskDialog.Show("Error", "Error accessing resources!");
            }
        }
    }
}


////Create a ribbon Tab
//String tabName = Main.Util.Caption;
//application.CreateRibbonTab(tabName);

//                // Add the 1st ribbon panel
//                RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Common Tools");

////Set the icon folder path
////String iconFlderPath = directory + "/" + "Icons";
//String iconFlderPath = directory + "/" + "Resources" + "/" + "Icons";


//// Create push button to trigger a command
//PushButtonData a1 = new PushButtonData("Text 2 Upper", "Text 2 Upper", thisAssemblyPath, "OATools.ConvertTextNotes.cmdConvertTextNotes");
//a1.ToolTip = "Load the table family and " + "place table instances";
//                Uri uriImagea1 = new Uri(@iconFlderPath + "/" + "icon-text.ico");
//BitmapImage largeImagea1 = new BitmapImage(uriImagea1);
//a1.LargeImage = largeImagea1;
//                //Add the button to ribbon
//                PushButton pushButtona1 = ribbonPanel1.AddItem(a1) as PushButton;

//// Add the 2nd ribbon panel
//RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(tabName, "DNotes");

//// Create push button to trigger a command
//PushButtonData b1 = new PushButtonData("cmdDNoteLoadPlace", "Create DNote", thisAssemblyPath, "OATools.DNotes.cmdDNoteLoadPlace");
//b1.ToolTip = "Load the DNote family and " + "place DNote instances";
//                Uri uriImageb1 = new Uri(@iconFlderPath + "/" + "dnote_icon(1).ico");
//BitmapImage largeImageb1 = new BitmapImage(uriImageb1);
//b1.LargeImage = largeImageb1;
//                //Add the button to ribbon
//                PushButton pushButtonb1 = ribbonPanel2.AddItem(b1) as PushButton;

//// Create push button to trigger a command
//PushButtonData b2 = new PushButtonData("CmdCreateDNoteLegend", "DNote Legend", thisAssemblyPath, "OATools.DNotes.CmdCreateDNoteLegend");
//b2.ToolTip = "Load the DNote family and " + "place DNote instances";
//                Uri uriImageb2 = new Uri(@iconFlderPath + "/" + "dnote_legend_icon.ico");
//BitmapImage largeImageb2 = new BitmapImage(uriImageb2);
//b2.LargeImage = largeImageb2;
//                //Add the button to ribbon
//                PushButton pushButtonb2 = ribbonPanel2.AddItem(b2) as PushButton;

//// Add the 3rd ribbon panel
//RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(tabName, "Sheet Tools");

//// Create push button to trigger a command
//PushButtonData c1 = new PushButtonData("cmdChangeSheet", "Change Sheet", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeSheet");
//c1.ToolTip = "Load the DNote family and " + "place DNote instances";
//                Uri uriImagec1 = new Uri(@iconFlderPath + "/" + "icon-grid.ico");
//BitmapImage largeImagec1 = new BitmapImage(uriImageb1);
//c1.LargeImage = largeImagec1;
//                //Add the button to ribbon
//                PushButton pushButtonc1 = ribbonPanel3.AddItem(c1) as PushButton;

//// Create push button to trigger a command
//PushButtonData c2 = new PushButtonData("cmdChangeTB", "Change TitleBlocks", thisAssemblyPath, "OATools.Sheet_Tools.cmdChangeTB");
//c2.ToolTip = "Load the DNote family and " + "place DNote instances";
//                Uri uriImagec2 = new Uri(@iconFlderPath + "/" + "icon-grid.ico");
//BitmapImage largeImagec2 = new BitmapImage(uriImageb1);
//c2.LargeImage = largeImagec2;
//                //Add the button to ribbon
//                PushButton pushButtonc2 = ribbonPanel3.AddItem(c2) as PushButton;

//// Add the 4th ribbon panel
//RibbonPanel ribbonPanel5 = application.CreateRibbonPanel(tabName, "Revitize");

//// Create push button to trigger a command
//PushButtonData e1 = new PushButtonData("DWG to Drafting View", "DWG to Drafting View", thisAssemblyPath, "OATools.Revitize.cmdDWG2DrafingView");
//e1.ToolTip = "Load the DNote family and " + "place DNote instances";
//                Uri uriImagee1 = new Uri(@iconFlderPath + "/" + "drafting_icon.ico");
//BitmapImage largeImagee1 = new BitmapImage(uriImagee1);
//e1.LargeImage = largeImagee1;
//                //Add the button to ribbon
//                PushButton pushButtone1 = ribbonPanel5.AddItem(e1) as PushButton;

//// Create push button to trigger a command
//PushButtonData d1 = new PushButtonData("Initilize", "Initilize", thisAssemblyPath, "OATools.Utilities.Initilize");
//d1.ToolTip = "Load the DNote family and " + "place DNote instances";
//Uri uriImaged1 = new Uri(@iconFlderPath + "/" + "icon-initialize.ico");
//BitmapImage largeImaged1 = new BitmapImage(uriImaged1);
//d1.LargeImage = largeImaged1;