using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;

namespace OATools2018.Test
{
    public partial class frmLoadResource : Form
    {
        public frmLoadResource()
        {
            InitializeComponent();

            try
            {




                System.Reflection.Assembly thisExe;
                thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream file = thisExe.GetManifestResourceStream("OATools2018.Resources.bmp.bmp_32x32_initialize.bmp");
                this.picbxTest1.Image = Image.FromStream(file);

                //picbxTest1.Image = bmpTest1;
            }
            catch (Exception)
            {
                //show errer if no icon can be loaded
                TaskDialog.Show("Error", "Error accessing resources!");
            }


        }
    }
}

//This code will display a list of all resurce names

//System.Reflection.Assembly thisExe;
//thisExe = System.Reflection.Assembly.GetExecutingAssembly();
//thisExe = System.Reflection.Assembly.GetExecutingAssembly();
//string[] resources = thisExe.GetManifestResourceNames();
//string list = "";

//// Build the string of resources.
//foreach (string resource in resources)
//    list += resource + "\r\n";

//TaskDialog.Show("Test", list);