using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools.DNotes
{
    public partial class frmCreateDNote : System.Windows.Forms.Form
    {
        public frmCreateDNote(string sheetNumber)
        {
            InitializeComponent();



            SetSheetNumber(sheetNumber);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void SetSheetNumber(string v)
        {
            tbxSheet_number.Text = v;
        }

        //Declare a Static variable
        public static string DNoteNumberInput = string.Empty;
        public static string DNoteSheetInput = string.Empty;
        public static string DNoteTextInput = string.Empty;

        //Set textBox Value to this variable on any event


        private void tbxDNoteNumber_TextChanged(object sender, EventArgs e)
        {
            DNoteNumberInput = tbxDNoteNumber.Text;
        }

        private void tbxSheet_number_TextChanged(object sender, EventArgs e)
        {
            DNoteSheetInput = tbxSheet_number.Text;
        }

        private void txbDNoteText_TextChanged(object sender, EventArgs e)
        {
            DNoteTextInput = tbxDNoteText.Text;
        }
    }
}
