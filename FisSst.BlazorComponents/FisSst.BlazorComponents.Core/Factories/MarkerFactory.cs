using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class MarkerFactory : IMarkerFactory
    {
        private readonly string create = "L.marker";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public MarkerFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Marker> Create(LatLng latLng)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLng);
            return new Marker(jsReference, this.eventedJsInterop);
        }

        public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLng);
            Marker marker = new Marker(jsReference, this.eventedJsInterop);
            await marker.AddTo(map);
            return marker;
        }
    }
}
