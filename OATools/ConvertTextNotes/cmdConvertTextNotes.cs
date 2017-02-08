

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace OATools.ConvertTextNotes
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class cmdConvertTextNotes : IExternalCommand
    {


        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Create a transaction
                Transaction documentTransaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Document");
                documentTransaction.Start();

                System.Windows.Forms.DialogResult result;


                // create a form to display the information of view filters
                using (frmConvertTextNotes frm = new frmConvertTextNotes(commandData))
                {
                    result = frm.ShowDialog();
                }
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    documentTransaction.Commit();
                    return Autodesk.Revit.UI.Result.Succeeded;
                }
                else
                {
                    documentTransaction.RollBack();
                    return Autodesk.Revit.UI.Result.Cancelled;
                }



                //return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                // If there is something wrong, give error information and return failed
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }
            

        }
    }
}

