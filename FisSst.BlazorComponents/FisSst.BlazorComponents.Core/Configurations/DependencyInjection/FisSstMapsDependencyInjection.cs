using FisSst.BlazorComponents.Core.JsInterops;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.Configurations.DependencyInjection
{
    public static class FisSstMapsDependencyInjection
    {
        public static IServiceCollection AddBlazorLeafletMaps(this IServiceCollection services)
        {
            services.AddScoped<DebugJsInterop>();
            services.AddScoped<MapJsInterop>();
            return services;
        }
    }
}
