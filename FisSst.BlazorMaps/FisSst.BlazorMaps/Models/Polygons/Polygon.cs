using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Polygon is a class for drawing polygon overlays on a map.
    /// </summary>
    public class Polygon : Polyline
    {
        internal Polygon(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base(jsReference, eventedJsInterop)
        {
        }
    }
}
