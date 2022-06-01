#region Header
//
// CmdLibraryPaths.cs - update the application options library paths
//
// Copyright (C) 2009-2018 by Jeremy Tammik,
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
using Autodesk.Revit.UI;
//using Autodesk.Revit.Collections;
#endregion // Namespaces

namespace OATools2018Commands
{
  [Transaction( TransactionMode.ReadOnly )]
  class CmdLibraryPaths : IExternalCommand
  {
    //void PrintMap( StringStringMap map, string description ) // 2011
    void PrintMap( IDictionary<string, string> map, string description ) // 2012
    {
      Debug.Print( "\n{0}:\n", description );

      //StringStringMapIterator it = map.ForwardIterator(); // 2011
      //while( it.MoveNext() ) // 2011
      //{
      //  Debug.Print( "{0} -> {1}", it.Key, it.Current ); // 2011
      //}

      foreach( KeyValuePair<string, string> pair in map ) // 2012
      {
        Debug.Print( "{0} -> {1}", pair.Key, pair.Value ); // 2012
      }
    }

    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      Application app = commandData.Application.Application;

      //StringStringMap map = app.LibraryPaths; // 2011
      IDictionary<string, string> map = app.GetLibraryPaths(); // 2012

      PrintMap( map, "Initial application options library paths" );

      string key = "ImperialTestCreate";
      //string value = @"C:\Documents and Settings\All Users\Application Data\Autodesk\RAC 2010\Imperial Library\Detail Components"; // 2010
      string value = @"C:\ProgramData\Autodesk\RAC 2015\Libraries\Imperial Library\Detail Components"; // 2015

      if( map.ContainsKey( key ) )
      {
        map[key] = value;
      }
      else
      {
        //map.Insert( key, value ); // 2011
        map.Add( key, value ); // 2012
      }

      PrintMap( map, "After adding 'ImperialTestCreate' key" );

      //map.set_Item( key, @"C:\Temp" ); // 2011
      map[key] = @"C:\Temp"; // 2012

      PrintMap( map, "After modifying 'ImperialTestCreate' key" );

      //map.set_Item( "Metric Detail Library", @"C:\Temp" ); // 2011
      map["Metric Detail Library"] = @"C:\Temp"; // 2012

      PrintMap( map, "After modifying 'Metric Detail Library' key" );

      //app.LibraryPaths = map; // 2011
      app.SetLibraryPaths( map ); // 2012

      Debug.Print( "You might want to clean up your "
        + "library paths manually via Revit > Options "
        + "> File Locations > Places... after running "
        + "this command..." );

      return Result.Succeeded;
    }
  }
}