#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools.Utilities;
#endregion // Namespaces

namespace OATools.Functions
{
   
    [Transaction(TransactionMode.ReadOnly)]
    public class funFamilyParamGUID : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;

            var bindingMap = doc.ParameterBindings;
            var it = bindingMap.ForwardIterator();
            it.Reset();

            while (it.MoveNext())
            {
                var definition = (InternalDefinition)it.Key;

                var sharedParameterElement = doc.GetElement(
                  definition.Id) as SharedParameterElement;

                if (sharedParameterElement == null)
                {
                    TaskDialog.Show("non-shared parameter",
                      definition.Name);
                }
                else
                {
                    TaskDialog.Show("shared parameter",
                      $"{sharedParameterElement.GuidValue}"
                        + "- {definition.Name}");
                }
            }
            return Result.Succeeded;
        }
    }
}