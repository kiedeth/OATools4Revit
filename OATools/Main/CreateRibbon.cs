//using System;
//using System.Reflection;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using System.Windows.Media.Imaging;
//using System.Collections.Generic;

//namespace OATools
//{
//    public class CreateRibbon : IExternalCommand
//    {
//        //Both OnStartup and OnShutdown must be implemented as public method.
//        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
//        {
//            // Create ribbon tab.
//            String tabName = "OA Tools";
//            application.CreateRibbonTab(tabName);

//            //Get location of this assembly.
//            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

//            // CreateRibbon push buttons.
//            PushButtonData button1 = new PushButtonData("cmdHelloWorld", "Hello World", thisAssemblyPath, "OATools.Main.HelloWorld");

//            //// Create a ribbon panel.
//            //List<RibbonItem> projectButtons = new List<RibbonItem>();
//            //projectButtons.AddRange(m_projectPanel.AddStackedItems(button1));

//            return Result.Succeeded;
//        }

//        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
//        {
//            // Nothing to clean up in this case.
//            return Result.Succeeded;
//        }

//        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
//        {
//            TaskDialog.Show("Revit", "Ribbon Created!");
//            return Autodesk.Revit.UI.Result.Succeeded;
//        }
//    }

//    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//    public class HelloWorld : IExternalCommand
//    {
//        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
//        {
//            TaskDialog.Show("Revit", "Hello World");
//            return Autodesk.Revit.UI.Result.Succeeded;
//        }


//    }
//}