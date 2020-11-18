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
        private const string redraw = "redraw";
        private const string setStyle = "setStyle";
        private const string bringToFront = "bringToFront";
        private const string bringToBack = "bringToBack";

        public async Task<Path> Redraw()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(redraw);
            return this;
        }

        public async Task<Path> SetStyle(PathOptions options)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(setStyle, options);
            return this;
        }

        public async Task<Path> BringToFront()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(bringToFront);
            return this;
        }

        public async Task<Path> BringToBack()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(bringToBack);
            return this;
        }
    }
}
