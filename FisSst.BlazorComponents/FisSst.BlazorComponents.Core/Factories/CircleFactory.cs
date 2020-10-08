using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class CircleFactory : ICircleFactory
    {
        private readonly string create = "L.circle";
        private readonly IJSRuntime jsRuntime;

        public CircleFactory(
            IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<Circle> Create(LatLng latLngs)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            return new Circle(jsReference);
        }

        public async  Task<Circle> Create(LatLng latLngs, CircleOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            return new Circle(jsReference);
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLngs, Map map)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs);
            Circle circle = new Circle(jsReference);
            await circle.AddTo(map);
            return circle;
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLngs, Map map, CircleOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, latLngs, options);
            Circle circle = new Circle(jsReference);
            await circle.AddTo(map);
            return circle;
        }
    }
}
