////
//// Created by SharpDevelop.
//// User: michael
//// Date: 7/8/2015
//// Time: 10:32 PM
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

//public partial class frmImportDWG
//{
//	public frmImportDWG()
//	{
//		// The Me.InitializeComponent call is required for Windows Forms designer support.
//		this.InitializeComponent();

//		//set drop-downs
//		this.cmbColors.SelectedIndex = 1;
//		this.cmbInsertType.SelectedIndex = 1;
//		this.cmbPositioning.SelectedIndex = 0;

//	}


//	public void Button1Click(object sender, System.EventArgs e)
//	{
//		openFileDialog1.Title = "Select DWG files to import";
//		openFileDialog1.Multiselect = true;

//		openFileDialog1.ShowDialog();

//		openFileDialog1.Filter = "DWG Files (*.dwg)|*.dwg";
//		openFileDialog1.FilterIndex = 1;

//	}

//	public void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
//	{
//		//update list box with filenames
//		foreach (string curFile in openFileDialog1.FileNames) {
//			//add file to list box
//			lbFiles.Items.Add(curFile);
//		}
//	}

//	public list<string> getSelectedDWGs()
//	{
//		List<string> DWGList = new List<string>();

//		//return list of selected DWGs
//		for (int i = 0; i <= lbFiles.Items.Count - 1; i++) {
//			//add current DWG to list
//			DWGList.Add(lbFiles.Items[i].ToString());
//		}

//		return DWGList;
//	}

//	public string getColorSetting()
//	{
//		return cmbColors.SelectedItem.ToString();
//	}

//	public string getPosSetting()
//	{
//		return cmbPositioning.SelectedItem.ToString();
//	}

//	public string getInsertType()
//	{
//		return cmbInsertType.SelectedItem.ToString();
//	}
//}
