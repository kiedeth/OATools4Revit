#region Header
//
// CmdDimensionInstanceOrigin.cs - create dimensioning between the origins of family instances
//
// Copyright (C) 2014-2018 by Jeremy Tammik,
// Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion // Namespaces

namespace OATools2018Commands
{
  #region Scott Wilson Reference Stable Representation Magic Voodoo
  class ScottWilsonVoodooMagic
  {
    void f()
    {
      Document dbDoc = null;
      Reference myReference = null;
      string refString = myReference
        .ConvertToStableRepresentation( dbDoc );

      string[] refTokens = refString.Split(
        new char[] { ':' } );
    }

    public static Edge GetInstanceEdgeFromSymbolRef(
      Reference symbolRef,
      Document dbDoc )
    {
      Edge instEdge = null;

      Options gOptions = new Options();
      gOptions.ComputeReferences = true;
      gOptions.DetailLevel = ViewDetailLevel.Undefined;
      gOptions.IncludeNonVisibleObjects = false;

      Element elem = dbDoc.GetElement( symbolRef.ElementId );

      string stableRefSymbol = symbolRef
        .ConvertToStableRepresentation( dbDoc );

      string[] tokenList = stableRefSymbol.Split(
        new char[] { ':' } );

      string stableRefInst = tokenList[3] + ":"
        + tokenList[4] + ":" + tokenList[5];

      GeometryElement geomElem = elem.get_Geometry(
        gOptions );

      foreach( GeometryObject geomElemObj in geomElem )
      {
        GeometryInstance geomInst = geomElemObj
          as GeometryInstance;

        if( geomInst != null )
        {
          GeometryElement gInstGeom = geomInst
            .GetInstanceGeometry();

          foreach( GeometryObject gGeomObject
            in gInstGeom )
          {
            Solid solid = gGeomObject as Solid;
            if( solid != null )
            {
              foreach( Edge edge in solid.Edges )
              {
                string stableRef = edge.Reference
                  .ConvertToStableRepresentation(
                    dbDoc );

                if( stableRef == stableRefInst )
                {
                  instEdge = edge;
                  break;
                }
              }
            }

            if( instEdge != null )
            {
              // already found, exit early
              break;
            }
          }
        }
        if( instEdge != null )
        {
          // already found, exit early
          break;
        }
      }
      return instEdge;
    }

  public enum SpecialReferenceType
  {
    Left = 0,
    CenterLR = 1,
    Right = 2,
    Front = 3,
    CenterFB = 4,
    Back = 5,
    Bottom = 6,
    CenterElevation = 7,
    Top = 8
  }

  public static Reference GetSpecialFamilyReference( 
    FamilyInstance inst, 
    SpecialReferenceType refType )
  {
    Reference indexRef = null;

    int idx = (int) refType;

    if( inst != null )
    {
      Document dbDoc = inst.Document;

      Options geomOptions = dbDoc.Application.Create
        .NewGeometryOptions();

      if( geomOptions != null )
      {
        geomOptions.ComputeReferences = true;
        geomOptions.DetailLevel = ViewDetailLevel.Undefined;
        geomOptions.IncludeNonVisibleObjects = true;
      }

      GeometryElement gElement = inst.get_Geometry(
        geomOptions );

      GeometryInstance gInst = gElement.First()
        as GeometryInstance;

      String sampleStableRef = null;

      if( gInst != null )
      {
        GeometryElement gSymbol = gInst
          .GetSymbolGeometry();

        if( gSymbol != null )
        {
          foreach( GeometryObject geomObj in gSymbol )
          {
            if( geomObj is Solid )
            {
              Solid solid = geomObj as Solid;

              if( solid.Faces.Size > 0 )
              {
                Face face = solid.Faces.get_Item( 0 );

                sampleStableRef = face.Reference
                  .ConvertToStableRepresentation(
                    dbDoc );

                break;
              }
            }
            else if( geomObj is Curve )
            {
              Curve curve = geomObj as Curve;

              sampleStableRef = curve.Reference
                .ConvertToStableRepresentation( dbDoc );

              break;
            }
            else if( geomObj is Point )
            {
              Point point = geomObj as Point;

              sampleStableRef = point.Reference
                .ConvertToStableRepresentation( dbDoc );

              break;
            }
          }
        }

        if( sampleStableRef != null )
        {
          String[] refTokens = sampleStableRef.Split( 
            new char[] { ':' } );

          String customStableRef = refTokens[0] + ":"
            + refTokens[1] + ":" + refTokens[2] + ":"
            + refTokens[3] + ":" + idx.ToString();

          indexRef = Reference
            .ParseFromStableRepresentation( 
              dbDoc, customStableRef );

          GeometryObject geoObj = inst
            .GetGeometryObjectFromReference( 
              indexRef );

          if( geoObj != null )
          {
            String finalToken = "";

            if( geoObj is Edge )
            {
              finalToken = ":LINEAR";
            }

            if( geoObj is Face )
            {
              finalToken = ":SURFACE";
            }

            customStableRef += finalToken;

            indexRef = Reference
              .ParseFromStableRepresentation( 
                dbDoc, customStableRef );
          }
          else
          {
            indexRef = null;
          }
        }
      }
      else
      {
        throw new Exception( "No Symbol Geometry found..." );
      }
    }
    return indexRef;
  }
  }
  #endregion // Scott Wilson Reference Stable Representation Magic Voodoo

