#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OATools2018.Utilities;
using Autodesk.Revit.UI.Selection;
#endregion // Namespaces

namespace OATools2018.Electrical
{
    class cmdCreateViewFilter
    {






        public static void CreateViewFilter(Document doc, View view)
        {
            List<ElementId> categories = new List<ElementId>();
            categories.Add(new ElementId(BuiltInCategory.OST_Walls));
            List<FilterRule> filterRules = new List<FilterRule>();

            try
            {
                

                // Create filter element associated to the input categories
                ParameterFilterElement parameterFilterElement = ParameterFilterElement.Create(doc, "Example view filter", categories);

                // Criterion 1 - wall type Function is "Exterior"
                ElementId exteriorParamId = new ElementId(BuiltInParameter.FUNCTION_PARAM);
                filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(exteriorParamId, (int)WallFunction.Exterior));

                // Criterion 2 - wall height > some number
                ElementId lengthId = new ElementId(BuiltInParameter.CURVE_ELEM_LENGTH);
                filterRules.Add(ParameterFilterRuleFactory.CreateGreaterOrEqualRule(lengthId, 28.0, 0.0001));

                // Criterion 3 - custom shared parameter value matches string pattern
                // Get the id for the shared parameter - the ElementId is not hardcoded, so we need to get an instance of this type to find it
                Guid spGuid = new Guid("96b00b61-7f5a-4f36-a828-5cd07890a02a");
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                collector.OfClass(typeof(Wall));
                Wall wall = collector.FirstElement() as Wall;

                if (wall != null)
                {
                    Parameter sharedParam = wall.get_Parameter(spGuid);
                    ElementId sharedParamId = sharedParam.Id;

                    filterRules.Add(ParameterFilterRuleFactory.CreateBeginsWithRule(sharedParamId, "15.", true));
                }

                parameterFilterElement.SetRules(filterRules);

                // Apply filter to view
                view.AddFilter(parameterFilterElement.Id);
                view.SetFilterVisibility(parameterFilterElement.Id, false);
 
            }  
            catch
            {

            }


        }





    }
}
