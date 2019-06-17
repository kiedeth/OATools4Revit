using OATools2018Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.CommonTools.CopyLinkedProjectInfo
{
    public partial class frmListLinkedElements : Form
    {
        public frmListLinkedElements(
          List<ElementData> a)
        {
            InitializeComponent();
            dataGridView1.DataSource = a;
        }                
    }
}
