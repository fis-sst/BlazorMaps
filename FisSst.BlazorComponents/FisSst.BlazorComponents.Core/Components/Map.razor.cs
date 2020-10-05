using FisSst.BlazorComponents.Core;
using FisSst.BlazorComponents.Core.JsInterops;
using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps
{
    public partial class Map : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        internal IDebugJsInterop DebugJsInterop { get; set; }

        [Inject]
        internal IMapJsInterop MapJsInterop { get; set; }

        [Parameter]
        public MapOptions MapOptions { get; set; }        

        private JSObjectReference MapReference { get; set; }

        private const string getCenter = "getCenter";
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
            }            
        }

        public async Task<LatLng> GetCenter()
        {
            return await this.MapReference.InvokeAsync<LatLng>(getCenter);
        }

        public async Task SetView(LatLng latLng)
        {
            await this.MapReference.InvokeVoidAsync(setView, latLng);
        }

        public async Task SetZoom(int zoom)
        {
            await this.MapReference.InvokeVoidAsync(setZoom, zoom);
        }

        public async Task ZoomIn(int zoomDelta)
        {
            await this.MapReference.InvokeVoidAsync(zoomIn, zoomDelta);
        }

        public async Task ZoomOut(int zoomDelta)
        {
            await this.MapReference.InvokeVoidAsync(zoomOut, zoomDelta);
        }

        public async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeVoidAsync(setZoomAround, latLng, zoom);
        }
    }
}
