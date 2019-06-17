#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools2018.CommonTools.AutoSectionBox;
using OATools2018Commands;
#endregion // Namespaces

namespace OATools2018.CommonTools.CopyProjectInfoFromLink
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {

        // get the absolute path of this assembly
        string thisAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        //get this assembly path
        public string returnAssembly()
        {
            string thisEXE = thisAssemblyPath;

            return thisEXE;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            CmdLinkedFiles cmd = new CmdLinkedFiles();
            cmd.Execute(commandData, ref message, elements);




            using (Transaction tx = new Transaction(doc, "Auto Section Box"))
            {
                tx.Start();

                TaskDialog.Show("test", "test");

                tx.Commit();
                tx.Dispose();
            }

            return Result.Succeeded;
        }



    }
}
