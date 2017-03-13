////
//// Created by SharpDevelop.
//// User: michael
//// Date: 2/4/2015
//// Time: 11:13 AM
//// 
//// To change this template use Tools | Options | Coding | Edit Standard Headers.
////
//using System;
//using Autodesk.Revit.UI;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI.Selection;
//using System.Collections.Generic;
//using System.Linq;
//using System.Diagnostics;

//[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//[Autodesk.Revit.DB.Macros.AddInId("FE9B398F-B0E3-412C-8328-FC1D92221E12")]
//public partial class ThisDocument
//{

//	public void ImportDWGsToDraftingViews()
//	{
//		//Get the current document
//		Document curDoc = this.Application.ActiveUIDocument.Document;
//		int counter = 0;

//		//open form
//		using (frmImportDWG curForm = new frmImportDWG()) {
//			//show form
//			curForm.ShowDialog();

//			if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
//			//Result.Cancelled
//			} else {
//				//get selected DWG files
//				List<string> drawingList = curForm.getSelectedDWGs();

//				using (Transaction curTrans = new Transaction(curDoc, "Import DWGs to Drafting View")) {
//					if (curTrans.Start() == TransactionStatus.Started) {
//						//loop through DWGs, create drafting view and insert
//						foreach (string curDWG in drawingList) {

//							//get view family type for drafting view
//							ElementId curVFT = getDraftingViewFamilyType(curDoc);

//							//create drafting view
//							View curView = ViewDrafting.Create(curDoc, curVFT);

//							//rename drafting view to DWG filename
//							string tmpName = getFilenameFromPath(curDWG);
//							string viewName = tmpName.Substring(0, tmpName.Length - 4);

//							try {
//								curView.Name = viewName;
//							} catch (Exception ex) {
//								TaskDialog.Show("Error", "There is already a drafting view named " + viewName + " in this project file. The view will be named " + curView.Name + " instead.");
//							}

//							//set insert settings
//							DWGImportOptions curImportOptions = new DWGImportOptions();

//							switch (curForm.getColorSetting()) {
//								case "Invert":
//									curImportOptions.ColorMode = ImportColorMode.Inverted;
//									break;
//								case "Preserve":
//									curImportOptions.ColorMode = ImportColorMode.Preserved;
//									break;
//								default:
//									curImportOptions.ColorMode = ImportColorMode.BlackAndWhite;
//									break;
//							}

//							switch (curForm.getPosSetting()) {
//								case "Origin to Origin":
//									curImportOptions.Placement = ImportPlacement.Origin;
//									break;

//								case "Center to Center":
//									curImportOptions.Placement = ImportPlacement.Centered;
//									break;
//							}

//							//import / link current DWG to current view
//							ElementId curLinkID = null;

//							if (curForm.getInsertType() == "Link") {
//								curDoc.Link(curDWG, curImportOptions, curView, out curLinkID);
//								counter = counter + 1;
//							} else {
//								curDoc.Import(curDWG, curImportOptions, curView, out curLinkID);
//								counter = counter + 1;
//							}
//						}
//					}

//					//commit changes
//					curTrans.Commit();
//				}
//			}
//		}

//		//alert user
//		TaskDialog.Show("Complete", "Inserted " + counter + " DWG files.");

//	}

//	private string getFilenameFromPath(string filePath)
//	{
//		//Split the string on the backslash character.
//		string[] parts = filePath.Split(new char[] { '\\' });

//		//Loop through result strings with For Each.
//		string fileName = parts[parts.Count() - 1];

//		return fileName;

//	}

//	public List<ViewFamilyType> getAllViewTypes(Document m_doc)
//	{
//		//get list of view types
//		FilteredElementCollector m_colVT = new FilteredElementCollector(m_doc);
//		m_colVT.OfClass(typeof(ViewFamilyType));

//		List<ViewFamilyType> m_vt = new List<ViewFamilyType>();
//		foreach (ViewFamilyType x in m_colVT.ToElements()) {
//			m_vt.Add(x);
//		}

//		return m_vt;

//	}

//	public ElementId getDraftingViewFamilyType(Document curDoc)
//	{
//		ElementId functionReturnValue = null;
//		//get list of view types
//		List<ViewFamilyType> vTypes = getAllViewTypes(curDoc);

//		foreach (ViewFamilyType x in vTypes) {
//			if (x.ViewFamily == ViewFamily.Drafting) {
//				return x.Id;
//				return functionReturnValue;
//			}
//		}

//		return null;
//		return functionReturnValue;

//	}
//}
