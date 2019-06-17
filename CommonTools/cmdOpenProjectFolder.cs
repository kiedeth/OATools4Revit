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
#endregion // Namespaces

namespace OATools2018.CommonTools.projectFolder
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class cmdOpenProjectFolder : IExternalCommand
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
            string name = doc.Title;
            string path = doc.PathName;

            //replace away the filename
            string folderPath = path.Replace(name + ".rvt", "");

            using (Transaction tx = new Transaction(doc, "Open Project Folder"))
            {
                tx.Start();

                //Open the folder
                System.Diagnostics.Process.Start("explorer.exe", folderPath);

                tx.Commit();
                tx.Dispose();
            }
            return Result.Succeeded;
        }
    }
}
