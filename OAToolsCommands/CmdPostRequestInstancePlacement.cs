#region Header
//
// CmdPostRequestInstancePlacement.cs - Exercise the PostRequestForElementTypePlacement method
//
// Copyright (C) 2015-2018 by Jeremy Tammik,
// Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace OATools2018Commands
{
  [Transaction( TransactionMode.Manual )]
  class CmdPostRequestInstancePlacement : IExternalCommand
  {
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Document doc = uidoc.Document;

      ElementType elementType
        = new FilteredElementCollector( doc )
          .OfCategory( BuiltInCategory.OST_Walls ) // .OST_Columns
          .OfClass( typeof( ElementType ) )
          .FirstElement() as ElementType;

      uidoc.PostRequestForElementTypePlacement( 
        elementType );

      return Result.Succeeded;
    }
  }
}
