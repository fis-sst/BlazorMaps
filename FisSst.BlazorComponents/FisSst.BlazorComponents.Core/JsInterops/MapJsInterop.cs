using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorComponents.Core.JsInterops
{
    internal class MapJsInterop
    {
        internal static async Task Initialize(
            IJSRuntime jsRuntime, 
            string mapDivId, 
            LatLng startCenter, 
            int startZoom,
            string urlTileLayer,
            MapOptions mapOptions)
        {
            await jsRuntime.InvokeVoidAsync("leafletMap.initializeMap", 
                mapDivId, startCenter.Value, startZoom, urlTileLayer, mapOptions);
        }
    }
}
