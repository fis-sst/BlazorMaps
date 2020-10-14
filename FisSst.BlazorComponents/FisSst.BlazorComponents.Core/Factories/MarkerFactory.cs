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
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng);
            return new Marker(jsReference, this.eventedJsInterop);
        }

        public async Task<Marker> Create(LatLng latLng, MarkerOptions options)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng, options);
            return new Marker(jsReference, this.eventedJsInterop);
        }

        public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map)
        {
            Marker marker = await this.Create(latLng);
            await marker.AddTo(map);
            return marker;
        }

        public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options)
        {
            Marker marker = await this.Create(latLng, options);
            await marker.AddTo(map);
            return marker;
        }
    }
}
