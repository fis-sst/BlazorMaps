using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class Circle : CircleMarker
    {
        private readonly string setRadius = "setRadius";
        private readonly string getBounds = "getBounds";

        internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base (jsReference, eventedJsInterop)
        {
            JsReference = jsReference;
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
