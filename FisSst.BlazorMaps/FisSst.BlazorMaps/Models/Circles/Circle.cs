using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Circle is a class for drawing circle overlays on a map.
    /// </summary>
    public class Circle : CircleMarker
    {
        private const string setRadius = "setRadius";

        internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base (jsReference, eventedJsInterop)
        {
        }

        public async Task<Circle> SetRadius(double radius)
        {
            await this.JsReference.InvokeAsync<Circle>(setRadius, radius);
            return this;
        }
    }
}
