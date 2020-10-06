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
            AddJsInterops(services);
            AddFactories(services);
            return services;
        }

        private static void AddFactories(IServiceCollection services)
        {
            services.AddTransient<IMarkerFactory, MarkerFactory>();
            services.AddTransient<IIconFactory, IconFactory>();
            services.AddTransient<IPolylineFactory, PolylineFactory>();
            services.AddTransient<IPolygonFactory, PolygonFactory>();
            services.AddTransient<ICircleMarkerFactory, CircleMarkerFactory>();
            services.AddTransient<ICircleFactory, CircleFactory>();
        }

        private static void AddJsInterops(IServiceCollection services)
        {
            services.AddTransient<IDebugJsInterop, DebugJsInterop>();
            services.AddTransient<IMapJsInterop, MapJsInterop>();
            services.AddTransient<IEventedJsInterop, EventedJsInterop>();
            services.AddTransient<IIconFactoryJsInterop, IconFactoryJsInterop>();
        }
    }
}
