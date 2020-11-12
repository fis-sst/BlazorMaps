using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public abstract class Path : InteractiveLayer
    {
        private readonly string redraw = "redraw";
        private readonly string setStyle = "setStyle";
        private readonly string bringToFront = "bringToFront";
        private readonly string bringToBack = "bringToBack";

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
