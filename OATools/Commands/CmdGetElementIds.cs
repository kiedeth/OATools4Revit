#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools.Utilities;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
#endregion // Namespaces

namespace OATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class CmdGetElementIds : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
          
            //Perform the transaction
            using (Transaction t = new Transaction(doc, "Show IDs"))
            {
                t.Start();

                GetIDs(doc, uidoc);

                t.Commit();
            }
            return Result.Succeeded;
        }

        private void GetIDs(Document doc, UIDocument uidoc)
        {
            // Get the element selection of current document.
            Selection selection = uidoc.Selection;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            //ICollection<ElementId> selectedElements = uidoc.Selection.Get

            if (0 == selectedIds.Count)
            {
                // If no elements selected.
                TaskDialog.Show("Revit", "You haven't selected any elements.");
            }
            else
            {
                String info = "Ids of selected elements in the document are: ";
                foreach (ElementId id in selectedIds)
                {
                    info += "\n\t" + id.IntegerValue;

                    //Gets the type associated with the ID
                    ElementType type = doc.GetElement(id) as ElementType;

                    //Gets the element associated with the ID
                    Element eFromId = doc.GetElement(id);
                }

                TaskDialog.Show("Revit", info);
            }
        }
    }
}
