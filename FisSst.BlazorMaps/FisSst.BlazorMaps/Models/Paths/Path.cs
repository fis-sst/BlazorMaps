using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public abstract class Path : InteractiveLayer
    {
        private const string RedrawJsFunction = "redraw";
        private const string SetStyleJsFunction = "setStyle";
        private const string BringToFrontJsFunction = "bringToFront";
        private const string BringToBackJsFunction = "bringToBack";

        public async Task<Path> Redraw()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(RedrawJsFunction);
            return this;
        }

        public async Task<Path> SetStyle(PathOptions options)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(SetStyleJsFunction, options);
            return this;
        }

        public async Task<Path> BringToFront()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BringToFrontJsFunction);
            return this;
        }

        public async Task<Path> BringToBack()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BringToBackJsFunction);
            return this;
        }
    }
}
