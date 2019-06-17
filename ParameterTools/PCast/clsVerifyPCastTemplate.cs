#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using OATools2018.ParameterTools.PCast;
using OATools2018.Utilities;
using System.IO;
#endregion // Namespaces

namespace OATools2018.ParameterTools.PCast
{
    class clsVerifyPCastTemplate
    {
        //Declare the template file path var
        private static string pCastTemplate;

        private static string defaultTemplate = Environment.ExpandEnvironmentVariables("%appdata%") + "/Autodesk/Revit/Addins/2018/OATools2018.bundle/Additional/pCast_Template.pct";


        //Read the template path from the settings file
        public static string pCastFilePathFromSettings()
        {
            //Read the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedPCastFilePath = cls.GetSetting("<PCAST_TEMPLATE_FILE_LOCATION>");
            if (returnedPCastFilePath == "")
            {
                pCastTemplate = defaultTemplate;
            }
            else
            {
                pCastTemplate = returnedPCastFilePath;
            }

            ////Set the template var
            //pCastTemplate = returnedPCastFilePath;

            ////If no template is set set one
            //if (pCastTemplate == null)
            //{
            //    pCastTemplate = defaultTemplate;
            //}

            //Verify template
            if (!VerifyTemplateExists())
            {
                if (CreateTemplateFile())
                {
                }
            }

            //write the template
            if (new FileInfo(pCastTemplate).Length == 0)
            {
                bool writeTemplateFile = createEmptyTemplateFile();

                if (writeTemplateFile)
                {
                    TaskDialog.Show("OA Tools pCast", "No pCast Template could be found. Default pCast Template created at specified location.");
                }

            }

            //return the path
            return pCastTemplate;
        }

        private static bool VerifyTemplateExists()
        {
            if (!File.Exists(pCastTemplate))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CreateTemplateFile()
        {
            File.Create(pCastTemplate).Close();

            if (File.Exists(pCastTemplate))
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool createEmptyTemplateFile()
        {
            FileStream file = new FileStream(pCastTemplate, FileMode.Create, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine("TemplateName" + "\t" + "GUID" + "\t" + "Name" + "\t" + "DataType" + "\t" +
                                    "GroupNumber" + "\t" + "GroupName" + "\t" + "Visible" + "\t" + "InstanceOrType" + "\t" +
                                    "GroupUnder" + "\t" + "Source" + "\t" + "ParamToReplace" + "\t" + "MapToElecConnector" +
                                    "\t" + "Value" + "\t" + "Formula" + "\t" + "SortOrder" + "\t" + "ToolTip" + "\t" + "\t" + "\t" + "\t" + "\t");

                sw.WriteLine("FirstTemplate" + "\t" + "88b2ceac-489a-4412-8375-7686ccc0dd84" + "\t" + "TestName" + "\t" + "Text");
                sw.Flush();
                sw.Close();
            }

            return true;
        }

        //Read the template path from the settings file
        public static string sharedParamFileFromSettings()
        {
            //Read the path from the settings file
            cmdSettingsReadWrite cls = new cmdSettingsReadWrite();
            string returnedPath = cls.GetSetting("<PCAST_PARAMETER_FROM_FILE_PATH>");

            //return the path
            return returnedPath;
        }
    }

}
