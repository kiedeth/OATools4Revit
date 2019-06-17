using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace OATools2018Commands
{
  /// <summary>
  /// Allow selection of elements of type T only.
  /// </summary>
  class JtElementsOfClassSelectionFilter<T> 
    : ISelectionFilter where T : Element
  {
    public bool AllowElement( Element e )
    {
      return e is T;
    }

    public bool AllowReference( Reference r, XYZ p )
    {
      return true;
    }
  }
}
