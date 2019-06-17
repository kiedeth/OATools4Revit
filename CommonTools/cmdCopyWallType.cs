#region Header
//
// CopyWallType.cs - duplicate a system type from on project to another to partially transfer project standards
//
// Copyright (C) 2011-2018 by Jeremy Tammik, Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
#endregion // Namespaces

namespace OATools2018.CommonTools.CopyWallType
{
  [Transaction( TransactionMode.Manual )]
  class cmdCopyWallType : IExternalCommand
  {
        //call the open file dialog to get the path to the .rvt file
        string _source_project_path = OATools2018.CommonTools.OAT_Utilities.oat_OpenFileDialog("rvt");  
              
        //Source wall type name to copy.
        string _selectedWallTypeName = "NewWallType"; //set this as something just in case no name is passed so it doesnt error

        //list to hold the wall types to pass to the form
        List<String> m_data = new List<String>();

        //var to hold the selected wall from the form
        string _userSelectedWallType;


    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Application app = uiapp.Application;
      Document doc = uidoc.Document;


      // Open source project
      Document docHasFamily = app.OpenDocumentFile(_source_project_path );

      // Find system family to copy, e.g. using a named wall type
      WallType _selectedWallType = null;

      FilteredElementCollector wallTypes
        = new FilteredElementCollector( docHasFamily ) // 2014
        .OfClass( typeof( WallType ) );

      int i = 0;



            foreach (WallType wt in wallTypes)
            {
                //Add the wall type to the list
                m_data.Add(wt.Name);
                
            }

            //show the form and get a value back from it  
            //See this page for example: https://stackoverflow.com/questions/5233502/how-to-return-a-value-from-a-form-in-c
            using (var f = new frmListDialog(m_data))
            {
                var result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _selectedWallTypeName = f.ReturnValue1; //values preserved after close

                    //loop thru and find the wall type the matches the name
                    foreach (WallType wt in wallTypes)
                    {
                        if (wt.Name == _selectedWallTypeName)
                        {
                            //if its a match then...
                            _selectedWallType = wt;
                            //_selectedWallTypeName = wt.Name;
                        }
                    }
                }                
            }





      //foreach( WallType wt in wallTypes )
      //{
      //  string name = wt.Name;

      //  Debug.Print( "  {0} {1}", ++i, name );

      //  if( name.Equals( _selectedWallTypeName ) )
      //  {
      //    _selectedWallType = wt;
      //    break;
      //  }
      //}

      //if( null == _selectedWallType )
      //{
      //  message = string.Format(
      //    "Cannot find source wall type '{0}'"
      //    + " in source document '{1}'. ",
      //    _selectedWallTypeName, _source_project_path );

      //  return Result.Failed;
      //}




      // Create a new wall type in current document

      using( Transaction t = new Transaction( doc ) )
      {
        t.Start( "Transfer Wall Type" );

        WallType newWallType = null;

        wallTypes = new FilteredElementCollector( doc ).OfClass( typeof( WallType ) ); // 2014

        foreach( WallType wt in wallTypes )
        {
          if( wt.Kind == _selectedWallType.Kind )
          {
            newWallType = wt.Duplicate( _selectedWallTypeName ) as WallType;

             TaskDialog.Show("New wall type '{0}' created.", "Wall type " + _selectedWallTypeName + "created.");

            break;
          }
        }

        // Assign parameter values from source wall type:

#if COPY_INDIVIDUAL_PARAMETER_VALUE
    // Example: individually copy the "Function" parameter value:

    BuiltInParameter bip = BuiltInParameter.FUNCTION_PARAM;
    string function = wallType.get_Parameter( bip ).AsString();
    Parameter p = newWallType.get_Parameter( bip );
    p.Set( function );
#endif // COPY_INDIVIDUAL_PARAMETER_VALUE

        Parameter p = null;

        foreach( Parameter p2 in newWallType.Parameters )
        {
          Definition d = p2.Definition;

          if( p2.IsReadOnly )
          {
            Debug.Print( string.Format(
              "Parameter '{0}' is read-only.", d.Name ) );
          }
          else
          {
            p = _selectedWallType.get_Parameter( d );

            if( null == p )
            {
              Debug.Print( string.Format(
                "Parameter '{0}' not found on source wall type.",
                d.Name ) );
            }
            else
            {
              if( p.StorageType == StorageType.ElementId )
              {
                // Here you have to find the corresponding
                // element in the target document.

                Debug.Print( string.Format(
                  "Parameter '{0}' is an element id.",
                  d.Name ) );
              }
              else
              {
                                if (p.StorageType == StorageType.Double)
                                {
                                    p2.Set(p.AsDouble());
                                }
                                else if (p.StorageType == StorageType.String)
                                {
                                    p2.Set(p.AsString());
                                }
                                else if (p.StorageType == StorageType.Integer)
                                {
                                    p2.Set(p.AsInteger());
                                }


                                Debug.Print( string.Format(
                  "Parameter '{0}' copied.", d.Name ) );
              }
            }
          }

          // Note:
          // If a shared parameter parameter is attached,
          // you need to create the shared parameter first,
          // then copy the parameter value.
        }

        // If the system family type has some other properties,
        // you need to copy them as well here. Reflection can
        // be used to determine the available properties.

        MemberInfo[] memberInfos = newWallType.GetType()
          .GetMembers( BindingFlags.GetProperty );

        foreach( MemberInfo m in memberInfos )
        {
          // Copy the writable property values here.
          // As there are no property writable for
          // Walltype, I ignore this process here.
        }
        t.Commit();
      }
      return Result.Succeeded;
    }
  }
}
