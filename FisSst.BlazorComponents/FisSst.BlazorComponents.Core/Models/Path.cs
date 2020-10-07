using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public abstract class Path : InteractiveLayer
    {
        private readonly string redraw = "redraw";
        private readonly string setStyle = "setStyle";
        private readonly string bringToFront = "bringToFront";
        private readonly string bringToBack = "bringToBack";

        public async Task<Path> Redraw()
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(redraw);
            return this;
        }

        public async Task<Path> SetStyle(PathOptions options)
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(setStyle, options);
            return this;
        }
        public async Task<Path> BringToFront()
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(bringToFront);
            return this;
        }
        public async Task<Path> BringToBack()
        {
            await this.JsReference.InvokeAsync<JSObjectReference>(bringToBack);
            return this;
        }
    }
}
