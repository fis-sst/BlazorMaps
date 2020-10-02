using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorComponents.Core.JsInterops
{
    internal class MapJsInterop : BaseJsInterop, IMapJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.MapFile}";
        private const string initialize = "initialize";
        private const string getCenter = "getCenter";
        private const string setView = "setView";
        private const string setZoom = "setZoom";
        private const string zoomIn = "zoomIn";
        private const string zoomOut = "zoomOut";
        private const string setZoomAround = "setZoomAround";

        public MapJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask<JSObjectReference> Initialize(MapOptions mapOptions)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<JSObjectReference>(initialize, mapOptions);
        }

        public async ValueTask<LatLng> GetCenter(JSObjectReference mapReference)
        {
            return await mapReference.InvokeAsync<LatLng>(getCenter);
        }

        public async ValueTask SetView(JSObjectReference mapReference, LatLng latLng)
        {
            await mapReference.InvokeAsync<JSObjectReference>(setView, latLng);
        }

        public async Task SetZoom(JSObjectReference mapReference, int zoom)
        {
            await mapReference.InvokeAsync<JSObjectReference>(setZoom, zoom);
        }

        public async Task ZoomIn(JSObjectReference mapReference, int? zoomDelta)
        {
            await mapReference.InvokeAsync<JSObjectReference>(zoomIn, zoomDelta);
        }

        public async Task ZoomOut(JSObjectReference mapReference, int? zoomDelta)
        {
            await mapReference.InvokeAsync<JSObjectReference>(zoomOut, zoomDelta);
        }

        public async Task SetZoomAround(JSObjectReference mapReference, LatLng latLng, int zoom)
        {
            await mapReference.InvokeAsync<JSObjectReference>(setZoomAround, latLng, zoom);
        }
    }
}
