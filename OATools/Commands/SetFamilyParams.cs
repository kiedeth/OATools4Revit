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
    class SetFamilyParams : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            SetParameter(doc, uidoc);

            return Result.Succeeded;
        }

        public void SetParameter(Autodesk.Revit.DB.Document doc, UIDocument uidoc)
        {
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_GenericAnnotation);
            FilteredElementCollector collector = new FilteredElementCollector(doc).WherePasses(categoryFilter);
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

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

                    ParameterSet parameters = eFromId.Parameters;
                    foreach (Parameter param in parameters)
                    {
                        
                        if (param.Definition.Name.Contains("Number"))
                        //if (param.GUID.Equals("dcef93ac-112d-4ddd-830f-771951a8f103-0003e2fd") )
                        //if (param.Definition.Name.Equals("DNote Number") && param.AsString() != "")
                        {
                            using (Transaction t = new Transaction(doc, "Set Parameter"))
                            {
                                t.Start();
                                param.Set("3");
                                t.Commit();
                            }
                        }
                    }




                }
                TaskDialog.Show("Test", info);
            }

        }



    }
}

//54faba29-384e-48cd-9a87-8a8df5102217-0003e16b
//dcef93ac-112d-4ddd-830f-771951a8f103-0003e2fd