  #region Scott Conover sample code for SPR #201483
  // SPR #201483 [API wish: access reference plane 
  // in family instance and retrieve dimensioning 
  // reference to it]

  /// <summary>
  /// Get element's id and type information 
  /// and its supported information.
  /// </summary>
  [Transaction( TransactionMode.Manual )]
  public class Command : IExternalCommand
  {
    public Result Execute(
      ExternalCommandData revit,
      ref string message,
      ElementSet elements )
    {
      m_uiApp = revit.Application;
      m_app = m_uiApp.Application;
      m_uiDoc = m_uiApp.ActiveUIDocument;
      m_doc = m_uiDoc.Document;

      TaskDialog.Show( "Test application",
        "Revit version: " + m_app.VersionBuild );

      m_writer = new StreamWriter( @"C:\SRD201483.txt" );

      WriteDimensionReferences( 161908 );
      WriteElementGeometry( 161900 );

      m_writer.Close();

      return Result.Succeeded;
    }

    private List<Curve> m_referencePlaneReferences
      = new List<Curve>();

    private DetailCurve m_vLine;
    private DetailCurve m_hLine;

    private void WriteDimensionReferences( int dimId )
    {
      Dimension dim = m_doc.GetElement(
        new ElementId( dimId ) ) as Dimension;

      ReferenceArray references = dim.References;

      foreach( Reference reference in references )
      {
        m_writer.WriteLine( "Dim reference - "
          + reference.ConvertToStableRepresentation(
            m_doc ) );
      }
    }

    private ViewPlan m_targetView = null;

