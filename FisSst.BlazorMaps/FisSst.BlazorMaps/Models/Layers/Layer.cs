using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public abstract class Layer : Evented
    {
        private const string AddToJsFunction = "addTo";
        private const string RemoveJsFunction = "remove";
        private const string RemoveFromJsFunction = "removeFrom";
        private const string BindPopupJsFunction = "bindPopup";
        private const string UnbindPopupJsFunction = "unbindPopup";
        private const string OpenPopupJsFunction = "openPopup";
        private const string ClosePopupJsFunction = "closePopup";
        private const string TogglePopupJsFunction = "togglePopup";
        private const string IsPopupOpenJsFunction = "isPopupOpen";
        private const string SetPopupContentJsFunction = "setPopupContent";
        private const string BindTooltipJsFunction = "bindTooltip";
        private const string UnbindTooltipJsFunction = "unbindTooltip";
        private const string OpenTooltipJsFunction = "openTooltip";
        private const string CloseTooltipJsFunction = "closeTooltip";
        private const string ToggleTooltipJsFunction = "toggleTooltip";
        private const string IsTooltipOpenJsFunction = "isTooltipOpen";
        private const string SetTooltipContentJsFunction = "setTooltipContent";

        public async Task<Layer> AddTo(Map map)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(AddToJsFunction, map.MapReference);
            return this;
        }

        public async Task<Layer> Remove()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(RemoveJsFunction);
            await this.JsReference.DisposeAsync();
            return this;
        }

        public async Task<Layer> RemoveFrom(Map map)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(RemoveFromJsFunction, map.MapReference);
            return this;
        }

        public async Task<Layer> BindPopup(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BindPopupJsFunction, content);
            return this;
        }

        public async Task<Layer> UnbindPopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(UnbindPopupJsFunction);
            return this;
        }

        public async Task<Layer> OpenPopup(LatLng? latLng)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(OpenPopupJsFunction, latLng);
            return this;
        }

        public async Task<Layer> ClosePopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(ClosePopupJsFunction);
            return this;
        }

        public async Task<Layer> TogglePopup()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(TogglePopupJsFunction);
            return this;
        }

        public async Task<bool> IsPopupOpen()
        {
            return await this.JsReference.InvokeAsync<bool>(IsPopupOpenJsFunction);
        }

        public async Task<Layer> SetPopupContent(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(SetPopupContentJsFunction, content);
            return this;
        }

        public async Task<Layer> BindTooltip(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BindTooltipJsFunction, content);
            return this;
        }

        public async Task<Layer> UnbindTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(UnbindTooltipJsFunction);
            return this;
        }

        public async Task<Layer> OpenTooltip(LatLng? latLng)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(OpenTooltipJsFunction, latLng);
            return this;
        }

        public async Task<Layer> CloseTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(CloseTooltipJsFunction);
            return this;
        }

        public async Task<Layer> ToggleTooltip()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(ToggleTooltipJsFunction);
            return this;
        }

        public async Task<bool> IsTooltipOpen()
        {
            return await this.JsReference.InvokeAsync<bool>(IsTooltipOpenJsFunction);
        }

        public async Task<Layer> SetTooltipContent(string content)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(SetTooltipContentJsFunction, content);
            return this;
        }
    }
}
