using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Models
{
    public class Circle : CircleMarker
    {
        private readonly string setRadius = "setRadius";
        private readonly string getBounds = "getBounds";

        internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base (jsReference, eventedJsInterop)
        {
        }

        public async Task<Circle> SetRadius(double radius)
        {
            await this.JsReference.InvokeAsync<Circle>(setRadius, radius);
            return this;
        }

        //TO DO
        //public async Task<LatLngBounds> GetBounds()
        //{
        //    return await this.JsReference.InvokeAsync<LatLngBounds>(getBounds);
        //}
    }
}
