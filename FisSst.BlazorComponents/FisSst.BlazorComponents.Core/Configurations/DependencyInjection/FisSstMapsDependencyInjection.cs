using FisSst.BlazorComponents.Core.JsInterops;
using FisSst.Maps.Factories;
using FisSst.Maps.JsInterops;
using FisSst.Maps.JsInterops.Base;
using Microsoft.Extensions.DependencyInjection;

namespace FisSst.Maps.DependencyInjection
{
    public static class FisSstMapsDependencyInjection
    {
        public static IServiceCollection AddBlazorLeafletMaps(this IServiceCollection services)
        {
            services.AddTransient<IDebugJsInterop, DebugJsInterop>();
            services.AddTransient<IMapJsInterop, MapJsInterop>();
            services.AddTransient<IMarkerFactory, MarkerFactory>();
            services.AddTransient<IPolylineFactory, PolylineFactory>();
            services.AddTransient<IEventedJsInterop, EventedJsInterop>();
            services.AddTransient<ICircleMarkerFactory, CircleMarkerFactory>();
            services.AddTransient<ICircleFactory, CircleFactory>();
            return services;
        }
    }
}
