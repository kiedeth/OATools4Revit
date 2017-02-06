using System;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using System.Collections.Generic;

namespace OATools
{
    /// <remarks>
    /// This creates the custom Tab and adds the Ribbon and buttons to it.
    /// </remarks>
    public class clsCreateTab
    {
        // Both OnStartup and OnShutdown must be implemented as public method
        public void CreateTab(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "O'Brien/Atkins";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "O'Brien/Atkins Tools 4 Revit");

            //Get the assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //-----------------------------------------------------------------

            // Create 1st push button to trigger a command add it to the ribbon panel.
            PushButtonData buttonData1 = new PushButtonData("cmdHelloWorld",
               "Say Hello", thisAssemblyPath, "OATools.clsHelloWorld");

            // Create 2nd push button to trigger a command add it to the ribbon panel.
            PushButtonData buttonData2 = new PushButtonData("cmdAllText2Upper",
               "Text To Upper", thisAssemblyPath, "OATools.Commands.cmdAllText2Upper");


            //Adds the button to the ribbon
            PushButton pushButton1 = ribbonPanel.AddItem(buttonData1) as PushButton;
            PushButton pushButton2 = ribbonPanel.AddItem(buttonData2) as PushButton;


            // Button #1
            pushButton1.ToolTip = "Convert all text notes to uppercase text.";
            Uri uriImage1 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-home.ico");
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            pushButton1.LargeImage = largeImage1;


            // Button #2
            pushButton2.ToolTip = "Convert all text notes to uppercase text.";
            Uri uriImage2 = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-text.ico");
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            pushButton2.LargeImage = largeImage2;
        }
    }
}//OATools