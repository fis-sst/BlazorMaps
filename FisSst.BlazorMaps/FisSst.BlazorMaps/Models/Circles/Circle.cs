using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// A class for drawing circle overlays on a Map.
    /// </summary>
    public class Circle : CircleMarker
    {
        private const string SetRadiusJsFunction = "setRadius";

        internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base (jsReference, eventedJsInterop)
        {
        }

        public async Task<Circle> SetRadius(double radius)
        {
            await this.JsReference.InvokeAsync<Circle>(SetRadiusJsFunction, radius);
            return this;
        }
    }
}
