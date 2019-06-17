using System.Collections.Generic;
using System.Windows.Forms;

namespace OATools2018Commands
{
  public partial class CmdLinkedFileElementsForm : Form
  {
    public CmdLinkedFileElementsForm(
      List<ElementData> a )
    {
      InitializeComponent();
      //dataGridView1.DataSource = a;
    }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CmdLinkedFileElementsForm
            // 
            this.ClientSize = new System.Drawing.Size(1471, 253);
            this.Name = "CmdLinkedFileElementsForm";
            this.ResumeLayout(false);

        }
    }
}