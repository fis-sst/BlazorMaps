using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class CircleMarkerFactory : ICircleMarkerFactory
    {
        private const string create = "L.circleMarker";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public CircleMarkerFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<CircleMarker> Create(LatLng latLng)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng);
            return new CircleMarker(jsReference, this.eventedJsInterop);
        }

        public async  Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng, options);
            return new CircleMarker(jsReference, this.eventedJsInterop);
        }

        public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map)
        {
            CircleMarker circleMarker = await this.Create(latLng);
            await circleMarker.AddTo(map);
            return circleMarker;
        }

        public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options)
        {
            CircleMarker circleMarker = await this.Create(latLng, options);
            await circleMarker.AddTo(map);
            return circleMarker;
        }
    }
}
