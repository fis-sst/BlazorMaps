using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        internal JSObjectReference MapReference { get; set; }

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
            await this.MapReference.InvokeAsync<JSObjectReference>(setView, latLng);
        }

        public async Task SetZoom(int zoom)
        {
            await this.MapReference.InvokeAsync<JSObjectReference>(setZoom, zoom);
        }

        public async Task ZoomIn(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<JSObjectReference>(zoomIn, zoomDelta);
        }

        public async Task ZoomOut(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<JSObjectReference>(zoomOut, zoomDelta);
        }

        public async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeAsync<JSObjectReference>(setZoomAround, latLng, zoom);
        }
    }
}
