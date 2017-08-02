#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools.ParameterTools.PCast;
using OATools.Utilities;
using System.IO;
using System.Windows.Forms;
using System.Data;
#endregion // Namespaces

namespace OATools.ParameterTools.PCast
{
    public static class ClsInitDGVs
    {
        //Create the reading class
        static clsReadTemplateFile readingClass = new clsReadTemplateFile();
        //Declare the template path var
        static string verifiedPCastTemplate = null;


        public static bool initDGV(DataGridView dgv, BindingSource path)
        {
            //Verify the template file and set its path
            verifiedPCastTemplate = clsVerifyPCastTemplate.pCastFilePathFromSettings();

            //set the selected bs data source to the raw template dt
            path.DataSource = readingClass.GetDataSourceFromFile(verifiedPCastTemplate);

            //Insert if condition here
            if (1 > 0)
            {
                //set the datagridview source
                dgv.DataSource = path;

                dgv.AutoGenerateColumns = false;

                int curCol = 0;
                int numberOfCols = 21;

                //Turn all cols off
                while (curCol < numberOfCols)
                {
                    dgv.Columns[curCol].Visible = false;

                    curCol++;
                }

                //Turn some cols back on
                dgv.Columns[2].Visible = true;
                dgv.Columns[3].Visible = true;


                return true;
            }

            return false;
        }

        public static bool hideDgvCols(DataGridView dgv)
        {
            //Verify the template file and set its path
            verifiedPCastTemplate = clsVerifyPCastTemplate.pCastFilePathFromSettings();


            //Insert if condition here
            if (1 > 0)
            {

                dgv.AutoGenerateColumns = false;

                int curCol = 0;
                int numberOfCols = 30;

                //Turn all cols off
                while (curCol < numberOfCols)
                {
                    dgv.Columns[curCol].Visible = false;

                    curCol++;
                }

                //Turn some cols back on
                dgv.Columns[2].Visible = true;
                dgv.Columns[3].Visible = true;


                return true;
            }

            return false;
        }
    }
}
