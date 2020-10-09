using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class PolygonFactory : IPolygonFactory
    {
        private readonly string create = "L.polygon";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public PolygonFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Polygon> Create(IEnumerable<LatLng> latLngs)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            return new Polygon(jsReference, this.eventedJsInterop);
        }

        public async Task<Polygon> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            return new Polygon(jsReference, this.eventedJsInterop);
        }

        public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            Polygon polygon = new Polygon(jsReference, this.eventedJsInterop);
            await polygon.AddTo(map);
            return polygon;
        }

        public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            Polygon polygon = new Polygon(jsReference, this.eventedJsInterop);
            await polygon.AddTo(map);
            return polygon;
        }
    }
}
