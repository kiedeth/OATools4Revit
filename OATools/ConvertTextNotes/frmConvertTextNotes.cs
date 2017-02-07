using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools.ConvertTextNotes
{
    public partial class frmConvertTextNotes : System.Windows.Forms.Form
    {

        #region Class Member Variables
        /// <summary>
        /// Revit active document
        /// </summary>
        Autodesk.Revit.DB.Document document;
        #endregion


        public frmConvertTextNotes(Autodesk.Revit.UI.ExternalCommandData commandData)
        {
            InitializeComponent();
            document = commandData.Application.ActiveUIDocument.Document;
        }

        private void btnConvertTextNotes_Click(object sender, EventArgs e)
        {
            convertTextNotesToUpperByView();
        }


        #region convertTextNotesToUpperByView
        private void convertTextNotesToUpperByView()
        {
            // Iterate through the document and find all the TextNote elements
            FilteredElementCollector collector = new FilteredElementCollector(document, document.ActiveView.Id);
            collector.OfClass(typeof(TextNote));
            if (collector.GetElementCount() == 0)
            {
                return;
            }

            // Record all TextNotes that are not yet formatted to be 'AllCaps'
            ElementSet textNotesToUpdate = new Autodesk.Revit.DB.ElementSet();
            foreach (Element element in collector)
            {
                TextNote textNote = (TextNote)element;

                // Extract the FormattedText from the TextNote
                FormattedText formattedText = textNote.GetFormattedText();

                if (formattedText.GetAllCapsStatus() != FormatStatus.All)
                {
                    textNotesToUpdate.Insert(textNote);
                }
            }

            // Check whether we found any TextNotes that need to be formatted
            if (textNotesToUpdate.IsEmpty)
            {
                //Do something if there are no notes to format
            }

            // Apply the 'AllCaps' formatting to the TextNotes that still need it.
            using (Transaction transaction = new Transaction(document, "Capitalize All TextNotes"))
            {
                transaction.Start();

                foreach (TextNote textNote in textNotesToUpdate)
                {
                    Autodesk.Revit.DB.FormattedText formattedText = textNote.GetFormattedText();

                    formattedText.SetAllCapsStatus(true);

                    textNote.SetFormattedText(formattedText);
                }

                transaction.Commit();
            }

        }
        #endregion

    }
}
