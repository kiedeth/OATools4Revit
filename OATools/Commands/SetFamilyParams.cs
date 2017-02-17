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


            FilteredElementCollector collector = new FilteredElementCollector(doc);

            collector.OfCategory(BuiltInCategory.OST_GenericAnnotation);
            collector.OfClass(typeof(FamilySymbol));

            FamilySymbol symbol = collector.FirstElement() as FamilySymbol;





            


            //Perform the transaction
            using (Transaction t = new Transaction(doc, "Show Parameters"))
            {
                t.Start();

                //Do stuff here

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

                        ElementType type = doc.GetElement(id) as ElementType;

                        //GetElementParameterInformation(doc, type);
                    }

                    TaskDialog.Show("Revit", info);
                }







                t.Commit();
            }



            return Result.Succeeded;
        }

        private void setFamilyParams(Document doc)
        {
            FamilyManager manager = doc.FamilyManager;

            // lookup the family parameters
            FamilyParameter number = lookupFamilyParam(manager, "DNote Number");
            //FamilyParameter partNumber = lookupFamilyParam(manager, "Model");

            // set them
            manager.Set(number, "1");
            //manager.SetFormula(manufacturer, "\"VIKING\"");

        }

        private FamilyParameter lookupFamilyParam(FamilyManager fm, string name)
        {
            // lookup the family parameter
            foreach (FamilyParameter fp in fm.Parameters)
            {
                if (fp.Definition.Name.ToUpper() == name.ToUpper()) return fp;
            }

            throw new ApplicationException("Unable to find parameter: " + name);

        }

        void GetElementParameterInformation(Document document, Element element)
        {
            // Format the prompt information string
            String prompt = "Show parameters in selected Element: \n\r";

            StringBuilder st = new StringBuilder();
            // iterate element's parameters
            foreach (Parameter para in element.Parameters)
            {
                st.AppendLine(GetParameterInformation(para, document));
            }

            // Give the user some information
            TaskDialog.Show("Revit", prompt + st.ToString());
        }

        String GetParameterInformation(Parameter para, Document document)
        {
            string defName = para.Definition.Name + "\t : ";
            string defValue = string.Empty;
            // Use different method to get parameter data according to the storage type
            switch (para.StorageType)
            {
                case StorageType.Double:
                    //covert the number into Metric
                    defValue = para.AsValueString();
                    break;
                case StorageType.ElementId:
                    //find out the name of the element
                    Autodesk.Revit.DB.ElementId id = para.AsElementId();
                    if (id.IntegerValue >= 0)
                    {
                        defValue = document.GetElement(id).Name;
                    }
                    else
                    {
                        defValue = id.IntegerValue.ToString();
                    }
                    break;
                case StorageType.Integer:
                    if (ParameterType.YesNo == para.Definition.ParameterType)
                    {
                        if (para.AsInteger() == 0)
                        {
                            defValue = "False";
                        }
                        else
                        {
                            defValue = "True";
                        }
                    }
                    else
                    {
                        defValue = para.AsInteger().ToString();
                    }
                    break;
                case StorageType.String:
                    defValue = para.AsString();
                    break;
                default:
                    defValue = "Unexposed parameter.";
                    break;
            }

            return defName + defValue;
        }


    }


}