    private void WriteElementGeometry( int elementId )
    {
      FilteredElementCollector viewCollector = new FilteredElementCollector( m_doc );
      viewCollector.OfClass( typeof( ViewPlan ) );
      Func<ViewPlan, bool> isLevel1FloorPlan = v => !v.IsTemplate && v.Name == "Level 1" && v.ViewType == ViewType.FloorPlan;

      m_targetView = viewCollector.Cast<ViewPlan>().First<ViewPlan>( isLevel1FloorPlan );

      Transaction createCurve = new Transaction( m_doc, "Create reference curves" );
      createCurve.Start();
      const double xReferenceLocation = 30;
      Line vLine = Line.CreateBound( new XYZ( xReferenceLocation, 0, 0 ), new XYZ( xReferenceLocation, 20, 0 ) );
      m_vLine = m_doc.Create.NewDetailCurve( m_targetView, vLine );

      const double yReferenceLocation = -10;
      Line hLine = Line.CreateBound( new XYZ( 0, yReferenceLocation, 0 ), new XYZ( 20, yReferenceLocation, 0 ) );
      m_hLine = m_doc.Create.NewDetailCurve( m_targetView, hLine );
      createCurve.Commit();

      Element e = m_doc.GetElement( new ElementId( elementId ) );

      Options options = new Options();
      options.ComputeReferences = true;
      options.IncludeNonVisibleObjects = true;
      options.View = m_targetView;

      GeometryElement geomElem = e.get_Geometry( options );

      foreach( GeometryObject geomObj in geomElem )
      {
        if( geomObj is Solid )
        {
          WriteSolid( (Solid) geomObj );
        }
        else if( geomObj is GeometryInstance )
        {
          TraverseGeometryInstance( (GeometryInstance) geomObj );
        }
        else
        {
          m_writer.WriteLine( "Something else - " + geomObj.GetType().Name );
        }
      }

      foreach( Curve curve in m_referencePlaneReferences )
      {
        // Try to get the geometry object from reference
        Reference curveReference = curve.Reference;
        GeometryObject geomObj = e.GetGeometryObjectFromReference( curveReference );

        if( geomObj != null )
        {
          m_writer.WriteLine( "Curve reference leads to: " + geomObj.GetType().Name );
        }
      }

      // Dimension to reference curves
      foreach( Curve curve in m_referencePlaneReferences )
      {
        DetailCurve targetLine = m_vLine;

        Line line = (Line) curve;
        XYZ lineStartPoint = line.GetEndPoint( 0 );
        XYZ lineEndPoint = line.GetEndPoint( 1 );
        XYZ direction = lineEndPoint - lineStartPoint;
        Line dimensionLine = null;
        if( Math.Abs( direction.Y ) < 0.0001 )
        {
          targetLine = m_hLine;
          XYZ dimensionLineStart = new XYZ( lineStartPoint.X + 5, lineStartPoint.Y, 0 );
          XYZ dimensionLineEnd = new XYZ( dimensionLineStart.X, dimensionLineStart.Y + 10, 0 );

          dimensionLine = Line.CreateBound( dimensionLineStart, dimensionLineEnd );
        }
        else
        {
          targetLine = m_vLine;
          XYZ dimensionLineStart = new XYZ( lineStartPoint.X, lineStartPoint.Y + 5, 0 );
          XYZ dimensionLineEnd = new XYZ( dimensionLineStart.X + 10, dimensionLineStart.Y, 0 );
          dimensionLine = Line.CreateBound( dimensionLineStart, dimensionLineEnd );
        }

        ReferenceArray references = new ReferenceArray();
        references.Append( curve.Reference );
        references.Append( targetLine.GeometryCurve.Reference );

        Transaction t = new Transaction( m_doc, "Create dimension" );
        t.Start();
        m_doc.Create.NewDimension( m_targetView, dimensionLine, references );
        t.Commit();
      }
    }

    private void TraverseGeometryInstance( GeometryInstance geomInst )
    {
      GeometryElement instGeomElem = geomInst.GetSymbolGeometry();
      foreach( GeometryObject instGeomObj in instGeomElem )
      {
        if( instGeomObj is Solid )
        {
          WriteSolid( (Solid) instGeomObj );
        }
        else if( instGeomObj is Curve )
        {
          Curve curve = (Curve) instGeomObj;
          Transaction createCurve = new Transaction( m_doc, "Create curve" );
          createCurve.Start();
          m_doc.Create.NewDetailCurve( m_targetView, curve );
          createCurve.Commit();

          if( curve.Reference != null )
          {
            m_writer.WriteLine( "Geometry curve - " + curve.Reference.ConvertToStableRepresentation( m_doc ) );
            m_referencePlaneReferences.Add( curve );
          }
          else
            m_writer.WriteLine( "Geometry curve - but reference is null" );
        }

        else
        {
          m_writer.WriteLine( "Something else - " + instGeomObj.GetType().Name );
        }
      }
    }

    private void WriteSolid( Solid solid )
    {
      foreach( Face face in solid.Faces )
      {
        Reference reference = face.Reference;
        if( reference != null )
          m_writer.WriteLine( "Geometry face - " + reference.ConvertToStableRepresentation( m_doc ) );
        else
          m_writer.WriteLine( "Geometry face - but reference is null" );
      }
    }

