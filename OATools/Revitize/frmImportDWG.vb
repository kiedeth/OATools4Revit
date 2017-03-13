''
'' Created by SharpDevelop.
'' User: michael
'' Date: 7/8/2015
'' Time: 10:32 PM
'' 
'' To change this template use Tools | Options | Coding | Edit Standard Headers.
''
'Imports System
'Imports Autodesk.Revit.UI
'Imports Autodesk.Revit.DB
'Imports Autodesk.Revit.UI.Selection
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Diagnostics

'Public Partial Class frmImportDWG
'	Public Sub New()
'		' The Me.InitializeComponent call is required for Windows Forms designer support.
'		Me.InitializeComponent()

'		'set drop-downs
'		Me.cmbColors.SelectedIndex = 1
'		Me.cmbInsertType.SelectedIndex = 1
'		Me.cmbPositioning.SelectedIndex = 0

'	End Sub


'    Sub Button1Click(sender As Object, e As System.EventArgs)
'        openFileDialog1.Title = "Select DWG files to import"
'        openFileDialog1.Multiselect = True

'        openFileDialog1.ShowDialog()

'        openFileDialog1.Filter = "DWG Files (*.dwg)|*.dwg"
'        openFileDialog1.FilterIndex = 1

'    End Sub

'    Sub OpenFileDialog1FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)
'		'update list box with filenames
'		For Each curFile As String In openFileDialog1.FileNames
'			'add file to list box
'			lbFiles.Items.Add(curFile)
'		Next
'	End Sub

'	Public Function getSelectedDWGs() As list(Of String)
'		Dim DWGList As New list(Of String)

'		'return list of selected DWGs
'		For i As Integer = 0 To lbFiles.items.Count - 1
'			'add current DWG to list
'			DWGList.Add(lbFiles.Items.Item(i).ToString)
'		Next

'		Return DWGList
'	End Function

'	Public Function getColorSetting As String
'		Return cmbColors.SelectedItem.ToString
'	End Function

'	Public Function getPosSetting As String
'		Return cmbPositioning.SelectedItem.ToString
'	End Function

'	Public Function getInsertType As String
'		Return cmbInsertType.SelectedItem.ToString
'	End Function
'End Class
