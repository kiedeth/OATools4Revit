using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;

namespace OATools.DNoter
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class cmdCreateDNote : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document document = commandData.Application.ActiveUIDocument.Document;

            try
            {
                //Create a transaction
                Transaction documentTransaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Document");
                documentTransaction.Start();



             

                String fileName = @"C:\Users\jschaad\documents\visual studio 2015\Projects\OATools\OATools\Resources\fsDNote.rfa";


                // try to load family
                Family family = null;
                if (!document.LoadFamily(fileName, out family))
                {
                    //throw new Exception("Unable to load " + fileName);

                    documentTransaction.RollBack();
                    return Autodesk.Revit.UI.Result.Cancelled;
                }




                // Loop through table symbols and add a new table for each
                ISet<ElementId> familySymbolIds = family.GetFamilySymbolIds();
                double x = 0.0, y = 0.0;
                foreach (ElementId id in familySymbolIds)
                {
                    FamilySymbol symbol = family.Document.GetElement(id) as FamilySymbol;
                    XYZ location = new XYZ(x, y, 10.0);

                    FamilyInstance instance = document.Create.NewFamilyInstance(location, symbol, StructuralType.NonStructural);
                    x += 10.0;
                }


                documentTransaction.Commit();
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
