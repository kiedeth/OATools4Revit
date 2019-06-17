using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.Filtering
{
    public partial class frmNewFilter : System.Windows.Forms.Form
    {
        #region Class Memeber
        /// <summary>
        /// In-use filter names
        /// </summary>
        ICollection<String> m_inUseFilterNames;

        /// <summary>
        /// New filter name 
        /// </summary>
        private String m_filterName;

        /// <summary>
        /// Get new filter name
        /// </summary>
        public String FilterName
        {
            get { return m_filterName; }
        }
        #endregion

        /// <summary>
        /// Show form for new filter name
        /// </summary>
        /// <param name="inUseNames">Filter names should be excluded.</param>
        public frmNewFilter(ICollection<String> inUseNames)
        {
            InitializeComponent();
            m_inUseFilterNames = inUseNames;
        }

        /// <summary>
        /// Check if input name is valid for new filter, the name should be unique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            // Check name is not empty
            String newName = newFilterNameTextBox.Text.Trim();
            if (String.IsNullOrEmpty(newName))
            {
                frmViewFilters.MyMessageBox("Filter name is empty!");
                newFilterNameTextBox.Focus();
                return;
            }
            //
            // Check if filter name contains invalid characters
            // These character are different from Path.GetInvalidFileNameChars()
            char[] invalidFileChars = { '\\', ':', '{', '}', '[', ']', '|', ';', '<', '>', '?', '\'', '~' };
            foreach (char invalidChr in invalidFileChars)
            {
                if (newName.Contains(invalidChr))
                {
                    frmViewFilters.MyMessageBox("Filter name contains invalid character: " + invalidChr);
                    return;
                }
            }
            // 
            // Check if name is used
            // check if name is already used by other filters
            bool inUsed = m_inUseFilterNames.Contains(newName, StringComparer.OrdinalIgnoreCase);
            if (inUsed)
            {
                frmViewFilters.MyMessageBox("The name you supplied is already in use. Enter a unique name please.");
                newFilterNameTextBox.Focus();
                return;
            }
            m_filterName = newName;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
