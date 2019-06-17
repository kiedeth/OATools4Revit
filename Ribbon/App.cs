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
using OATools2018.Main;
using OATools2018.Test;
using OATools2018.Utilities;
using OATools2018Updater;
using System.Drawing;
using System.Windows;
using OATools2018Updater;
using OATools2018.ViewFilters;
using OATools2018;
using OATools2018.ParameterTools;
#endregion

namespace Ribbon
{
    public class App : IExternalApplication
    {
        // get the absolute path of this assembly
        string thisAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        private static string appData = Environment.ExpandEnvironmentVariables("%appdata%"); //this gives C:\Users\<userName>\AppData\Roaming
        private static string addinsLocation = appData + "/Autodesk/Revit/Addins/2018";
        private static string appUpdater = addinsLocation + "/" + "OATools2018.bundle" + "/" + "AppUpdater.exe";

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

            OATools2018.App OATools2018App = new OATools2018.App();
            string OATools2018Assembly = OATools2018App.returnAssembly();

            OATools2018.ViewFilters.Command viewFiltersApp = new OATools2018.ViewFilters.Command();
            string viewFiltersAssembly = viewFiltersApp.returnAssembly();

            OATools2018.ParameterTools.Command parameterToolsApp = new OATools2018.ParameterTools.Command();
            string parameterToolsAssembly = parameterToolsApp.returnAssembly();

            OATools2018.FamilyTools.Command familyToolsApp = new OATools2018.FamilyTools.Command();
            string familyToolsAssembly = familyToolsApp.returnAssembly();

            OATools2018.CommonTools.MyProject.cmdMyProject commonToolsApp = new OATools2018.CommonTools.MyProject.cmdMyProject();
            string commonToolsAssembly = commonToolsApp.returnAssembly();




            //OATools2018Updater.App updaterApp = new OATools2018Updater.App();
            //string updaterAssembly = updaterApp.returnAssembly();

