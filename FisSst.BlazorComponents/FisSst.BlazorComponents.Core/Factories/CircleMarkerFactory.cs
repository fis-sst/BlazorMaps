using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class CircleMarkerFactory : ICircleMarkerFactory
    {
        private readonly string create = "L.circleMarker";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public CircleMarkerFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<CircleMarker> Create(LatLng latLngs)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            return new CircleMarker(jsReference, this.eventedJsInterop);
        }

        public async  Task<CircleMarker> Create(LatLng latLngs, CircleMarkerOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            return new CircleMarker(jsReference, this.eventedJsInterop);
        }

        public async Task<CircleMarker> CreateAndAddToMap(LatLng latLngs, Map map)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            CircleMarker circleMarker = new CircleMarker(jsReference, this.eventedJsInterop);
            await circleMarker.AddTo(map);
            return circleMarker;
        }

        public async Task<CircleMarker> CreateAndAddToMap(LatLng latLngs, Map map, CircleMarkerOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            CircleMarker circleMarker = new CircleMarker(jsReference, this.eventedJsInterop);
            await circleMarker.AddTo(map);
            return circleMarker;
        }
    }
}
