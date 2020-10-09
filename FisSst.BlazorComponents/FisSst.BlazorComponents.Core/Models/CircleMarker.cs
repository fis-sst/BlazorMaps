using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class CircleMarker : Path
    {
        private readonly string toGeoJSON = "toGeoJSON";
        private readonly string setLatLng = "setLatLng";
        private readonly string getLatLng = "getLatLng";
        private readonly string setRadius = "setRadius";
        private readonly string getRadius = "getRadius";

        internal CircleMarker(JSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
        }

        public async Task<object> ToGeoJSON()
        {
            return await this.JsReference.InvokeAsync<object>(toGeoJSON);
        }

        public async Task<CircleMarker> SetLatLng(LatLng latLng)
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(setLatLng, latLng);
            return this;
        }

        public async Task<LatLng> GetLatLng()
        {
            return await this.JsReference.InvokeAsync<LatLng>(getLatLng);
        }

        public async Task<CircleMarker> SetRadius(LatLng latLng)
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(setRadius, latLng);
            return this;
        }

        public async Task<double> GetRadius()
        {
            return await this.JsReference.InvokeAsync<double>(getRadius);
        }
    }
}
