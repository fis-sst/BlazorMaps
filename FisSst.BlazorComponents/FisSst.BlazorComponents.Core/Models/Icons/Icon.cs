using Microsoft.JSInterop;

namespace FisSst.BlazorMaps.Models
{
    public class Icon : JsReferenceBase
    {
        internal Icon(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
