'
' Created by SharpDevelop.
' User: michael
' Date: 2/4/2015
' Time: 11:13 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Autodesk.Revit.UI
Imports Autodesk.Revit.DB
Imports Autodesk.Revit.UI.Selection
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics

<Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)> _
<Autodesk.Revit.DB.Macros.AddInId("FE9B398F-B0E3-412C-8328-FC1D92221E12")> _
Partial Public Class ThisDocument

    Public Sub ImportDWGsToDraftingViews()
    	'Get the current document
		Dim curDoc As Document = Me.Application.ActiveUIDocument.Document
		Dim counter As Integer = 0
		
		'open form
		Using curForm As New frmImportDWG()
			'show form
			curForm.ShowDialog
			
			If curForm.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
				'Result.Cancelled
			Else
				'get selected DWG files
				Dim drawingList As List(Of String) = curForm.getSelectedDWGs
				
				Using curTrans As New Transaction(curDoc, "Import DWGs to Drafting View")
					If curTrans.Start = TransactionStatus.Started Then
						'loop through DWGs, create drafting view and insert
						For Each curDWG As String In drawingList
							
							'get view family type for drafting view
							Dim curVFT As ElementId = getDraftingViewFamilyType(curDoc)
							
							'create drafting view
							Dim curView As View = ViewDrafting.Create(curDoc, curVFT)
							
							'rename drafting view to DWG filename
							Dim tmpName As String = getFilenameFromPath(curDWG)
							Dim viewName As String = tmpName.Substring(0, tmpName.Length - 4)
							
							Try
								curView.Name = viewName
							Catch ex As Exception
								TaskDialog.Show("Error", "There is already a drafting view named " & viewName & " in this project file. The view will be named " & curView.Name & " instead.")
							End Try
							
							'set insert settings
							Dim curImportOptions As New DWGImportOptions
							
							Select Case curForm.getColorSetting
								Case "Invert"
									curImportOptions.ColorMode = ImportColorMode.Inverted
								Case "Preserve"
									curImportOptions.ColorMode = ImportColorMode.Preserved
								Case Else
									curimportoptions.ColorMode = ImportColorMode.BlackAndWhite
							End Select
							
							Select Case curForm.getPosSetting
								Case "Origin to Origin"
									curImportOptions.Placement = ImportPlacement.Origin
									
								Case "Center to Center"
									curImportOptions.Placement = ImportPlacement.Centered
							End Select
							
							'import / link current DWG to current view
							Dim curLinkID As ElementID = Nothing
							
							If curForm.getInsertType = "Link" Then
								curDoc.Link(curDWG, curImportOptions, curView, curLinkID)
								counter = counter + 1
							Else
								curDoc.Import(curDWG, curImportOptions, curView, curLinkID)
								counter = counter + 1
							End If 
						Next
					End If
							
					'commit changes
					curTrans.Commit
				End Using
			End If 
		End Using
		
		'alert user
		TaskDialog.Show("Complete", "Inserted " & counter & " DWG files.")
	
    End Sub
    
    Private function getFilenameFromPath(filePath As String) As String
    	'Split the string on the backslash character.
		Dim parts As String() = filePath.Split(New Char() {"\"c})

		'Loop through result strings with For Each.
		Dim fileName As String = parts(parts.Count -1)
		
		Return fileName
		
    End Function
    
    Public function getAllViewTypes(m_doc As Document) As List(Of ViewFamilyType)
		'get list of view types
		Dim m_colVT As New FilteredElementCollector(m_doc)
		m_colVT.OfClass(GetType(ViewFamilyType))
		
		Dim m_vt As New List(Of ViewFamilyType)
		For Each x As ViewFamilyType In m_colVT.ToElements
			m_vt.Add(x)
		Next
		
		Return m_vt
		
    End Function
    
    Public function getDraftingViewFamilyType(curDoc As Document) As ElementId
		'get list of view types
		Dim vTypes As List(Of ViewFamilyType) = getAllViewTypes(curDoc)
	
		For Each x As ViewFamilyType In vTypes
			If x.ViewFamily = ViewFamily.Drafting Then
				Return x.Id
				Exit Function
			End If
		Next
		
		Return Nothing
		
	End Function
End Class
