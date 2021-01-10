using FisSst.BlazorMaps.JsInterops.Events;
using FisSst.BlazorMaps.JsInterops.Maps;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public partial class Map : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        internal IMapJsInterop MapJsInterop { get; set; }

        [Inject]
        internal IEventedJsInterop EventedJsInterop { get; set; }

        internal MapEvented MapEvented { get; set; }

        [Parameter]
        public MapOptions MapOptions { get; set; }

        internal IJSObjectReference MapReference { get; set; }

        private const string getCenter = "getCenter";
        private const string getZoom = "getZoom";
        private const string getMinZoom = "getMinZoom";
        private const string getMaxZoom = "getMaxZoom";
        private const string setView = "setView";
        private const string setZoom = "setZoom";
        private const string zoomIn = "zoomIn";
        private const string zoomOut = "zoomOut";
        private const string setZoomAround = "setZoomAround";        

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.MapReference = await this.MapJsInterop.Initialize(this.MapOptions);
                this.MapEvented = new MapEvented(this.MapReference, this.EventedJsInterop);
            }            
        }

        public async Task<LatLng> GetCenter()
        {
            return await this.MapReference.InvokeAsync<LatLng>(getCenter);
        }

        public async Task<int> GetZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getZoom);
        }

        public async Task<int> GetMinZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMinZoom);
        }

        public async Task<int> GetMaxZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMaxZoom);
        }

        public async Task SetView(LatLng latLng)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setView, latLng);
        }

        public async Task SetZoom(int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoom, zoom);
        }

        public async Task ZoomIn(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomIn, zoomDelta);
        }

        public async Task ZoomOut(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomOut, zoomDelta);
        }

        public async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoomAround, latLng, zoom);
        }

        public async Task OnMouseEvent(MouseEventType mouseEventType, Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseEvent(mouseEventType, callback);
        }

        public async Task OffMouseEvent(MouseEventType mouseEventType)
        {
            await this.MapEvented.OffMouseEvent(mouseEventType);
        }
    }
}
