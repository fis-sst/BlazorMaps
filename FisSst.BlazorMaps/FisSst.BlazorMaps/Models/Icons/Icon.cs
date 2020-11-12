using Microsoft.JSInterop;

namespace FisSst.BlazorMaps
{
    public class Icon : JsReferenceBase
    {
        internal Icon(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
