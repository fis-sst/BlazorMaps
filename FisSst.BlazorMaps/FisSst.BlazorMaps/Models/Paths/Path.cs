﻿using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// It is an abstract class that contains options and constants
    /// shared between vector overlays (Polygon, Polyline, Circle).
    /// </summary>
    public abstract class Path : InteractiveLayer
    {
        private const string RedrawJsFunction = "redraw";
        private const string SetStyleJsFunction = "setStyle";
        private const string BringToFrontJsFunction = "bringToFront";
        private const string BringToBackJsFunction = "bringToBack";
        private const string GetBoundsJsFunction = "getBounds";
        
        public async Task<Path> Redraw()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(RedrawJsFunction);
            return this;
        }

        public async Task<Path> SetStyle(PathOptions options)
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(SetStyleJsFunction, options);
            return this;
        }

        public async Task<Path> BringToFront()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BringToFrontJsFunction);
            return this;
        }

        public async Task<Path> BringToBack()
        {
            await this.JsReference.InvokeAsync<IJSObjectReference>(BringToBackJsFunction);
            return this;
        }
        
        /// <summary>
        /// Leaflet getBounds() function returns  
        /// {"_southWest":{"lat":-23.601783040147975,"lng":-46.537071217637845}, "_northEast":{"lat":-23.556816959852032,"lng":-46.48800878236214}}"
        /// </summary>
        /// <returns>LatLngBounds</returns>
        public async Task<LatLngBounds> GetBounds()
        {
          
          return await this.JsReference.InvokeAsync<LatLngBounds>(GetBoundsJsFunction);
        }
    }
}
