using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace OATools2018.Filtering
{
    /// <summary>
    /// To add an external command to Autodesk Revit, 
    /// the developer must define an class which implement the IExternalCommand interface. 
    /// This class is used as the connection of revit and external program
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class cmdViewFilters : IExternalCommand
    {
        /// <summary>
        /// Implement this method as an external command for Revit.
        /// </summary>
        /// <param name="commandData">An object that is passed to the external application 
        /// which contains data related to the command, 
        /// such as the application object and active view.</param>
        /// <param name="message">A message that can be set by the external application 
        /// which will be displayed if a failure or cancellation is returned by 
        /// the external command.</param>
        /// <param name="elements">A set of elements to which the external application 
        /// can add elements that are to be highlighted in case of failure or cancellation.</param>
        /// <returns>Return the status of the external command. 
        /// A result of Succeeded means that the API external method functioned as expected. 
        /// Cancelled can be used to signify that the user cancelled the external operation 
        /// at some point. Failure should be returned if the application is unable to proceed with 
        /// the operation.</returns>
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData,
                                               ref string message, ElementSet elements)
        {
            try
            {
                // create a form to display the information of view filters
                using (frmViewFilters infoForm = new frmViewFilters(commandData))
                {
                    infoForm.ShowDialog();
                }
                return Autodesk.Revit.UI.Result.Succeeded;
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
