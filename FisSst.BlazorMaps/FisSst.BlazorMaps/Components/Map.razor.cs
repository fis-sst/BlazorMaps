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

        [Parameter]
        public EventCallback AfterRender { get; set; }

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
        private const string fitBounds = "fitBounds";
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.MapReference = await this.MapJsInterop.Initialize(this.MapOptions);
                this.MapEvented = new MapEvented(this.MapReference, this.EventedJsInterop);
                await this.AfterRender.InvokeAsync();
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

        public async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnClick(callback);
        }
        public async Task OnDblClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnDblClick(callback);
        }

        public async Task OnMouseDown(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseDown(callback);
        }

        public async Task OnMouseUp(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseUp(callback);
        }

        public async Task OnMouseOver(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOver(callback);
        }

        public async Task OnMouseOut(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOut(callback);
        }

        public async Task OnContextMenu(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnContextMenu(callback);
        }

        public async Task Off(string eventType)
        {
            await this.MapEvented.Off(eventType);
        }
        
        /// <summary>
        /// As far Leaflet (javascript) can accept getBounds() as parameter for fitBounds()
        /// Here we have to make some transform to give proper values for fitBounds() and prevent Exception "Bounds are not valid."
        /// Due to _southwest & _northeast returned by getBounds()
        /// All Leaflet methods that accept LatLngBounds objects also accept them in a simple Array form (unless noted otherwise), so the bounds can be passed like this:
        /// map.fitBounds([ [40.712, -74.227], [40.774, -74.125] ])
        /// </summary>
        /// <param name="coords">Use ToLatLng extension method from LatLngBounds</param>
        public async Task FitBounds(IEnumerable<LatLng> coords)
        {
          await this.MapReference.InvokeAsync<IJSObjectReference>(fitBounds, coords);
        }
    }
}