            //Try to build the ribbon tab and load all resources 
            try
            {
                //return the assembly
                System.Reflection.Assembly exe;
                exe = System.Reflection.Assembly.GetExecutingAssembly();

                //Create a ribbon Tab
                String tabName = "OA Tools";
                application.CreateRibbonTab(tabName);

                //--------------

                //// Add the A ribbon panel
                //RibbonPanel ribbonPanelA = application.CreateRibbonPanel(tabName, "Common Tools");

                //// Create push button to trigger a command
                //PushButtonData A1 = new PushButtonData("Text to Upper", "Text to Upper", OATools2018Assembly, "OATools2018.ConvertTextNotes.cmdConvertTextNotes");
                //A1.ToolTip = "Load the table family and " + "place table instances";
                //A1.Image = NewBitmapImage(exe, "icon-text.ico");

                //// Create push button to trigger a command
                //PushButtonData A2 = new PushButtonData("Project Parameters", "Project Parameters", viewFiltersAssembly, "BuildingCoder.CmdProjectParameterGuids");
                //A2.ToolTip = "Load the table family and " + "place table instances";
                //A2.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Create push button to trigger a command
                //PushButtonData A3 = new PushButtonData("View Filters2", "View Filters2", viewFiltersAssembly, "OATools2018.ViewFilters.Command");
                //A3.ToolTip = "Load the table family and " + "place table instances";
                //A3.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsA = new List<RibbonItem>();
                //projectButtonsA.AddRange(ribbonPanelA.AddStackedItems(A1, A2, A3));

                //--------------

                //--------------

                //// Add the A ribbon panel
                //RibbonPanel ribbonPanelA = application.CreateRibbonPanel(tabName, "Common Tools");

                //// Create push button to trigger a command
                //PushButtonData A1 = new PushButtonData("Text to Upper", "Text to Upper", OATools2018Assembly, "OATools2018.ConvertTextNotes.cmdConvertTextNotes");
                //A1.ToolTip = "Load the table family and " + "place table instances";
                //A1.LargeImage = NewBitmapImage(exe, "textToUpper.ico");

                //// Create push button to trigger a command
                //PushButtonData A3 = new PushButtonData("View Filters2", "View Filters2", viewFiltersAssembly, "OATools2018.ViewFilters.Command");
                //A3.ToolTip = "Load the table family and " + "place table instances";
                //A3.LargeImage = NewBitmapImage(exe, "icon-grid.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsA = new List<RibbonItem>();
                //projectButtonsA.AddRange(ribbonPanelA.AddStackedItems(A1, A3));

                //--------------

                //--------------

                // Add the B ribbon panel
                RibbonPanel ribbonPanelB = application.CreateRibbonPanel(tabName, "Common Tools");

                // Create push button to trigger a command
                PushButtonData B1 = new PushButtonData("pCaster", "pCaster", parameterToolsAssembly, "OATools2018.ParameterTools.cmdPCast");
                B1.ToolTip = "Create parameter templates and " + "cast them into families.";
                B1.LargeImage = NewBitmapImage(exe, "icon_pCast.ico");

                //Add the button to ribbon
                PushButton pushButtondB1 = ribbonPanelB.AddItem(B1) as PushButton;

                // Create push button to trigger a command
                PushButtonData B2 = new PushButtonData("Text To Upper", "Text To Upper", OATools2018Assembly, "OATools2018.ConvertTextNotes.cmdConvertTextNotes");
                B2.ToolTip = "Convert all Text Notes " + "to uppercase by view or project.";
                B2.LargeImage = NewBitmapImage(exe, "icon_textToUpper.ico");

                //Add the button to ribbon
                PushButton pushButtondB2 = ribbonPanelB.AddItem(B2) as PushButton;


                // Create push button to trigger a command
                PushButtonData B3 = new PushButtonData("DWG Blaster", "DWG Blaster", OATools2018Assembly, "OATools2018.Revitize.cmdDWG2DrafingView");
                B3.ToolTip = "Bath import DWG files " + "and add them to a sheet.";
                B3.LargeImage = NewBitmapImage(exe, "icon_DwgBlaster.ico");

                //Add the button to ribbon
                PushButton pushButtondB3 = ribbonPanelB.AddItem(B3) as PushButton;


                // Create push button to trigger a command
                PushButtonData B4 = new PushButtonData("Sheet Blaster", "Sheet Blaster", OATools2018Assembly, "OATools2018.Sheet_Tools.cmdSheetsFromViews");
                B4.ToolTip = "Creates sheets from views in the project.";
                B4.LargeImage = NewBitmapImage(exe, "icon_sheetBlaster.ico");

                //Add the button to ribbon
                PushButton pushButtondB4 = ribbonPanelB.AddItem(B4) as PushButton;


                // Create push button to trigger a command
                PushButtonData B5 = new PushButtonData("Family Tools", "Family Tools", familyToolsAssembly, "OATools2018.FamilyTools.Command");
                B5.ToolTip = "Creates sheets from views in the project.";
                B5.LargeImage = NewBitmapImage(exe, "icon_familyTools.ico");

                //Add the button to ribbon
                PushButton pushButtondB5 = ribbonPanelB.AddItem(B5) as PushButton;



                // Create push button to trigger a command
                PushButtonData B6 = new PushButtonData("Auto Section Box", "Auto Section Box", commonToolsAssembly, "OATools2018.CommonTools.AutoSectionBox.Command");
                B6.ToolTip = "Creates a 3D view of the selected area.";
                B6.LargeImage = NewBitmapImage(exe, "icon_AutoSectionBox.ico");

                //Add the button to ribbon
                PushButton pushButtondB6 = ribbonPanelB.AddItem(B6) as PushButton;



                // Create push button to trigger a command
                PushButtonData B7 = new PushButtonData("Auto Section View", "Auto Section View", commonToolsAssembly, "OATools2018.CommonTools.AutoSectionView.Command");
                B7.ToolTip = "Creates a section view at the midpoint of the selected element.";
                B7.LargeImage = NewBitmapImage(exe, "icon_AutoSectionView.ico");

                //Add the button to ribbon
                PushButton pushButtondB7 = ribbonPanelB.AddItem(B7) as PushButton;

                // Create push button to trigger a command
                PushButtonData B8 = new PushButtonData("cmdMyProject", "My Project", commonToolsAssembly, "OATools2018.CommonTools.MyProject.cmdMyProject");
                B8.ToolTip = "Project setup and cleanup tools.";
                B8.LargeImage = NewBitmapImage(exe, "icon_myProject.ico");

                //Add the button to ribbon
                PushButton pushButtondB8 = ribbonPanelB.AddItem(B8) as PushButton;

                // Create push button to trigger a command
                PushButtonData B9 = new PushButtonData("cmdGetter", "The Getter", commonToolsAssembly, "OATools2018.CommonTools.Getter.cmdGetter");
                B9.ToolTip = "Project setup and cleanup tools.";
                B9.LargeImage = NewBitmapImage(exe, "icon_getter.ico");

                //Add the button to ribbon
                PushButton pushButtondB9 = ribbonPanelB.AddItem(B9) as PushButton;

                // Create push button to trigger a command
                PushButtonData B10 = new PushButtonData("cmdProjectFolder", "Open Project Folder", commonToolsAssembly, "OATools2018.CommonTools.projectFolder.cmdOpenProjectFolder");
                B10.ToolTip = "Project setup and cleanup tools.";
                B10.LargeImage = NewBitmapImage(exe, "icon_projectFolder.ico");

                //Add the button to ribbon
                PushButton pushButtondB10 = ribbonPanelB.AddItem(B10) as PushButton;

                //---------------------------------------------------------------

                // Add the 5th ribbon panel
                RibbonPanel ribbonPanel4 = application.CreateRibbonPanel(tabName, "Settings");

                // Create push button to trigger a command
                PushButtonData d1 = new PushButtonData("Initilize", "Initilize", OATools2018Assembly, "OATools2018.Utilities.Initilize");
                d1.ToolTip = "Initialize O/A Tools";
                d1.LargeImage = NewBitmapImage(exe, "icon_init.ico");
                //Add the button to ribbon
                PushButton pushButtond1 = ribbonPanel4.AddItem(d1) as PushButton;

                // Create push button to trigger a command
                PushButtonData d2 = new PushButtonData("About", "About", OATools2018Assembly, "OATools2018.Settings.cmdAbout");
                d2.ToolTip = "Check for any updates";
                d2.LargeImage = NewBitmapImage(exe, "icon_about.ico");

                //Add the button to ribbon
                PushButton pushButtond2 = ribbonPanel4.AddItem(d2) as PushButton;

                //---------------------------------------------------------------

                //// Create push button to trigger a command
                //PushButtonData B1 = new PushButtonData("Project Parameters", "Project Parameters", viewFiltersAssembly, "OATools2018.ViewFilters.cmdProjectParameters");
                //B1.ToolTip = "Load the table family and " + "place table instances";
                //B1.Image = NewBitmapImage(exe, "icon-text.ico");

                // Create push button to trigger a command
                //PushButtonData B2 = new PushButtonData("SelectedElement", "SelectedElement", viewFiltersAssembly, "OATools2018.ViewFilters.cmdSelectedElementParameters");
                //B2.ToolTip = "Load the table family and " + "place table instances";
                //B2.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Create push button to trigger a command
                //PushButtonData B3 = new PushButtonData("none3", "none3", viewFiltersAssembly, "OATools2018.ViewFilters.Command3");
                //B3.ToolTip = "Load the table family and " + "place table instances";
                //B3.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsB = new List<RibbonItem>();
                //projectButtonsA.AddRange(ribbonPanelB.AddStackedItems(B1, B2));

                //--------------
                //--------------

                // Add the C ribbon panel
                //RibbonPanel ribbonPanelC = application.CreateRibbonPanel(tabName, "Beta");

                //// Create push button to trigger a command
                //PushButtonData C1 = new PushButtonData("Sheets From Views", "Sheets From Views", OATools2018Assembly, "OATools2018.Sheet_Tools.cmdSheetsFromViews");
                //C1.ToolTip = "Load the table family and " + "place table instances";
                //C1.Image = NewBitmapImage(exe, "icon-text.ico");

                //// Create push button to trigger a command
                //PushButtonData C2 = new PushButtonData("SelectedElement", "SelectedElement", OATools2018Assembly, "OATools2018.Sheet_Tools.cmdCreateSheetsFromViews");
                //C2.ToolTip = "Load the table family and " + "place table instances";
                //C2.Image = NewBitmapImage(exe, "icon-grid.ico");

                ////// Create push button to trigger a command
                ////PushButtonData B3 = new PushButtonData("none3", "none3", viewFiltersAssembly, "OATools2018.ViewFilters.Command3");
                ////B3.ToolTip = "Load the table family and " + "place table instances";
                ////B3.Image = NewBitmapImage(exe, "icon-grid.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsC = new List<RibbonItem>();
                //projectButtonsC.AddRange(ribbonPanelC.AddStackedItems(C1, C2));

                //--------------

                // Add the D ribbon panel
                RibbonPanel ribbonPanelD = application.CreateRibbonPanel(tabName, "Beta");

                // Create push button to trigger a command
                PushButtonData D1 = new PushButtonData("cmdDNoteLoadPlace", "Create DNote", OATools2018Assembly, "OATools2018.DNotes.cmdDNoteLoadPlace");
                D1.ToolTip = "Load the DNote family and " + "place DNote instances";
                D1.Image = NewBitmapImage(exe, "icon_beta.ico");

                //Add the button to ribbon
                //PushButton pushButtonD1 = ribbonPanelD.AddItem(D1) as PushButton;

                // Create push button to trigger a command
                PushButtonData D2 = new PushButtonData("CmdCreateDNoteLegend", "DNote Legend", OATools2018Assembly, "OATools2018.DNotes.CmdCreateDNoteLegend");
                D2.ToolTip = "Load the DNote family and " + "place DNote instances";
                D2.Image = NewBitmapImage(exe, "icon_beta.ico");

                //Add the button to ribbon
                //PushButton pushButtonD2 = ribbonPanelD.AddItem(D2) as PushButton;

                // Add the buttons to the panel
                List<RibbonItem> projectButtonsD = new List<RibbonItem>();
                projectButtonsD.AddRange(ribbonPanelD.AddStackedItems(D1, D2));


                //--------------


                //// Add the E ribbon panel
                //RibbonPanel ribbonPanelE = application.CreateRibbonPanel(tabName, "Sheet Tools");

                //// Create push button to trigger a command
                //PushButtonData E1 = new PushButtonData("cmdChangeSheet", "Change Sheet", OATools2018Assembly, "OATools2018.Sheet_Tools.cmdChangeSheet");
                //E1.ToolTip = "Load the DNote family and " + "place DNote instances";
                //E1.LargeImage = NewBitmapImage(exe, "icon-grid.ico");

                ////Add the button to ribbon
                ////PushButton pushButtonE1 = ribbonPanelE.AddItem(E1) as PushButton;

                //// Create push button to trigger a command
                //PushButtonData E2 = new PushButtonData("cmdChangeTB", "Change TitleBlocks", OATools2018Assembly, "OATools2018.Sheet_Tools.cmdChangeTB");
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
                //PushButtonData F1 = new PushButtonData("Emergency Circut", "Emergency Circut", OATools2018Assembly, "OATools2018.Electrical.cmdEmergencyCircut");
                //F1.ToolTip = "Load the DNote family and " + "place DNote instances";
                //F1.Image = NewBitmapImage(exe, "drafting_icon.ico");
                //// Create push button to trigger a command
                //PushButtonData F2 = new PushButtonData("Unswitched Circut", "Unswitched Circut", OATools2018Assembly, "OATools2018.Commands.cmdElementOveride");
                //F2.ToolTip = "Load the DNote family and " + "place DNote instances";
                //F2.Image = NewBitmapImage(exe, "drafting_icon.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsF = new List<RibbonItem>();
                //projectButtonsF.AddRange(ribbonPanelF.AddStackedItems(F1, F2));

                //-------------------

                //// Add the G ribbon panel
                //RibbonPanel ribbonPanelG = application.CreateRibbonPanel(tabName, "Revitize");

                //// Create push button to trigger a command
                //PushButtonData G1 = new PushButtonData("DWG to Drafting View", "DWG to Drafting View", OATools2018Assembly, "OATools2018.Revitize.cmdDWG2DrafingView");
                //G1.ToolTip = "Load the DNote family and " + "place DNote instances";
                //G1.Image = NewBitmapImage(exe, "drafting_icon.ico");

                //// Create push button to trigger a command
                //PushButtonData G2 = new PushButtonData("Import Details", "Import", OATools2018Assembly, "OATools2018.Revitize.CmdViewImport");
                //G2.ToolTip = "Load the DNote family and " + "place DNote instances";
                //G2.Image = NewBitmapImage(exe, "drafting_icon.ico");

                //// Add the buttons to the panel
                //List<RibbonItem> projectButtonsG = new List<RibbonItem>();
                //projectButtonsG.AddRange(ribbonPanelG.AddStackedItems(G1, G2));

                //------------------







            }
            catch
            {
                //show errer if anything fails
                TaskDialog.Show("Error", "Error Building the O/A Tools ribbon or accessing resources123!");
            }
        }
    }
}