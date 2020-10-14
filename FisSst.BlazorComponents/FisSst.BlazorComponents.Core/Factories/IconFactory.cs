using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    class IconFactory : IIconFactory
    {
        private readonly string create = "L.icon";
        private readonly string createDefault = "new L.Icon.Default";
        private readonly IJSRuntime jsRuntime;
        private readonly IIconFactoryJsInterop iconFactoryJsInterop;

        public IconFactory(
            IJSRuntime jsRuntime,
            IIconFactoryJsInterop iconFactoryJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.iconFactoryJsInterop = iconFactoryJsInterop;
        }

        public async Task<Icon> Create(IconOptions options)
        {
            JSObjectReference jsReference = await this.jsRuntime.InvokeAsync<JSObjectReference>(create, options);
            return new Icon(jsReference);
        }

        public async Task<Icon> CreateDefault()
        {
            JSObjectReference jsReference = await this.iconFactoryJsInterop.CreateDefaultIcon();
            return new Icon(jsReference);
        }
    }
}
