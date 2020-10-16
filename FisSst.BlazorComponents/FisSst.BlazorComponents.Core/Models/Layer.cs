using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public abstract class Layer : Evented
    {
        private readonly string addTo = "addTo";
        private readonly string remove = "remove";
        private readonly string removeFrom = "removeFrom";
        private readonly string bindPopup = "bindPopup";
        private readonly string unbindPopup = "unbindPopup";
        private readonly string openPopup = "openPopup";
        private readonly string closePopup = "closePopup";
        private readonly string togglePopup = "togglePopup";
        private readonly string isPopupOpen = "isPopupOpen";
        private readonly string setPopupContent = "setPopupContent";
        private readonly string bindTooltip = "bindTooltip";
        private readonly string unbindTooltip = "unbindTooltip";
        private readonly string openTooltip = "openTooltip";
        private readonly string closeTooltip = "closeTooltip";
        private readonly string toggleTooltip = "toggleTooltip";
        private readonly string isTooltipOpen = "isTooltipOpen";
        private readonly string setTooltipContent = "setTooltipContent";

        public async Task<Layer> AddTo(Map map)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(addTo, map.MapReference);
            return this;
        }

        public async Task<Layer> Remove()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(remove);
            await this.JsReference.DisposeAsync();
            return this;
        }

        public async Task<Layer> RemoveFrom(Map map)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(removeFrom, map.MapReference);
            return this;
        }

        public async Task<Layer> BindPopup(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(bindPopup, content);
            return this;
        }

        public async Task<Layer> UnbindPopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(unbindPopup);
            return this;
        }

        public async Task<Layer> OpenPopup(LatLng? latLng)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(openPopup, latLng);
            return this;
        }

        public async Task<Layer> ClosePopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(closePopup);
            return this;
        }

        public async Task<Layer> TogglePopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(togglePopup);
            return this;
        }

        public async Task<bool> IsPopupOpen()
        {
            return await this.JsReference.InvokeAsync<bool>(isPopupOpen);
        }

        public async Task<Layer> SetPopupContent(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(setPopupContent, content);
            return this;
        }

        public async Task<Layer> BindTooltip(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(bindTooltip, content);
            return this;
        }

        public async Task<Layer> UnbindTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(unbindTooltip);
            return this;
        }

        public async Task<Layer> OpenTooltip(LatLng? latLng)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(openTooltip, latLng);
            return this;
        }

        public async Task<Layer> CloseTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(closeTooltip);
            return this;
        }

        public async Task<Layer> ToggleTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(toggleTooltip);
            return this;
        }

        public async Task<bool> IsTooltipOpen()
        {
            return await this.JsReference.InvokeAsync<bool>(isTooltipOpen);
        }

        public async Task<Layer> SetTooltipContent(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(setTooltipContent, content);
            return this;
        }
    }
}
