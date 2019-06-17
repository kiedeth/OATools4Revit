#region Header
//
// CmdPartAtom.cs - extract part atom from family file
//
// Copyright (C) 2010-2018 by Jeremy Tammik,
// Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace OATools2018Commands
{
  [Transaction( TransactionMode.Manual )]
  class CmdPartAtom : IExternalCommand
  {
    void createPartAtomFile(
      Application app,
      string rfaFilePath,
      string partAtomFilePath )
    {
      app.ExtractPartAtomFromFamilyFile(
        rfaFilePath,
        partAtomFilePath );
    }

    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Application app = uiapp.Application;
      Document doc = uidoc.Document;

      Transaction tx = new Transaction( doc,
        "Extract Part Atom" );

      tx.Start();

      string familyFilePath
        = "C:/Documents and Settings/All Users"
        + "/Application Data/Autodesk/RAC 2011"
        + "/Metric Library/Doors/M_Double-Flush.rfa";

      string xmlPath = "C:/tmp/ExtractPartAtom.xml";

      app.ExtractPartAtomFromFamilyFile(
        familyFilePath, xmlPath );

      tx.Commit();

      return Result.Succeeded;
    }
  }
}
