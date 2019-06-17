
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
using System.Windows.Forms;
using OATools2018.CommonTools.DeleteUnusedRefPlanes;
using System.Threading;
using OATools2018.CommonTools;
using OATools2018.CommonTools.CopyProjectInfoFromLink;
using OATools2018.CommonTools.CopyWallType;
#endregion // Namespaces

namespace OATools2018.CommonTools.MyProject
{
    public partial class frmMyProject : System.Windows.Forms.Form
    {
        ExternalCommandData m_commandData;
        string m_message;
        ElementSet m_elements;

        public frmMyProject(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_commandData = commandData;
            m_message = message;
            m_elements = elements;

            InitializeComponent();
        }

        private void btnDeleteRefPlanes_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;

            bool progress = showProgress(50);

            cmdDeleteUnusedRefPlanes cmd = new cmdDeleteUnusedRefPlanes();
            cmd.Execute(m_commandData, ref m_message, m_elements);

            this.Close();
           
        }

        frmProgress progressDialog = new frmProgress();
        private bool showProgress(int time)
        {
            Thread backgroundThread1 = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(time);

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    progressDialog.UpdateProgress(i);

                    i++;
                }
                progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));

            }));
            backgroundThread1.Start();

            progressDialog.ShowDialog();

            return true;
        }

        private void btnCopyProjectInfoFromLink_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            bool progress = showProgress(50);

            OATools2018Commands.CmdLinkedFileElements cmd = new OATools2018Commands.CmdLinkedFileElements();
            cmd.Execute(m_commandData, ref m_message, m_elements);



            this.Close();
        }

        private void btnGetLinkedElements_Click(object sender, EventArgs e)
        {
            cmdLinkedFileElements cmd = new cmdLinkedFileElements();
            cmd.Execute(m_commandData, ref m_message, m_elements);
        }

        private void btnCopyWallType_Click(object sender, EventArgs e)
        {
            cmdCopyWallType cmd = new cmdCopyWallType();
            cmd.Execute(m_commandData, ref m_message, m_elements);
        }
    }
}

