

#region Header
//
// CmdSharedParamGuids.cs - list all shared parameter GUIDs
//
// Copyright (C) 2017 by Alexander Ignatovich and Jeremy Tammik, Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
// Written by Alexander Ignatovich.
//
#endregion // Header

#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace OATools.Utilities
{


    class GetSharedParamGUID
    {
        public void FamilySharedParam(UIDocument uidoc)
        {
            var doc = uidoc.Document;


        }


        public void GetGUID(UIDocument uidoc)
        {
            var doc = uidoc.Document;

            var bindingMap = doc.ParameterBindings;
            var it = bindingMap.ForwardIterator();
            it.Reset();

            while (it.MoveNext())
            {
                var definition = (InternalDefinition)it.Key;

                var sharedParameterElement = doc.GetElement(definition.Id) as SharedParameterElement;

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
            
        }
    }
}
