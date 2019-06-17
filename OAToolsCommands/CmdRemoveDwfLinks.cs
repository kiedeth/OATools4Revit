#region Header
//
// CmdRemoveDwfLinks.cs - Remove DWF links
//
// Copyright (C) 2012-2018 by Jeremy Tammik, Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace OATools2018Commands
{
  [Transaction( TransactionMode.Manual )]
  class CmdRemoveDwfLinks : IExternalCommand
  {
    #region MiroReloadLinks test code
    void MiroReloadLinks( IList<RevitLinkType> fecLinkTypes )
    {
      // Loop all RVT Links

      foreach( RevitLinkType typeLink in fecLinkTypes )
      {
        // ...

        // Skip1 - not IsFromRevitServer

        if( !typeLink.IsFromRevitServer() )
        {
          //�
          continue;
        }

        // Skip2 - not ExternalFileReference
        // 99% it would already skip above as 
        // RevitServer MUST be ExternalFileReference, 
        // but leave just in case...

        ExternalFileReference er = typeLink.GetExternalFileReference();

        if( er == null )
        {
          // ...

          continue;
        }

        // If here, we can cache ModelPath related 
        // info and show to user regardless if we skip 
        // on next checks or not....

        ModelPath mp = er.GetPath();

        string userVisiblePath = ModelPathUtils
          .ConvertModelPathToUserVisiblePath( mp );

        // Skip3 - if ModelPath is NOT Server Path 
        // 99% redundant as we already checked raw 
        // RevitLinkType for this, but keep 
        // just in case...

        if( !mp.ServerPath )
        {
          // ...

          continue;
        }

        // Skip4 - if NOT "NOT Found" problematic one 
        // there is nothing to fix

        if( er.GetLinkedFileStatus()
          != LinkedFileStatus.NotFound )
        {
          // ...

          continue;
        }

        // Skip5 - if Nested Link (can�t (re)load these!)

        if( typeLink.IsNestedLink )
        {
          // ...

          continue;
        }

        // If here, we MUST offer user to "Reload from..."

        // ...

        RevitLinkLoadResult res = null;

        try
        {
          // This fails for problematic Server files 
          // since it also fails on "Reload" button in 
          // UI (due to the GUID issue in the answer)

          //res = typeLink.Reload();

          // This fails same as above :-(!

          //res = typeLink.Load();

          // This WORKS!
          // Basically, this is the equivalent of UI 
          // "Reload from..." + browsing to the *same* 
          // Saved path showing in the manage Links 
          // dialogue.
          // ToDo: Check if we need to do anything 
          // special with WorksetConfiguration? 
          // In tests, it works fine with the 
          // default c-tor.

          ModelPath mpForReload = ModelPathUtils
            .ConvertUserVisiblePathToModelPath(
              userVisiblePath );

          res = typeLink.LoadFrom( mpForReload,
            new WorksetConfiguration() );

          Util.InfoMsg( string.Format(
            "Result = {0}", res.LoadResult ) );
        }
        catch( Exception ex )
        {
          Debug.Print( ex.Message );
        }
      } // foreach typeLink
    }
    #endregion // MiroReloadLinks test code

    /// <summary>
    /// Unpin all of the pinned elements in the list.
    /// </summary>
    int Unpin( List<ElementId> ids, Document doc )
    {
      int count = 0;

      foreach( ElementId id in ids )
      {
        Element e = doc.GetElement( id );
        if( e.Pinned )
        {
          e.Pinned = false;
          ++count;
        }
      }
      return count;
    }

    /// <summary>
    /// Return true if the given element category 
    /// name contains the substring ".dwf".
    /// </summary>
    bool ElementCategoryContainsDwf( Element e )
    {
      return ( null != e.Category )
        && e.Category.Name.ToLower()
          .Contains( ".dwf" );
    }

    /// <summary>
    /// Useless non-functional attempt to remove all
    /// DWF links from the model and return 
    /// the total number of deleted elements.
    /// This does not work! Instead, use 
    /// RemoveDwfLinkUsingExternalFileUtils.
    /// </summary>
    int RemoveDwfLinkUsingDelete( Document doc )
    {
      int nDeleted = 0;

      FilteredElementCollector col
        = new FilteredElementCollector( doc )
          .WhereElementIsNotElementType();

      List<ElementId> ids = new List<ElementId>();

      int pinned = 0;

      foreach( Element e in col )
      {
        if( ElementCategoryContainsDwf( e ) )
        {
          Debug.Print( Util.ElementDescription( e ) );
          pinned += ( e.Pinned ? 1 : 0 );
          ids.Add( e.Id );
        }
      }

      ICollection<ElementId> idsDeleted = null;
      Transaction t;

      int n = ids.Count;
      int unpinned = 0;

      if( 0 < n )
      {
        if( 0 < pinned )
        {
          using( t = new Transaction( doc ) )
          {
            t.Start(
              "Unpin non-ElementType '.dwf' elements" );

            unpinned = Unpin( ids, doc );

            t.Commit();
          }
        }

        using( t = new Transaction( doc ) )
        {
          t.Start(
            "Delete non-ElementType '.dwf' elements" );

          idsDeleted = doc.Delete( ids );

          t.Commit();
        }
      }

      int m = ( null == idsDeleted )
        ? 0
        : idsDeleted.Count;

      Debug.Print( string.Format(
        "Selected {0} non-ElementType element{1}, "
        + "{2} pinned, {3} unpinned, "
        + "{4} successfully deleted.",
        n, Util.PluralSuffix( n ), pinned, unpinned, m ) );

      nDeleted += m;

      col = new FilteredElementCollector( doc )
        .WhereElementIsElementType();

      ids.Clear();
      pinned = 0;

      foreach( Element e in col )
      {
        if( ElementCategoryContainsDwf( e ) )
        {
          Debug.Print( Util.ElementDescription( e ) );
          pinned += ( e.Pinned ? 1 : 0 );
          ids.Add( e.Id );
        }
      }

      n = ids.Count;

      if( 0 < n )
      {
        if( 0 < pinned )
        {
          using( t = new Transaction( doc ) )
          {
            t.Start(
              "Unpin element type '.dwf' elements" );

            unpinned = Unpin( ids, doc );

            t.Commit();
          }
        }

        using( t = new Transaction( doc ) )
        {
          t.Start( "Delete element type '.dwf' elements" );

          idsDeleted = doc.Delete( ids );

          t.Commit();
        }
      }

      m = ( null == idsDeleted ) ? 0 : idsDeleted.Count;

      Debug.Print( string.Format(
        "Selected {0} element type{1}, "
        + "{2} pinned, {3} unpinned, "
        + "{4} successfully deleted.",
        n, Util.PluralSuffix( n ), pinned, unpinned, m ) );

      nDeleted += m;

      return nDeleted;
    }

    /// <summary>
    /// Remove DWF links from model and return 
    /// the total number of deleted elements.
    /// </summary>
    int RemoveDwfLinkUsingExternalFileUtils(
      Document doc )
    {
      List<ElementId> idsToDelete
        = new List<ElementId>();

      ICollection<ElementId> ids = ExternalFileUtils
        .GetAllExternalFileReferences( doc );

      foreach( ElementId id in ids )
      {
        Element e = doc.GetElement( id );

        Debug.Print( Util.ElementDescription( e ) );

        ExternalFileReference xr = ExternalFileUtils
          .GetExternalFileReference( doc, id );

        ExternalFileReferenceType xrType
          = xr.ExternalFileReferenceType;

        if( xrType == ExternalFileReferenceType.DWFMarkup )
        {
          ModelPath xrPath = xr.GetPath();

          string path = ModelPathUtils
            .ConvertModelPathToUserVisiblePath( xrPath );

          if( path.EndsWith( ".dwf" )
            || path.EndsWith( ".dwfx" ) )
          {
            idsToDelete.Add( id );
          }
        }
      }

      int n = idsToDelete.Count;

      ICollection<ElementId> idsDeleted = null;

      if( 0 < n )
      {
        using( Transaction t = new Transaction( doc ) )
        {
          t.Start( "Delete DWFx Links" );

          idsDeleted = doc.Delete( idsToDelete );

          t.Commit();
        }
      }

      int m = ( null == idsDeleted )
        ? 0
        : idsDeleted.Count;

      Debug.Print( string.Format(
        "Selected {0} DWF external file reference{1}, "
        + "{2} element{3} successfully deleted.",
        n, Util.PluralSuffix( n ), m, Util.PluralSuffix( m ) ) );

      return m;
    }

    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Document doc = uidoc.Document;

      if( doc.IsFamilyDocument )
      {
        Util.ErrorMsg(
          "This command requires an active document." );

        return Result.Failed;
      }

      int nDeleted = RemoveDwfLinkUsingDelete( doc );

      int nDeleted2 = RemoveDwfLinkUsingExternalFileUtils( doc );

      return Result.Succeeded;
    }
  }
}
