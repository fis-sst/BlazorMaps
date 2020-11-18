using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Marker is used to display clickable/draggable icons on the map.
    /// </summary>
    public class Marker : InteractiveLayer
    {
        private const string getLatLng = "getLatLng";
        private const string setLatLng = "setLatLng";
        private const string setZIndexOffset = "setZIndexOffset";
        private const string getIcon = "getIcon";
        private const string setIcon = "setIcon";
        private const string setOpacity = "setOpacity";

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
