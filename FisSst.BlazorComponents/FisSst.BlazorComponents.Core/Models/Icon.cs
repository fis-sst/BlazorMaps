using Microsoft.JSInterop;

namespace FisSst.Maps.Models
{
    public class Icon : JsReferenceBase
    {
        internal Icon(JSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
