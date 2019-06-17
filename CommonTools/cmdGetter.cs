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
using System.IO;
using System.Data;
using OATools2018;
using OATools2018.Utilities;
using System.Windows.Forms;
using System.Reflection;
#endregion // Namespaces

namespace OATools2018.CommonTools.Getter
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class cmdGetter : IExternalCommand
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

        public static string GetPathFromSettings()
        {
            //read the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");



            return _sourceProjectPath;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //set the vars
            m_commandData = commandData;
            m_message = message;
            m_elements = elements;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            //show the form
            frmGetter frm = new frmGetter(commandData, ref message, elements);
            frm.ShowDialog();



            return Result.Succeeded;
        }

        //get and save the source project location


        public static string SourceProject(bool resetPath, string pathOrName)
        {
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string path;
            string name;

            if (resetPath == true)
            {
                //Clear the setting
                cls.UpdateSetting("<GETTER_SOURCE_PROJECT>", "");
            }

            //read the settings file            
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");
            if (_sourceProjectPath != "")
            {
                name = Path.GetFileName(_sourceProjectPath);

                if (pathOrName == "Name")
                {
                    return name;
                }
                if (pathOrName == "Path")
                {
                    return _sourceProjectPath;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                try
                {

                    //get the file path and name
                    path = OAT_Utilities.oat_OpenFileDialog("rvt");
                    name = Path.GetFileName(path);

                    //Write the new path to the settings file
                    cls.UpdateSetting("<GETTER_SOURCE_PROJECT>", path);

                    if (pathOrName == "Name")
                    {
                        return name;
                    }
                    if (pathOrName == "Path")
                    {
                        return path;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public static DataSet dtSet;

        public static DataTable createCatDataTable()
        {
            //create the new datatable
            DataTable catTable = new DataTable("Categories");
            DataColumn dtColumn;
            DataRow dtRow;
            //create the ID column
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.Int32");
            dtColumn.ColumnName = "ID";
            dtColumn.Caption = "id";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            //Add column to DataColumnCollection
            catTable.Columns.Add(dtColumn);

            //Create catName column
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "Category";
            dtColumn.Caption = "Categories";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            //Add catName column to table
            catTable.Columns.Add(dtColumn);

            //Make the ID column the primary key
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = catTable.Columns["ID"];
            catTable.PrimaryKey = PrimaryKeyColumns;

            //Instantiate the Dataset variable
            dtSet = new DataSet("Categories");

            //Add the catTable to the DataSet
            dtSet.Tables.Add(catTable);

            //Add row to the catTable
            dtRow = catTable.NewRow();
            dtRow["ID"] = 1;
            dtRow["Category"] = "Walls";
            catTable.Rows.Add(dtRow);
            //Add row to the catTable
            dtRow = catTable.NewRow();
            dtRow["ID"] = 2;
            dtRow["Category"] = "Line Types";
            catTable.Rows.Add(dtRow);
            //Add row to the catTable
            dtRow = catTable.NewRow();
            dtRow["ID"] = 3;
            dtRow["Category"] = "Title Blocks";
            catTable.Rows.Add(dtRow);

            //return the table
            return catTable;
        }

        public static DataTable CreateEmptyDataTable(string tableName)
        {
            //create the new datatable
            DataTable myTable = new DataTable(tableName);
            DataColumn dtColumn;

            //create the ID column
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.Int32");
            dtColumn.ColumnName = "ID";
            dtColumn.Caption = "id";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            //Add ID column to DataColumnCollection
            myTable.Columns.Add(dtColumn);

            //Create Name column
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "name";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            //Add Name column to table
            myTable.Columns.Add(dtColumn);

            //Make the ID column the primary key
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = myTable.Columns["ID"];
            myTable.PrimaryKey = PrimaryKeyColumns;

            return myTable;
        }



        //search the source project for the selected catagory
        public DataTable getSelectedCatagory_dataTable(ExternalCommandData m_commandData)
        {
            UIApplication uiapp = m_commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;



            //read the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");

            //DataTable to hold the gotton catagory
            DataTable _DT_gottonCatagory = new DataTable();
            _DT_gottonCatagory = CreateEmptyDataTable("Gotton Catagory");
            DataRow dtRow;

            //var to hold the selected type
            string _userSelectedType;

            //open source project
            Document _openedSourceDoc = app.OpenDocumentFile(_sourceProjectPath);

            //Find system family to copy, e.g. using a named wall type.
            WallType _selectedWallType = null;

            //Element collector
            FilteredElementCollector sourceWallTypes = new FilteredElementCollector(_openedSourceDoc).OfClass(typeof(WallType));

            //loop thru the types and add them to the DataTable
            int _counter = 0;
            foreach (WallType wt in sourceWallTypes)
            {
                dtRow = _DT_gottonCatagory.NewRow();
                dtRow["ID"] = _counter;
                dtRow["Name"] = wt.Name;
                _DT_gottonCatagory.Rows.Add(dtRow);

                //increase the counter
                _counter++;
            }

            //return the DT
            return _DT_gottonCatagory;

        }

        //search the source project for titleBlocks
        public DataTable getTitleblocks_dataTable(ExternalCommandData m_commandData)
        {
            UIApplication uiapp = m_commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;



            //read the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");

            //DataTable to hold the gotton catagory
            DataTable _DT_gottonCatagory = new DataTable();
            _DT_gottonCatagory = CreateEmptyDataTable("Gotton Catagory");
            DataRow dtRow;

            //var to hold the selected type
            string _userSelectedType;

            //open source project
            Document _openedSourceDoc = app.OpenDocumentFile(_sourceProjectPath);

            //Find system family to copy, e.g. using a named wall type.
            WallType _selectedWallType = null;

            //Element collector
            FilteredElementCollector sourceWallTypes = new FilteredElementCollector(_openedSourceDoc).OfClass(typeof(WallType));

            //loop thru the types and add them to the DataTable
            int _counter = 0;
            foreach (WallType wt in sourceWallTypes)
            {
                dtRow = _DT_gottonCatagory.NewRow();
                dtRow["ID"] = _counter;
                dtRow["Name"] = wt.Name;
                _DT_gottonCatagory.Rows.Add(dtRow);

                //increase the counter
                _counter++;
            }

            //return the DT
            return _DT_gottonCatagory;

        }

        private void cloneDatagrid(DataGridView dgvSource, DataGridView dgvDestination)
        {

            try
            {
                foreach (DataGridViewColumn col in dgvSource.Columns)
                {
                    dgvDestination.Columns.Add(col.Clone() as DataGridViewColumn);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void _getSelectedTypes_dataTable(DataGridView dgvSource, DataGridView dgvDestination)
        {
            if (dgvDestination.Columns.Count == 0)
            {
                cloneDatagrid(dgvSource, dgvDestination);
            }
            if (dgvSource.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow sRow in dgvSource.SelectedRows)
                {
                    if (dgvDestination.Rows.Count == 0)
                    {
                        object[] rowData = new object[sRow.Cells.Count];
                        for (int i = 0; i < rowData.Length; i++)
                        {
                            rowData[i] = sRow.Cells[i].Value;
                        }
                        dgvDestination.Rows.Add(rowData);
                    }
                    else
                    {
                        //Check to make sure ID is unique here

                        object[] rowData = new object[sRow.Cells.Count];
                        for (int i = 0; i < rowData.Length; i++)
                        {
                            rowData[i] = sRow.Cells[i].Value;
                        }
                        dgvDestination.Rows.Add(rowData);
                    }
                }
                dgvSource.Refresh();
            }
            else
            {
                TaskDialog.Show("Hey!", "Nothing selected to add to cart, select some items to add.");
            }
        }

        //get type from name
        WallType getTheTypeMatchingName(String wallName)
        {
            WallType wallTypeFromName = null;



            return wallTypeFromName;
        }

        public bool GetTheTypes(ExternalCommandData commandData, String _selectedWallTypeName)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            //read the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");

            //open source project
            Document _openedSourceDoc = app.OpenDocumentFile(_sourceProjectPath);


            WallType _selectedWallType = null;

            //get the wall types in the source doc
            FilteredElementCollector sourceWallTypes = new FilteredElementCollector(_openedSourceDoc).OfClass(typeof(WallType));

            foreach (WallType wt in sourceWallTypes)
            {
                if (wt.Name == _selectedWallTypeName)
                {
                    //the name matches
                    _selectedWallType = wt;
                }
            }


            //Create a wall type in the current document

            using (Transaction tx = new Transaction(doc, "Get Types"))
            {
                tx.Start("Transfer Wall Type");

                WallType newWallType = null;

                //get the wall types in the current doc
                FilteredElementCollector wallTypes = new FilteredElementCollector(doc).OfClass(typeof(WallType));

                foreach (WallType wt in wallTypes)
                {
                    if (wt.Kind == _selectedWallType.Kind)
                    {
                        newWallType = wt.Duplicate(_selectedWallTypeName) as WallType;

                        TaskDialog.Show("Wall Created", "The selected wall has been created.");

                        break;
                    }
                }


                // Assign parameter values from source wall type:

#if COPY_INDIVIDUAL_PARAMETER_VALUE
    // Example: individually copy the "Function" parameter value:

    BuiltInParameter bip = BuiltInParameter.FUNCTION_PARAM;
    string function = wallType.get_Parameter( bip ).AsString();
    Parameter p = newWallType.get_Parameter( bip );
    p.Set( function );

                
                BuiltInParameter bip = BuiltInParameter.WALL_ATTR_WIDTH_PARAM;
                Double _selectedWidth = _selectedWallType.get_Parameter(bip).AsDouble();
                Parameter newWallWidth = newWallType.get_Parameter(bip);
                newWallWidth.Set(_selectedWidth);

#endif // COPY_INDIVIDUAL_PARAMETER_VALUE



                Parameter p = null;

                foreach (Parameter p2 in newWallType.Parameters)
                {
                    Definition d = p2.Definition;

                    if (p2.IsReadOnly)
                    {
                        System.Diagnostics.Debug.Print(string.Format("Parameter '{0}' is read-only.", d.Name));
                    }
                    else
                    {
                        p = newWallType.get_Parameter(d);

                        if (null == p)
                        {
                            System.Diagnostics.Debug.Print(string.Format("Parameter '{0}' not found on source wall type.", d.Name));
                        }
                        else
                        {
                            if (p.StorageType == StorageType.ElementId)
                            {
                                // Here you have to find the corresponding
                                // element in the target document.

                                System.Diagnostics.Debug.Print(string.Format("Parameter '{0}' is an element id.", d.Name));
                            }
                            else
                            {
                                if (p.StorageType == StorageType.String)
                                {
                                    p2.Set(p.AsString());
                                }
                                else if (p.StorageType == StorageType.Double)
                                {
                                    p2.Set(p.AsDouble());
                                }
                                else if (p.StorageType == StorageType.Integer)
                                {
                                    p2.Set(p.AsInteger());
                                }
                                System.Diagnostics.Debug.Print(string.Format("Parameter '{0}' copied.", d.Name));
                            }
                        }
                    }
                }

                TaskDialog.Show("Parameter Set", "The walls parameters have been set.");

                MemberInfo[] memberInfos = newWallType.GetType().GetMembers(BindingFlags.GetProperty);

                foreach (MemberInfo m in memberInfos)
                {
                    // Copy the writable property values here.
                    // As there are no property writable for
                    // Walltype, I ignore this process here.
                }

                tx.Commit();
                tx.Dispose();
            }

            return true;
        }



        public bool GetTitleblocks(ExternalCommandData commandData, String _selectedWallTypeName)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection selection = uidoc.Selection;

            //read the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string _sourceProjectPath = cls.GetSetting("<GETTER_SOURCE_PROJECT>");

            //open source project
            Document _openedSourceDoc = app.OpenDocumentFile(_sourceProjectPath);


            WallType _selectedWallType = null;

            //get the wall types in the source doc
            FilteredElementCollector sourceWallTypes = new FilteredElementCollector(_openedSourceDoc).OfClass(typeof(ViewSheet));

            foreach (WallType wt in sourceWallTypes)
            {
                if (wt.Name == _selectedWallTypeName)
                {
                    //the name matches
                    _selectedWallType = wt;
                }
            }



            return true;
        }
    }
}




