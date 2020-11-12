using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Models
{
    public class Polyline : Path
    {
        private readonly string toGeoJSON = "toGeoJSON";
        private readonly string getLatLngs = "getLatLngs";
        private readonly string setLatLngs = "setLatLngs";
        private readonly string isEmpty = "isEmpty";
        private readonly string closestLayerPoint = "closestLayerPoint";
        private readonly string getCenter = "getCenter";
        private readonly string getBounds = "getBounds";
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

        //TO DO
        //public async Task<IEnumerable<LatLng>> GetLatLngs()
        //{
        //    return await this.JsReference.InvokeAsync<IEnumerable<LatLng>>(getLatLngs);
        //}

        public async Task<Polyline> SetLatLngs(IEnumerable<LatLng> latLngs)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(setLatLngs, latLngs);
            return this;
        }

        public async Task<bool> IsEmpty()
        {
            return await this.JsReference.InvokeAsync<bool>(isEmpty);
        }

        //TO DO
        //public async Task<Point> ClosestLayerPoint(Point point)
        //{
        //    return await this.JsReference.InvokeAsync<Point>(closestLayerPoint, point);
        //}

        public async Task<LatLng> GetCenter()
        {
            return await this.JsReference.InvokeAsync<LatLng>(getCenter);
        }

        //TO DO
        //public async Task<LatLngBounds> GetBounds()
        //{
        //    return await this.JsReference.InvokeAsync<LatLngBounds>(getBounds);
        //}

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
