using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using OATools;

namespace OATools.Utilities
{
    public class clsLoadIcon
    {
        #region Load bitmap from embedded resources
        /// <summary>
        /// Load a new icon bitmap from embedded resources.
        /// For the BitmapImage, make sure you reference 
        /// WindowsBase and PresentationCore, and import 
        /// the System.Windows.Media.Imaging namespace. 
        /// 
        /// System.Reflection.Assembly exe;
        /// exe = System.Reflection.Assembly.GetExecutingAssembly();
        /// 
        /// ussage example
        /// 
        /// d.LargeImage = NewBitmapImage( thisExe, "ImgStringSearch32.png" );
        /// 
        /// </summary>
        #endregion

        public static string _namespace_prefix = typeof(App).Namespace + "." + "Resources" + "." + "Icons" + ".";

        public BitmapImage NewBitmapImage(Assembly a, string imageName)
        {
            
            Stream s = a.GetManifestResourceStream( _namespace_prefix + imageName);

            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.StreamSource = s;
            img.EndInit();

            return img;
        }


    }
}
