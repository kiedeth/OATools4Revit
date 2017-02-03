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
    /// This application's main class. The class must be Public.
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

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
               "Say Hello", thisAssemblyPath, "OATools.HelloWorld");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Say hello to the entire world.";

            // b) large bitmap
            Uri uriImage = new Uri(@"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\Icons\icon-grid.ico");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

        }

    }

}//OATools