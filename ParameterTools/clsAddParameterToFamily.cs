
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using OATools2018.ParameterTools;
using OATools2018.ParameterTools.PCast;

namespace OATools2018.ParameterTools
{
    class clsAddParameterToFamily
    {
        bool succeeded;
        private Autodesk.Revit.ApplicationServices.Application m_app;
        private FamilyManager m_manager = null;
        


        public bool AddParameters(ExternalDefinition def)
        {
            // add the loaded family parameters to the family
            //bool succeeded = AddFamilyParameter();
            //if (!succeeded)
            //{
            //    return false;
            //}

            // add the loaded shared parameters to the family
            succeeded = addSharedParameter(def);
            if (!succeeded)
            {
                return false;
            }

            return true;
        }

        private bool addSharedParameter(ExternalDefinition def)
        {
            // check whether the parameter already exists in the document
            FamilyParameter param = m_manager.get_Parameter(def.Name);
            if (null != param)
            {
                return false;
            }
            try
            {
                m_manager.AddParameter(def, def.ParameterGroup, true);
            }
            catch (System.Exception e)
            {
                MessageManager.MessageBuff.AppendLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
