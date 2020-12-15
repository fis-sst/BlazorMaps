using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class PolygonFactory : IPolygonFactory
    {
        private const string create = "L.polygon";
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
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs);
            return new Polygon(jsReference, this.eventedJsInterop);
        }

        public async Task<Polygon> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs, options);
            return new Polygon(jsReference, this.eventedJsInterop);
        }

        public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
        {
            Polygon polygon = await this.Create(latLngs);
            await polygon.AddTo(map);
            return polygon;
        }

        public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
        {
            Polygon polygon = await this.Create(latLngs, options);
            await polygon.AddTo(map);
            return polygon;
        }
    }
}
