using Microsoft.JSInterop;

namespace FisSst.Maps.Models
{
    public class Polygon : Polyline
    {
        internal Polygon(JSObjectReference jsReference) : base(jsReference)
        {
            JsReference = jsReference;
        }
    }
}
