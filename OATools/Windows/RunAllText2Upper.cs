//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Autodesk.Revit;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using OATools;
//using OATools.Commands;

//namespace OATools.Windows
//{

//    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
//    public class RunAllText2Upper : IExternalCommand
//    {
//        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
//        {


//            return Autodesk.Revit.UI.Result.Succeeded;
//        }
//    }
//}


//[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//public class clsHelloWorld : IExternalCommand
//{
//    // The main Execute method (inherited from IExternalCommand) must be public
//    public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
//        ref string message, ElementSet elements)
//    {
//        TaskDialog.Show("Revit", "Hello World");

//        return Autodesk.Revit.UI.Result.Succeeded;
//    }
//}

//public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
//{
//    try
//    {

//        Document document = commandData.Application.ActiveUIDocument.Document;


//        // Iterate through the document and find all the TextNote elements
//        FilteredElementCollector collector = new FilteredElementCollector(document, document.ActiveView.Id);
//        collector.OfClass(typeof(TextNote));
//        if (collector.GetElementCount() == 0)
//        {
//            message = "The document does not contain TextNote elements";
//            return Result.Failed;
//        }

//        // Record all TextNotes that are not yet formatted to be 'AllCaps'
//        ElementSet textNotesToUpdate = new Autodesk.Revit.DB.ElementSet();
//        foreach (Element element in collector)
//        {
//            TextNote textNote = (TextNote)element;

//            // Extract the FormattedText from the TextNote
//            FormattedText formattedText = textNote.GetFormattedText();

//            // If 'GetAllCapsStatus()' returns 'FormatStatus.All' then all the characters in
//            // the text have the 'AllCaps' status.
//            // If there are no characters that have the 'AllCaps' status then 'GetAllCapsStatus()'
//            // will return 'FormatStatus.None'.  And if only some of the characters have 
//            // the 'AllCaps' status then 'GetAllCapsStatus()' returns 'FormatStatus.Mixed'
//            //
//            // Note that it is also possible to test whether all characters are 
//            // bold, italic, underlined, or have superscript or subscript formatting.
//            // See 'GetBoldStatus', 'GetItalicStatus', 'GetUnderlineStatus', 
//            // 'GetSuperscriptStatus', and 'GetSubscriptStatus' respectively.
//            //
//            // Note that it is also possible to only test a subset of characters in the FormattedText
//            // This is done by calling these methods with a 'TextRange' that specifies 
//            // the range of characters to be tested.

//            if (formattedText.GetAllCapsStatus() != FormatStatus.All)
//            {
//                textNotesToUpdate.Insert(textNote);
//            }
//        }

//        // Check whether we found any TextNotes that need to be formatted
//        if (textNotesToUpdate.IsEmpty)
//        {
//            message = "No TextNote elements needed updating";
//            return Result.Failed;
//        }


//        // Apply the 'AllCaps' formatting to the TextNotes that still need it.
//        using (Transaction transaction = new Transaction(document, "Capitalize All TextNotes"))
//        {
//            transaction.Start();

//            foreach (TextNote textNote in textNotesToUpdate)
//            {
//                Autodesk.Revit.DB.FormattedText formattedText = textNote.GetFormattedText();

//                // Apply the 'AllCaps' status to all characters.
//                // Note that there are also methods to apply bold, italic, underline, 
//                // superscript and subscript formatting.  
//                // And that the formatting can be applied both to the entire text
//                // (as is done here), or to a subset by calling these methods with a 'TextRange'

//                formattedText.SetAllCapsStatus(true);

//                // After making the changes to the Formatted text
//                // it is necessary to apply them to the TextNote element
//                // (or elements) that should get these changes.
//                textNote.SetFormattedText(formattedText);
//            }

//            transaction.Commit();
//        }

//        return Result.Succeeded;
//    }
//    catch (Exception ex)
//    {
//        message = ex.Message;
//        return Result.Failed;
//    }
//}
    