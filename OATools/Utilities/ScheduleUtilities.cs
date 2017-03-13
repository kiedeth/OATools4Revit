using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OATools.Utilities
{
    class ScheduleUtilities
    {
        /// <summary>
        /// Create a NoteBlock schedule
        /// </summary>
        public void CreateDNoteBlock(UIDocument uidoc, ElementId symbolId)
        {
            Document doc = uidoc.Document;

            List<ViewSchedule> schedules = new List<ViewSchedule>();

            //Check to make sure the user is on a sheet otherwise cancel 
            View activeView = doc.ActiveView;
            if (!(activeView is ViewSheet))
            {
                TaskDialog.Show("ERROR!", "You must be on a sheet to create a DNote Legend");
            }

            //Get the active sheet number
            Parameter activeSheetNumber;
            activeSheetNumber = activeView.get_Parameter(BuiltInParameter.SHEET_NUMBER);
            string sheet_number = activeSheetNumber.AsString();

            //Create an empty view schedule of wall category.
            //ViewSchedule schedule = ViewSchedule.CreateSchedule(document, new ElementId(BuiltInCategory.OST_Walls), ElementId.InvalidElementId);

            //Create a note-block view schedule.
            ViewSchedule schedule = ViewSchedule.CreateNoteBlock(doc, symbolId);
            schedule.Name = sheet_number + " DNote Legend";
            schedules.Add(schedule);
            
        }


        /// <summary>
        /// Add fields to view schedule.
        /// </summary>
        /// <param name="schedules">List of view schedule.</param>
        public void AddFieldToSchedule(List<ViewSchedule> schedules)
        {
            IList<SchedulableField> schedulableFields = null;

            foreach (ViewSchedule vs in schedules)
            {
                //Get all schedulable fields from view schedule definition.
                schedulableFields = vs.Definition.GetSchedulableFields();

                foreach (SchedulableField sf in schedulableFields)
                {
                    bool fieldAlreadyAdded = false;
                    //Get all schedule field ids
                    IList<ScheduleFieldId> ids = vs.Definition.GetFieldOrder();
                    foreach (ScheduleFieldId id in ids)
                    {
                        //If the GetSchedulableField() method of gotten schedule field returns same schedulable field,
                        // it means the field is already added to the view schedule.
                        if (vs.Definition.GetField(id).GetSchedulableField() == sf)
                        {
                            fieldAlreadyAdded = true;
                            break;
                        }
                    }

                    //If schedulable field doesn't exist in view schedule, add it.
                    if (fieldAlreadyAdded == false)
                    {
                        vs.Definition.AddField(sf);
                    }
                }
            }
        }
    }
}


//private ElementId getTheElementID(UIDocument uidoc)
//{
//    Document doc = uidoc.Document;
//    Selection sel = uidoc.Selection;


//    //ICollection<ElementId> noteblockFamilies = ViewSchedule.GetValidFamiliesForNoteBlock(doc);


//    // Get selected elements from current document.
//    ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

//    // Display current number of selected elements
//    TaskDialog.Show("Revit", "Number of selected elements: " + selectedIds.Count.ToString());

//    // Go through the selected items and filter out generic annotations only.
//    ICollection<ElementId> selectedElements = new List<ElementId>();
//    ElementId symbolId = null;

//    foreach (ElementId id in selectedIds)
//    {
//        Element elements = uidoc.Document.GetElement(id);
//        if (elements is AnnotationSymbol)
//        {
//            selectedElements.Add(id);
//        }

//        symbolId = selectedElements.First<ElementId>();


//        return symbolId;
//    }

//    return symbolId;

//}