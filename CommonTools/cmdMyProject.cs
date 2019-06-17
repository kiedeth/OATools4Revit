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

namespace OATools2018.CommonTools.MyProject
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class cmdMyProject : IExternalCommand
    {
        ExternalCommandData m_commandData;
        string m_message;
        ElementSet m_elements;

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
            m_commandData = commandData;
            m_message = message;
            m_elements = elements;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            using (var form = new frmMyProject(commandData, ref message, elements))
            {
                form.ShowDialog();
            }

            using (Transaction tx = new Transaction(doc, "My Project"))
            {
                tx.Start();

                tx.Commit();
                tx.Dispose();
            }

            return Result.Succeeded;
        }



    }
}
