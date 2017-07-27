#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections;
#endregion // Namespaces

namespace OATools.ParameterTools
{
    public partial class frmNewSharedParameter : System.Windows.Forms.Form
    {
        public string newParameterName { get; set; }
        public string newDataType { get; set; }
        public string newGUID { get; set; }
        public int  NewGroupID { get; set; }

        public frmNewSharedParameter()
        {
            InitializeComponent();

            cbxDataTypes.DataSource = clsParameterDataTypes.SP_dataTypes();

            //ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions("Instance_ProductDate", ParameterType.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            this.newParameterName = tbxParameterName.Text.ToString();

            this.newDataType = cbxDataTypes.SelectedItem.ToString();

            this.newGUID = Guid.NewGuid().ToString();

            this.NewGroupID = 1;

            this.Close();

        }


    }
}
