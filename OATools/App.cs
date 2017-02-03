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
//            //throw new NotImplementedException();
//        }

//        public Result OnStartup(UIControlledApplication application)
//        {
//            ////Get location of this assembly.
//            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

//            // Create a custom ribbon tab
//            String tabName = "This Tab Name";
//            application.CreateRibbonTab(tabName);

//            //// CreateRibbon push buttons.
//            //PushButtonData button1 = new PushButtonData("cmdHelloWorld", "Hello World", thisAssemblyPath, "OATools.App");

//            return Result.Succeeded;


//            //// Create ribbon tab.
//            //String tabName = "OA Tools";
//            //application.CreateRibbonTab(tabName);

//            ////Get location of this assembly.
//            //string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

//            //// CreateRibbon push buttons.
//            //PushButtonData button1 = new PushButtonData("cmdHelloWorld", "Hello World", thisAssemblyPath, "OATools.Main.HelloWorld");

//            ////// Create a ribbon panel.
//            ////List<RibbonItem> projectButtons = new List<RibbonItem>();
//            ////projectButtons.AddRange(m_projectPanel.AddStackedItems(button1));

//            //return Result.Succeeded;

//            ////throw new NotImplementedException();
//        }
//    }
//}