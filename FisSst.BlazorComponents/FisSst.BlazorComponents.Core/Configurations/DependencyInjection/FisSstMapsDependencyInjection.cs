using FisSst.BlazorComponents.Core.JsInterops;
using FisSst.Maps.JsInterops.Base;
using Microsoft.Extensions.DependencyInjection;

namespace FisSst.Maps.Configurations.DependencyInjection
{
    public static class FisSstMapsDependencyInjection
    {
        public static IServiceCollection AddBlazorLeafletMaps(this IServiceCollection services)
        {
            services.AddTransient<IDebugJsInterop, DebugJsInterop>();
            services.AddTransient<IMapJsInterop, MapJsInterop>();
            return services;
        }
    }
}
