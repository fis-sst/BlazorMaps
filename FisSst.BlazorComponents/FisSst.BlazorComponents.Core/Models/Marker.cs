using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class Marker : InteractiveLayer
    {
        private readonly string getLatLng = "getLatLng";
        private readonly string setLatLng = "setLatLng";
        private readonly string setZIndexOffset = "setZIndexOffset";
        private readonly string getIcon = "getIcon";
        private readonly string setIcon = "setIcon";
        private readonly string setOpacity = "setOpacity";

        internal Marker(JSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
        }

        public async Task<LatLng> GetLatLng()
        {
            return await this.JsReference.InvokeAsync<LatLng>(getLatLng);
        }

        public async Task<JSObjectReference> SetLatLng(LatLng latLng)
        {
            return await this.JsReference.InvokeAsync<JSObjectReference>(setLatLng, latLng);
        }

        public async Task<JSObjectReference> SetZIndexOffset(int number)
        {
            return await this.JsReference.InvokeAsync<JSObjectReference>(setZIndexOffset, number);
        }

        public async Task<Icon> GetIcon()
        {
            return await this.JsReference.InvokeAsync<Icon>(getIcon);
        }

        public async Task<JSObjectReference> SetIcon(Icon icon)
        {
            return await this.JsReference.InvokeAsync<JSObjectReference>(setIcon, icon);
        }

        public async Task<JSObjectReference> SetOpacity(int number)
        {
            return await this.JsReference.InvokeAsync<JSObjectReference>(setOpacity, number);
        }
    }
}
