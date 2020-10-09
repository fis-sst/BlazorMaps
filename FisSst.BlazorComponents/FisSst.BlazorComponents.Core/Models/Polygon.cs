using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;

namespace FisSst.Maps.Models
{
    public class Polygon : Polyline
    {
        internal Polygon(JSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base(jsReference, eventedJsInterop)
        {
        }
    }
}
