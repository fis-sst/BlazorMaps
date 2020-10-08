using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class PolylineFactory : IPolylineFactory
    {
        private readonly string create = "L.polyline";
        private readonly IJSRuntime jsRuntime;

        public PolylineFactory(
            IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<Polyline> Create(IEnumerable<LatLng> latLngs)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            return new Polyline(jsReference);
        }

        public async  Task<Polyline> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            return new Polyline(jsReference);
        }

        public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            Polyline polyline = new Polyline(jsReference);
            await polyline.AddTo(map);
            return polyline;
        }

        public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            Polyline polyline = new Polyline(jsReference);
            await polyline.AddTo(map);
            return polyline;
        }
    }
}
