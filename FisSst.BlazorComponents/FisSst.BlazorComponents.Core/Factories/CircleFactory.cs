using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class CircleFactory : ICircleFactory
    {
        private readonly string create = "L.circle";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public CircleFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Circle> Create(LatLng latLng)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng);
            return new Circle(jsReference, this.eventedJsInterop);
        }

        public async  Task<Circle> Create(LatLng latLng, CircleOptions options)
        {
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng, options);
            return new Circle(jsReference, this.eventedJsInterop);
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map)
        {
            Circle circle = await this.Create(latLng);
            await circle.AddTo(map);
            return circle;
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options)
        {
            Circle circle = await this.Create(latLng, options);
            await circle.AddTo(map);
            return circle;
        }
    }
}
