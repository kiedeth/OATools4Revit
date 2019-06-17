using System.Windows.Forms;

namespace OATools2018Commands
{
  public partial class CmdWindowHandleForm : Form
  {
    public CmdWindowHandleForm()
    {
      InitializeComponent();
    }

    public string LabelText
    {
      get
      {
        return label1.Text;
      }
      set
      {
        label1.Text = value;
      }
    }
  }
}
