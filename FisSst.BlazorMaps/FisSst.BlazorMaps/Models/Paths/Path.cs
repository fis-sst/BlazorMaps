using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Path is an abstract class that contains options and constants
    /// shared between vector overlays (Polygon, Polyline, Circle).
    /// </summary>
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
