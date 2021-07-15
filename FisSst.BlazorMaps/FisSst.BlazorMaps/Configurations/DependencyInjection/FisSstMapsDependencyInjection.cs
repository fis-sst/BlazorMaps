using FisSst.BlazorMaps.JsInterops.Events;
using FisSst.BlazorMaps.JsInterops.IconFactories;
using FisSst.BlazorMaps.JsInterops.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace FisSst.BlazorMaps.DependencyInjection
{
    /// <summary>
    /// It is responsible for providing an app's services
    /// collection with its Factories and JsInterops implementations.
    /// </summary>
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
            services.AddTransient<ITileLayerFactory, TileLayerFactory>();
        }

        private static void AddJsInterops(IServiceCollection services)
        {
            services.AddTransient<IMapJsInterop, MapJsInterop>();
            services.AddTransient<IEventedJsInterop, EventedJsInterop>();
            services.AddTransient<IIconFactoryJsInterop, IconFactoryJsInterop>();
        }
    }
}
