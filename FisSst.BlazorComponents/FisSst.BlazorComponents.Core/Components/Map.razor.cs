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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.MapReference = await this.MapJsInterop.Initialize(this.MapOptions);
            }            
        }

        public async Task<LatLng> GetCenter()
        {
            return await this.MapJsInterop.GetCenter(this.MapReference);
        }

        public async Task SetView(LatLng latLng)
        {
            await this.MapJsInterop.SetView(this.MapReference, latLng);
        }

        public async Task SetZoom(int zoom)
        {
            await this.MapJsInterop.SetZoom(this.MapReference, zoom);
        }

        public async Task ZoomIn(int zoomDelta)
        {
            await this.MapJsInterop.SetZoom(this.MapReference, zoomDelta);
        }

        public async Task ZoomOut(int zoomDelta)
        {
            await this.MapJsInterop.SetZoom(this.MapReference, zoomDelta);
        }

        public async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapJsInterop.SetZoomAround(this.MapReference, latLng, zoom);
        }
    }
}
