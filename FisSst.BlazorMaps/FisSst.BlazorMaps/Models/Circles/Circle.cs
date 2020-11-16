using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class Circle : CircleMarker
    {
        private readonly string setRadius = "setRadius";

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
