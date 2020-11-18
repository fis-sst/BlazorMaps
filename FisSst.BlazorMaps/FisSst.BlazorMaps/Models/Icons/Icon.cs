using Microsoft.JSInterop;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Icon can be a graphical representation of an object on a map.
    /// </summary>
    public class Icon : JsReferenceBase
    {
        internal Icon(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
