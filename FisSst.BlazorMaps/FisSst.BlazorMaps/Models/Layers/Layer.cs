using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// A set of methods from the Layer base class that all Leaflet layers (e.g. markers, circles) use.
    /// </summary>
    public abstract class Layer : Evented
    {
        private const string addTo = "addTo";
        private const string remove = "remove";
        private const string removeFrom = "removeFrom";
        private const string bindPopup = "bindPopup";
        private const string unbindPopup = "unbindPopup";
        private const string openPopup = "openPopup";
        private const string closePopup = "closePopup";
        private const string togglePopup = "togglePopup";
        private const string isPopupOpen = "isPopupOpen";
        private const string setPopupContent = "setPopupContent";
        private const string bindTooltip = "bindTooltip";
        private const string unbindTooltip = "unbindTooltip";
        private const string openTooltip = "openTooltip";
        private const string closeTooltip = "closeTooltip";
        private const string toggleTooltip = "toggleTooltip";
        private const string isTooltipOpen = "isTooltipOpen";
        private const string setTooltipContent = "setTooltipContent";

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
