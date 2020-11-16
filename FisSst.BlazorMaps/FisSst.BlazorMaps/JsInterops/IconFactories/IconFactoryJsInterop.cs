using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.IconFactories
{
    internal class IconFactoryJsInterop : BaseJsInterop, IIconFactoryJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.IconFactoryFile}";
        private const string createDefaultIcon = "createDefaultIcon";

        public IconFactoryJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask<IJSObjectReference> CreateDefaultIcon()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<IJSObjectReference>(createDefaultIcon);
        }
    }
}
