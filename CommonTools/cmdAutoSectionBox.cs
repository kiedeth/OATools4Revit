//
// (C) Copyright 2003-2016 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;
using OATools2018.CommonTools;
using Autodesk.Revit.UI.Selection;
using System.Linq;

namespace OATools2018.CommonTools.AutoSectionBox
{
    /// <summary>
    /// The main class which given a linear element, such as a wall, floor or beam,
    /// generates a section view across the mid point of the element.
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class Command : IExternalCommand
    {
        
        
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            try
            {
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
                Document doc = uidoc.Document;
                Selection selection = uidoc.Selection;
                Autodesk.Revit.DB.View activeView = doc.ActiveView;
                ElementId levelId = null;

                // Get a ViewFamilyType for a 3D view
                ViewFamilyType viewFamilyType = (from v in new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).
                Cast<ViewFamilyType>()
                where v.ViewFamily == ViewFamily.ThreeDimensional
                select v).First();

                using (Transaction tx = new Transaction(doc, "Create view"))
                {
                    //set the name of the view
                    String viewNameToCreate = "OAT 3D Section";

                    //start transaction
                    tx.Start();

                    // Create the 3D view 
                    View3D view = View3D.CreateIsometric(doc, viewFamilyType.Id);

                    // Set the name of the view
                    view.Name = makeViewNameUnique(doc, viewNameToCreate);

                    // Set the name of the transaction
                    tx.SetName("Create view " + view.Name);

                    // Create a new BoundingBoxXYZ to define a rectangular space
                    BoundingBoxXYZ boundingBoxXYZ = new BoundingBoxXYZ();

                    // Determin the height of the bounding box
                    double zOffset = 0;

                    // Get the current level Id
                    Level _curLevel = null;
                    Parameter level = activeView.LookupParameter("Associated Level");
                    FilteredElementCollector lvlCollector = new FilteredElementCollector(doc);
                    ICollection<Element> lvlCollection = lvlCollector.OfClass(typeof(Level)).ToElements();
                    foreach (Element lev in lvlCollection)
                    {
                        Level lvl = lev as Level;
                        if (lvl.Name == level.AsString())
                        {
                            levelId = lvl.Id;
                            _curLevel = lvl;
                        }
                    }

                    // Get the selection box
                    PickedBox pickBox = uidoc.Selection.PickBox(PickBoxStyle.Directional, "Click and drag to define the box.");

                    // Get the two user selected points on screen
                    XYZ xyzFirst = pickBox.Min;
                    XYZ xyzThird = pickBox.Max;

                    // Set zOffset to 10'
                    zOffset = _curLevel.Elevation + 10;

                    // Build the box from the selected points
                    XYZ xyxSecond = new XYZ(xyzThird.X, xyzFirst.Y, zOffset);
                    XYZ xyzFourth = new XYZ(xyzFirst.X, xyzThird.Y, zOffset);

                    boundingBoxXYZ.Min = new XYZ(xyzFirst.X, xyzThird.Y, _curLevel.Elevation);
                    boundingBoxXYZ.Max = new XYZ(xyzThird.X, xyzFirst.Y, zOffset);
                    view.SetSectionBox(boundingBoxXYZ);

                    //End transaction
                    tx.Commit();
                    uidoc.ActiveView = view;
                }               
            }

            catch (Exception e)
            {
                message = e.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }
            return Result.Succeeded;
        }

        private string makeViewNameUnique(Document doc, String nameToMakeUnique)
        {
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
            ICollection<Element> viewCollection = viewCollector.OfClass(typeof(View3D)).ToElements();
            int count = 1;
            string rawName = nameToMakeUnique;
            string newName = rawName;
            foreach (View3D view in viewCollection)
            {
                while (view.Name == newName)
                {
                    newName = rawName + " (" + count + ")";
                    count++;
                }                
            }
            return newName;
        }

    }
}


// Set zOffset to 10'
//zOffset = _curLevel.Elevation + 10;
//boundingBoxXYZ.Min = new XYZ(-50, -100, _curLevel.Elevation);
//boundingBoxXYZ.Max = new XYZ(200, 125, zOffset);
