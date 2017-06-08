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
using OAToolsUpdater;
using System.Drawing;
using System.Windows;
using OAToolsUpdater;
using OATools.ViewFilters;
using OATools;
using OATools.ParameterTools;
#endregion

namespace Ribbon
{
    public class App : IExternalApplication
    {
        // get the absolute path of this assembly
        string thisAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        private static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        private static string addinsLocation = appData + "/Autodesk/Revit/Addins/2017";
        private static string appUpdater = addinsLocation + "/" + "OAToolsForRevit2017.bundle" + "/" + "AppUpdater.exe";

        private AppDocEvents m_appDocEvents;

        public Result OnShutdown(UIControlledApplication application)
        {
            RemoveAppDocEvents();

            //Check for updates
            //AppUpdater.Program.Main();
            //System.Diagnostics.Process.Start(appUpdater);

            //Apply the updates if any
            //Updater.RunUpdate();
            //AppUpdater.Program.RevitHasClosed();

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





        public static string _namespace_prefix = typeof(App).Namespace + "." + "Resources" + "." + "Icons" + ".";

        public BitmapImage NewBitmapImage(Assembly a, string imageName)
        {

            Stream s = a.GetManifestResourceStream(_namespace_prefix + imageName);

            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.StreamSource = s;
            img.EndInit();

            return img;
        }


        public void CreateTab(UIControlledApplication application)
        {

            OATools.App oatoolsApp = new OATools.App();
            string oaToolsAssembly = oatoolsApp.returnAssembly();

            OATools.ViewFilters.Command viewFiltersApp = new OATools.ViewFilters.Command();
            string viewFiltersAssembly = viewFiltersApp.returnAssembly();

            OATools.ParameterTools.Command parameterToolsApp = new OATools.ParameterTools.Command();
            string parameterToolsAssembly = parameterToolsApp.returnAssembly();

            //OAToolsUpdater.App updaterApp = new OAToolsUpdater.App();
            //string updaterAssembly = updaterApp.returnAssembly();

            //Try to build the ribbon tab and load all resources 
            try
            {
                //return the assembly
                System.Reflection.Assembly exe;
                exe = System.Reflection.Assembly.GetExecutingAssembly();

                //Create a ribbon Tab
                String tabName = "O/A Tools";
                application.CreateRibbonTab(tabName);

                //--------------

                // Add the A ribbon panel
                RibbonPanel ribbonPanelA = application.CreateRibbonPanel(tabName, "Common Tools");

                // Create push button to trigger a command
                PushButtonData A1 = new PushButtonData("Text 2 Upper", "Text 2 Upper", oaToolsAssembly, "OATools.ConvertTextNotes.cmdConvertTextNotes");
                A1.ToolTip = "Load the table family and " + "place table instances";
                A1.Image = NewBitmapImage(exe, "icon-text.ico");

                // Create push button to trigger a command
                PushButtonData A2 = new PushButtonData("Project Parameters", "Project Parameters", viewFiltersAssembly, "BuildingCoder.CmdProjectParameterGuids");
                A2.ToolTip = "Load the table family and " + "place table instances";
                A2.Image = NewBitmapImage(exe, "icon-grid.ico");

                // Create push button to trigger a command
                PushButtonData A3 = new PushButtonData("View Filters2", "View Filters2", viewFiltersAssembly, "OATools.ViewFilters.Command");
                A3.ToolTip = "Load the table family and " + "place table instances";
                A3.Image = NewBitmapImage(exe, "icon-grid.ico");

                // Add the buttons to the panel
                List<RibbonItem> projectButtonsA = new List<RibbonItem>();
                projectButtonsA.AddRange(ribbonPanelA.AddStackedItems(A1, A2, A3));

                //--------------

                //--------------

                // Add the B ribbon panel
                RibbonPanel ribbonPanelB = application.CreateRibbonPanel(tabName, "Parameter Tools");

                // Create push button to trigger a command
                PushButtonData B1 = new PushButtonData("P Cast", "P Cast", parameterToolsAssembly, "OATools.ParameterTools.cmdPCast");
                B1.ToolTip = "Load the table family and " + "place table instances";
                B1.LargeImage = NewBitmapImage(exe, "icon-text.ico");

                //Add the button to ribbon
                PushButton pushButtondB1 = ribbonPanelB.AddItem(B1) as PushButton;




                //// Create push button to trigger a command
                //PushButtonData B1 = new PushButtonData("Project Parameters", "Project Parameters", viewFiltersAssembly, "OATools.ViewFilters.cmdProjectParameters");
                //B1.ToolTip = "Load the table family and " + "place table instances";
                //B1.Image = NewBitmapImage(exe, "icon-text.ico");

                // Create push button to trigger a command
                //PushButtonData B2 = new PushButtonData("SelectedElement", "SelectedElement", viewFiltersAssembly, "OATools.ViewFilters.cmdSelectedElementParameters");
                //B2.ToolTip = "Load the table family and " + "place table instances";
                //B2.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Create push button to trigger a command
                //PushButtonData B3 = new PushButtonData("none3", "none3", viewFiltersAssembly, "OATools.ViewFilters.Command3");
                //B3.ToolTip = "Load the table family and " + "place table instances";
                //B3.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsB = new List<RibbonItem>();
                //projectButtonsA.AddRange(ribbonPanelB.AddStackedItems(B1, B2));

                //--------------
                //--------------

                // Add the C ribbon panel
                RibbonPanel ribbonPanelC = application.CreateRibbonPanel(tabName, "Sheet Tools");

                // Create push button to trigger a command
                PushButtonData C1 = new PushButtonData("Sheets From Views", "Sheets From Views", oaToolsAssembly, "OATools.Sheet_Tools.cmdSheetsFromViews");
                C1.ToolTip = "Load the table family and " + "place table instances";
                C1.Image = NewBitmapImage(exe, "icon-text.ico");

                // Create push button to trigger a command
                PushButtonData C2 = new PushButtonData("SelectedElement", "SelectedElement", oaToolsAssembly, "OATools.Sheet_Tools.cmdCreateSheetsFromViews");
                C2.ToolTip = "Load the table family and " + "place table instances";
                C2.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Create push button to trigger a command
                //PushButtonData B3 = new PushButtonData("none3", "none3", viewFiltersAssembly, "OATools.ViewFilters.Command3");
                //B3.ToolTip = "Load the table family and " + "place table instances";
                //B3.Image = NewBitmapImage(exe, "icon-grid.ico");

                // Add the buttons to the panel
                List<RibbonItem> projectButtonsC = new List<RibbonItem>();
                projectButtonsC.AddRange(ribbonPanelC.AddStackedItems(C1, C2));

                //--------------

                // Add the D ribbon panel
                RibbonPanel ribbonPanelD = application.CreateRibbonPanel(tabName, "DNotes");

                // Create push button to trigger a command
                PushButtonData D1 = new PushButtonData("cmdDNoteLoadPlace", "Create DNote", oaToolsAssembly, "OATools.DNotes.cmdDNoteLoadPlace");
                D1.ToolTip = "Load the DNote family and " + "place DNote instances";
                D1.Image = NewBitmapImage(exe, "dnote_icon.ico");

                //Add the button to ribbon
                //PushButton pushButtonD1 = ribbonPanelD.AddItem(D1) as PushButton;

                // Create push button to trigger a command
                PushButtonData D2 = new PushButtonData("CmdCreateDNoteLegend", "DNote Legend", oaToolsAssembly, "OATools.DNotes.CmdCreateDNoteLegend");
                D2.ToolTip = "Load the DNote family and " + "place DNote instances";
                D2.Image = NewBitmapImage(exe, "dnote_icon.ico");

                //Add the button to ribbon
                //PushButton pushButtonD2 = ribbonPanelD.AddItem(D2) as PushButton;

                // Add the buttons to the panel
                List<RibbonItem> projectButtonsD = new List<RibbonItem>();
                projectButtonsD.AddRange(ribbonPanelD.AddStackedItems(D1, D2));


                //--------------


                //// Add the E ribbon panel
                //RibbonPanel ribbonPanelE = application.CreateRibbonPanel(tabName, "Sheet Tools");

                //// Create push button to trigger a command
                //PushButtonData E1 = new PushButtonData("cmdChangeSheet", "Change Sheet", oaToolsAssembly, "OATools.Sheet_Tools.cmdChangeSheet");
                //E1.ToolTip = "Load the DNote family and " + "place DNote instances";
                //E1.LargeImage = NewBitmapImage(exe, "icon-grid.ico");

                ////Add the button to ribbon
                ////PushButton pushButtonE1 = ribbonPanelE.AddItem(E1) as PushButton;

                //// Create push button to trigger a command
                //PushButtonData E2 = new PushButtonData("cmdChangeTB", "Change TitleBlocks", oaToolsAssembly, "OATools.Sheet_Tools.cmdChangeTB");
                //E2.ToolTip = "Load the DNote family and " + "place DNote instances";
                //E2.LargeImage = NewBitmapImage(exe, "icon-grid.ico");

                ////Add the button to ribbon
                ////PushButton pushButtonE2 = ribbonPanelE.AddItem(E2) as PushButton;

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsE = new List<RibbonItem>();
                //projectButtonsE.AddRange(ribbonPanelE.AddStackedItems(E1, E2));

                //--------------

                //// Add the F ribbon panel
                //RibbonPanel ribbonPanelF = application.CreateRibbonPanel(tabName, "Electrical Tools");

                //// Create push button to trigger a command
                //PushButtonData F1 = new PushButtonData("Emergency Circut", "Emergency Circut", oaToolsAssembly, "OATools.Electrical.cmdEmergencyCircut");
                //F1.ToolTip = "Load the DNote family and " + "place DNote instances";
                //F1.Image = NewBitmapImage(exe, "drafting_icon.ico");
                //// Create push button to trigger a command
                //PushButtonData F2 = new PushButtonData("Unswitched Circut", "Unswitched Circut", oaToolsAssembly, "OATools.Commands.cmdElementOveride");
                //F2.ToolTip = "Load the DNote family and " + "place DNote instances";
                //F2.Image = NewBitmapImage(exe, "drafting_icon.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsF = new List<RibbonItem>();
                //projectButtonsF.AddRange(ribbonPanelF.AddStackedItems(F1, F2));

                //-------------------

                // Add the G ribbon panel
                RibbonPanel ribbonPanelG = application.CreateRibbonPanel(tabName, "Revitize");

                // Create push button to trigger a command
                PushButtonData G1 = new PushButtonData("DWG to Drafting View", "DWG to Drafting View", oaToolsAssembly, "OATools.Revitize.cmdDWG2DrafingView");
                G1.ToolTip = "Load the DNote family and " + "place DNote instances";
                G1.Image = NewBitmapImage(exe, "drafting_icon.ico");

                // Create push button to trigger a command
                PushButtonData G2 = new PushButtonData("Import Details", "Import", oaToolsAssembly, "OATools.Revitize.CmdViewImport");
                G2.ToolTip = "Load the DNote family and " + "place DNote instances";
                G2.Image = NewBitmapImage(exe, "drafting_icon.ico");

                // Add the buttons to the panel
                List<RibbonItem> projectButtonsG = new List<RibbonItem>();
                projectButtonsG.AddRange(ribbonPanelG.AddStackedItems(G1, G2));

                //------------------



                // Add the 5th ribbon panel
                RibbonPanel ribbonPanel4 = application.CreateRibbonPanel(tabName, "Settings");

                // Create push button to trigger a command
                PushButtonData d1 = new PushButtonData("Initilize", "Initilize", oaToolsAssembly, "OATools.Utilities.Initilize");
                d1.ToolTip = "Initialize O/A Tools";
                d1.LargeImage = NewBitmapImage(exe, "icon-initialize.ico");
                //Add the button to ribbon
                PushButton pushButtond1 = ribbonPanel4.AddItem(d1) as PushButton;

                // Create push button to trigger a command
                PushButtonData d2 = new PushButtonData("Check For Updates", "Check for Updates", oaToolsAssembly, "OATools.Settings.cmdCheckForUpdates");
                d2.ToolTip = "Update O/A Tools";
                d2.LargeImage = NewBitmapImage(exe, "icon-initialize.ico");

                //Add the button to ribbon
                PushButton pushButtond2 = ribbonPanel4.AddItem(d2) as PushButton;



            }
            catch
            {
                //show errer if anything fails
                TaskDialog.Show("Error", "Error Building the O/A Tools ribbon or accessing resources123!");
            }
        }
    }
}