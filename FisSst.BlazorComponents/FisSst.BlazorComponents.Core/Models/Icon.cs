using Microsoft.JSInterop;

namespace FisSst.Maps.Models
{
    public class Icon : JsReferenceBase
    {
        internal Icon(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
