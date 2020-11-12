using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class Polyline : Path
    {
        private readonly string toGeoJSON = "toGeoJSON";
        private readonly string setLatLngs = "setLatLngs";
        private readonly string isEmpty = "isEmpty";
        private readonly string getCenter = "getCenter";
        private readonly string addLatLng = "addLatLng";

        internal Polyline(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            EventedJsInterop = eventedJsInterop;
            JsReference = jsReference;
        }

        public async Task<object> ToGeoJSON()
        {
            return await this.JsReference.InvokeAsync<object>(toGeoJSON);
        }

        public async Task<Polyline> SetLatLngs(IEnumerable<LatLng> latLngs)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(setLatLngs, latLngs);
            return this;
        }

        public async Task<bool> IsEmpty()
        {
            return await this.JsReference.InvokeAsync<bool>(isEmpty);
        }

        public async Task<LatLng> GetCenter()
        {
            return await this.JsReference.InvokeAsync<LatLng>(getCenter);
        }

        public async Task<Polyline> AddLatLng(LatLng latLng)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(addLatLng, latLng);
            return this;
        }

        public async Task<Polyline> AddLatLng(LatLng latLng, IEnumerable<LatLng> latLngs)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(addLatLng, latLng, latLngs);
            return this;
        }
    }
}
