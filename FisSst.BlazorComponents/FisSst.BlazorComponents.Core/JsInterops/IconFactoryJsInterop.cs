using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops
{
    internal class IconFactoryJsInterop : BaseJsInterop, IIconFactoryJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.IconFactoryFile}";
        private const string createDefaultIcon = "createDefaultIcon";

        public IconFactoryJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask<JSObjectReference> CreateDefaultIcon()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<JSObjectReference>(createDefaultIcon);
        }
    }
}
