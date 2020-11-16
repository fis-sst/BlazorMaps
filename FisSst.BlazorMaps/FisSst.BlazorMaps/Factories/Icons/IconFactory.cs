using FisSst.BlazorMaps.JsInterops.IconFactories;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    class IconFactory : IIconFactory
    {
        private readonly string create = "L.icon";
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
            IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, options);
            return new Icon(jsReference);
        }

        public async Task<Icon> CreateDefault()
        {
            IJSObjectReference jsReference = await this.iconFactoryJsInterop.CreateDefaultIcon();
            return new Icon(jsReference);
        }
    }
}
