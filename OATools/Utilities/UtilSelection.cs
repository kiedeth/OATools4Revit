#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using WinForms = System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections;
using System.Windows.Documents;
using OATools.Utilities;
#endregion // Namespaces

namespace OATools.Utilities
{
    class UtilSelection
    {

        public static ElementId getSelectedFamily(UIDocument uidoc)
        {
            Document doc = uidoc.Document;

            //Get first ElementId of a Note Block family.
            ICollection<ElementId> noteblockFamilies = ViewSchedule.GetValidFamiliesForNoteBlock(doc);

            ElementId symbolId = noteblockFamilies.First<ElementId>();
           
            return symbolId;

        }
    }
}
