using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Models
{
    public class Marker : InteractiveLayer
    {
        private readonly string getLatLng = "getLatLng";
        private readonly string setLatLng = "setLatLng";
        private readonly string setZIndexOffset = "setZIndexOffset";
        private readonly string getIcon = "getIcon";
        private readonly string setIcon = "setIcon";
        private readonly string setOpacity = "setOpacity";

        internal Marker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
        }

        public async Task<LatLng> GetLatLng()
        {
            return await this.JsReference.InvokeAsync<LatLng>(getLatLng);
        }

        public async Task<IJSObjectReference> SetLatLng(LatLng latLng)
        {
            return await this.JsReference.InvokeAsync<IJSObjectReference>(setLatLng, latLng);
        }

        public async Task<IJSObjectReference> SetZIndexOffset(int number)
        {
            return await this.JsReference.InvokeAsync<IJSObjectReference>(setZIndexOffset, number);
        }

        public async Task<Icon> GetIcon()
        {
            return await this.JsReference.InvokeAsync<Icon>(getIcon);
        }

        public async Task<IJSObjectReference> SetIcon(Icon icon)
        {
            return await this.JsReference.InvokeAsync<IJSObjectReference>(setIcon, icon);
        }

        public async Task<IJSObjectReference> SetOpacity(int number)
        {
            return await this.JsReference.InvokeAsync<IJSObjectReference>(setOpacity, number);
        }
    }
}
