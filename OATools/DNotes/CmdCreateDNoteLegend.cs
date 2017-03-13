
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using System.Threading.Tasks;
using OATools.Main;
using System.IO;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI.Selection;
using OATools.Utilities;

namespace OATools.DNotes
{
    [Transaction(TransactionMode.Manual)]
    public class CmdCreateDNoteLegend : IExternalCommand
    {

        private Element value;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Message", "This feature of O/A Tools is not complete yet.");


            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Get first ElementId of a Note Block family.
            ICollection<ElementId> noteblockFamilies = ViewSchedule.GetValidFamiliesForNoteBlock(doc);
            ElementId symbolId = noteblockFamilies.First<ElementId>();

            //CreateDNoteLegend(doc, symbolId);

            //Gets the element associated with the ID
            //Element eFromId = doc.GetElement(symbolId);

            //ParameterSet pSet = eFromId.Parameters;



            //foreach (Parameter param in pSet)
            //{
            //    TaskDialog.Show("Test", param.GUID.ToString());

            //    if (param.IsShared)
            //    {
            //        TaskDialog.Show("Test", param.GUID.ToString());
            //    }
            //}


            return Result.Succeeded;
        }


        
        //Create the Note Block Schedule
        public static void CreateDNoteLegend(Document doc, ElementId symbolId)
        {
            ViewSchedule vs = null;

            using (Transaction transaction = new Transaction(doc, "Creating Note BLock"))
            {
                if (!symbolId.Equals(ElementId.InvalidElementId))
                {
                    transaction.Start();

                    //Create a note-block view schedule.
                    vs = ViewSchedule.CreateNoteBlock(doc, symbolId);

                    AddRegularFieldToSchedule(doc, vs);
                }

                if (null != vs)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.RollBack();
                }
            }
        }











        /// <summary>
        /// Adds a single parameter field to the schedule
        /// </summary>
        public static void AddRegularFieldToSchedule(Document doc, ViewSchedule schedule)
        {


            ScheduleDefinition definition = schedule.Definition;

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

            // Find a matching SchedulableField
            //SchedulableField schedulableField = definition.GetSchedulableFields().FirstOrDefault<SchedulableField>();

            schedule.Name = sheet_number + " DNote Legend";

            

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






















        /// <summary>
        ///// Create a view schedule of wall category and add schedule field, filter and sorting/grouping field to it.
        ///// </summary>
        ///// <param name="uiDocument">UIdocument of revit file.</param>
        ///// <returns>ICollection of created view schedule(s).</returns>
        //private ICollection<ViewSchedule> CreateSchedules(UIDocument uiDocument, ElementId symbolId)
        //{
        //    Document document = uiDocument.Document;

        //    Transaction t = new Transaction(document, "Create Schedules");
        //    t.Start();

        //    List<ViewSchedule> schedules = new List<ViewSchedule>();



        //    //Check to make sure the user is on a sheet otherwise cancel 
        //    View activeView = document.ActiveView;
        //    if (!(activeView is ViewSheet))
        //    {
        //        TaskDialog.Show("ERROR!", "You must be on a sheet to create a DNote Legend");
        //    }

        //    //Get the active sheet number
        //    Parameter activeSheetNumber;
        //    activeSheetNumber = activeView.get_Parameter(BuiltInParameter.SHEET_NUMBER);
        //    string sheet_number = activeSheetNumber.AsString();

        //    //Create an empty view schedule of wall category.
        //    //ViewSchedule schedule = ViewSchedule.CreateSchedule(document, new ElementId(BuiltInCategory.OST_Walls), ElementId.InvalidElementId);

        //    //Create a note-block view schedule.
        //    ViewSchedule schedule = ViewSchedule.CreateNoteBlock(document, symbolId);
        //    schedule.Name = sheet_number + " DNote Legend";
        //    schedules.Add(schedule);

        //    //Iterate all the schedulable field gotten from the walls view schedule.
        //    foreach (SchedulableField schedulableField in schedule.Definition.GetSchedulableFields())
        //    {
        //        //Judge if the FieldType is ScheduleFieldType.Instance.
        //        if (schedulableField.FieldType == ScheduleFieldType.Instance)
        //        {
        //            //Get ParameterId of SchedulableField.
        //            ElementId parameterId = schedulableField.ParameterId;

        //            //If the ParameterId is id of BuiltInParameter.ALL_MODEL_MARK then ignore next operation.
        //            if (ShouldSkip(parameterId))
        //                continue;

        //            //Add a new schedule field to the view schedule by using the SchedulableField as argument of AddField method of Autodesk.Revit.DB.ScheduleDefinition class.
        //            ScheduleField field = schedule.Definition.AddField(schedulableField);


        //            //ScheduleDefinition schedDef = schedule.Definition;

        //            //// Hide two columns in the schedule

        //            //schedDef.GetField(0).IsHidden = true;
        //            //schedDef.GetField(1).IsHidden = true;
        //            //schedDef.GetField(1).IsHidden = false;
        //            //schedDef.GetField(1).IsHidden = false;

        //            //Judge if the parameterId is a BuiltInParameter.
        //            if (Enum.IsDefined(typeof(BuiltInParameter), parameterId.IntegerValue))
        //            {
        //                BuiltInParameter bip = (BuiltInParameter)parameterId.IntegerValue;
        //                //Get the StorageType of BuiltInParameter.
        //                StorageType st = document.get_TypeOfStorage(bip);

        //                //if StorageType is String or ElementId, set GridColumnWidth of schedule field to three times of current GridColumnWidth. 
        //                //And set HorizontalAlignment property to left.
        //                if (st == StorageType.String)
        //                {
        //                    field.GridColumnWidth = 3 * field.GridColumnWidth;
        //                    field.HorizontalAlignment = ScheduleHorizontalAlignment.Left;
        //                }
        //                //For other StorageTypes, set HorizontalAlignment property to center.
        //                else
        //                {
        //                    //field.HorizontalAlignment = ScheduleHorizontalAlignment.Center;
        //                }
        //            }


        //            //Filter the view schedule by volume
        //            if (field.ParameterId == new ElementId(BuiltInParameter.HOST_VOLUME_COMPUTED))
        //            {
        //                double volumeFilterInCubicFt = 0.8 * Math.Pow(3.2808399, 3.0);
        //                ScheduleFilter filter = new ScheduleFilter(field.FieldId, ScheduleFilterType.GreaterThan, volumeFilterInCubicFt);
        //                schedule.Definition.AddFilter(filter);
        //            }

        //            //Group and sort the view schedule by type
        //            if (field.ParameterId == new ElementId(BuiltInParameter.ELEM_TYPE_PARAM))
        //            {
        //                ScheduleSortGroupField sortGroupField = new ScheduleSortGroupField(field.FieldId);
        //                sortGroupField.ShowHeader = true;
        //                schedule.Definition.AddSortGroupField(sortGroupField);
        //            }
        //        }
        //    }

        //    t.Commit();

        //    uiDocument.ActiveView = schedule;

        //    return schedules;
        //}

        /////// <summary>
        /////// Judge if the parameterId should be skipped.
        /////// </summary>
        /////// <param name="parameterId">ParameterId to be judged.</param>
        /////// <returns>Return true if parameterId should be skipped.</returns>
        ////private bool ShouldSkip(ElementId parameterId)
        ////{
        ////    foreach (BuiltInParameter bip in s_skipParameters)
        ////    {
        ////        if (new ElementId(bip) == parameterId)
        ////            return true;
        ////    }
        ////    return false;
        ////}






    }//CmdCreateDNoteLegend
}//OATools.DNotes


