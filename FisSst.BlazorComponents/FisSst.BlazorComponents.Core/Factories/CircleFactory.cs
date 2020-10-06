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

        public async Task<Circle> Create(LatLng latLngs)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            return new Circle(jsReference, this.eventedJsInterop);
        }

        public async  Task<Circle> Create(LatLng latLngs, CircleOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            return new Circle(jsReference, this.eventedJsInterop);
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLngs, Map map)
        {
            Circle circle = await this.Create(latLngs);
            await circle.AddTo(map);
            return circle;
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLngs, Map map, CircleOptions options)
        {
            Circle circle = await this.Create(latLngs, options);
            await circle.AddTo(map);
            return circle;
        }
    }
}
