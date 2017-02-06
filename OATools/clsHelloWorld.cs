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
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class clsHelloWorld : IExternalCommand
    {
        // The main Execute method (inherited from IExternalCommand) must be public
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
            ref string message, ElementSet elements)
        {
            TaskDialog.Show("Revit", "Hello World");

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}


//   /// <remarks>
//   /// The "HelloWorld" external command. The class must be Public.
//   /// </remarks>
//   [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//   public class HelloWorld : IExternalCommand
//   {
//      // The main Execute method (inherited from IExternalCommand) must be public
//      public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
//          ref string message, ElementSet elements)
//      {
//         TaskDialog.Show("Revit", "Hello World");
//         return Autodesk.Revit.UI.Result.Succeeded;
//      }
//   }