    private UIApplication m_uiApp;
    private UIDocument m_uiDoc;
    private Application m_app;
    private Document m_doc;
    private TextWriter m_writer;
  }
  #endregion // Scott's sample code from SPR #201483

  [Transaction( TransactionMode.Manual )]
  class CmdDimensionInstanceOrigin : IExternalCommand
  {
    static Options _opt = null;

    /// <summary>
    /// Retrieve the given family instance's
    /// non-visible geometry point reference.
    /// </summary>
    static Reference GetFamilyInstancePointReference(
      FamilyInstance fi )
    {
      return fi.get_Geometry( _opt )
        .OfType<Point>()
        .Select<Point, Reference>( x => x.Reference )
        .FirstOrDefault();
    }

    /// <summary>
    /// External command mainline. Run in the sample 
    /// model Z:\a\rvt\dimension_case_2015.rvt, e.g.
    /// </summary>
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication app = commandData.Application;
      UIDocument uidoc = app.ActiveUIDocument;
      Document doc = uidoc.Document;

      JtPairPicker<FamilyInstance> picker
        = new JtPairPicker<FamilyInstance>( uidoc );

      Result rc = picker.Pick();

      if( Result.Failed == rc )
      {
        message = "We need at least two "
          + "FamilyInstance elements in the model.";
      }
      else if( Result.Succeeded == rc )
      {
        IList<FamilyInstance> a = picker.Selected;

        _opt = new Options();
        _opt.ComputeReferences = true;
        _opt.IncludeNonVisibleObjects = true;

        XYZ[] pts = new XYZ[2];
        Reference[] refs = new Reference[2];

        pts[0] = ( a[0].Location as LocationPoint ).Point;
        pts[1] = ( a[1].Location as LocationPoint ).Point;

        refs[0] = GetFamilyInstancePointReference( a[0] );
        refs[1] = GetFamilyInstancePointReference( a[1] );

        CmdDimensionWallsIterateFaces
          .CreateDimensionElement( doc.ActiveView,
          pts[0], refs[0], pts[1], refs[1] );
      }
      return rc;
    }

    /// <summary>
    /// Create vertical dimensioning, cf.
    /// http://forums.autodesk.com/t5/revit-api-forum/how-can-i-create-dimension-line-that-is-not-parallel-to-detail/m-p/6801271
    /// </summary>
    void CreateVerticalDimensioning( ViewSection viewSection )
    {
      Document doc = viewSection.Document;

      XYZ point3 = new XYZ( 417.8, 80.228, 46.8 );
      XYZ point4 = new XYZ( 417.8, 80.811, 46.3 );

      Line geomLine3 = Line.CreateBound( point3, point4 );
      Line dummyLine = Line.CreateBound( XYZ.Zero, XYZ.BasisY );

      using( Transaction tx = new Transaction( doc ) )
      {
        tx.Start( "tx" );

        DetailLine line3 = doc.Create.NewDetailCurve( 
          viewSection, geomLine3 ) as DetailLine;

        DetailLine dummy = doc.Create.NewDetailCurve( 
          viewSection, dummyLine ) as DetailLine;

        ReferenceArray refArray = new ReferenceArray();
        refArray.Append( dummy.GeometryCurve.Reference );
        refArray.Append( line3.GeometryCurve.GetEndPointReference( 0 ) );
        refArray.Append( line3.GeometryCurve.GetEndPointReference( 1 ) );
        XYZ dimPoint1 = new XYZ( 417.8, 80.118, 46.8 );
        XYZ dimPoint2 = new XYZ( 417.8, 80.118, 46.3 );
        Line dimLine3 = Line.CreateBound( dimPoint1, dimPoint2 );

        Dimension dim = doc.Create.NewDimension( 
          viewSection, dimLine3, refArray );

        doc.Delete( dummy.Id );
        tx.Commit();
      }
    }

  }
}
