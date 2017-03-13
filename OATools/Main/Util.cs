#region Namespaces
using System;
using System.Diagnostics;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace OATools.Main
{
    class Util
    {
        #region Unit conversion
        const double _convertFootToMm = 12 * 25.4;

        /// <summary>
        /// Convert a given length in millimetres to feet.
        /// </summary>
        public static double MmToFoot(double length)
        {
            return length / _convertFootToMm;
        }
        #endregion // Unit conversion

        #region Formatting
        /// <summary>
        /// Return an English plural suffix for the given
        /// number of items, i.e. 's' for zero or more
        /// than one, and nothing for exactly one.
        /// </summary>
        public static string PluralSuffix(int n)
        {
            return 1 == n ? "" : "s";
        }

        /// <summary>
        /// Return a dot (full stop) for zero
        /// or a colon for more than zero.
        /// </summary>
        public static string DotOrColon(int n)
        {
            return 0 < n ? ":" : ".";
        }

        /// <summary>
        /// Return a string for a real number
        /// formatted to two decimal places.
        /// </summary>
        public static string RealString(double a)
        {
            return a.ToString("0.##");
        }

        /// <summary>
        /// Return a string for an XYZ point
        /// or vector with its coordinates
        /// formatted to two decimal places.
        /// </summary>
        public static string PointString(XYZ p)
        {
            return string.Format("({0},{1},{2})",
              RealString(p.X),
              RealString(p.Y),
              RealString(p.Z));
        }
        #endregion // Formatting

        #region Display a message
        public const string Caption = "O/A Tools";

        public static void InfoMsg(string msg)
        {
            Debug.WriteLine(msg);
            TaskDialog.Show(Caption, msg);
        }

        public static void InfoMsg2(
          string instruction,
          string content)
        {
            Debug.WriteLine(instruction + "\r\n" + content);
            TaskDialog d = new TaskDialog(Caption);
            d.MainInstruction = instruction;
            d.MainContent = content;
            d.Show();
        }

        public static void ErrorMsg(string msg)
        {
            Debug.WriteLine(msg);
            TaskDialog d = new TaskDialog(Caption);
            d.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
            d.MainInstruction = msg;
            d.Show();
        }

        /// <summary>
        /// Return a string describing the given element:
        /// .NET type name,
        /// category name,
        /// family and symbol name for a family instance,
        /// element id and element name.
        /// </summary>
        public static string ElementDescription(
          Element e)
        {
            if (null == e)
            {
                return "<null>";
            }

            // For a wall, the element name equals the
            // wall type name, which is equivalent to the
            // family name ...

            FamilyInstance fi = e as FamilyInstance;

            string typeName = e.GetType().Name;

            string categoryName = (null == e.Category)
              ? string.Empty
              : e.Category.Name + " ";

            string familyName = (null == fi)
              ? string.Empty
              : fi.Symbol.Family.Name + " ";

            string symbolName = (null == fi
              || e.Name.Equals(fi.Symbol.Name))
                ? string.Empty
                : fi.Symbol.Name + " ";

            return string.Format("{0} {1}{2}{3}<{4} {5}>",
              typeName, categoryName, familyName,
              symbolName, e.Id.IntegerValue, e.Name);
        }
        #endregion // Display a message
    }
}
