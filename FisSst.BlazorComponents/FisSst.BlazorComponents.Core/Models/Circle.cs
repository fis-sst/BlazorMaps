﻿using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class Circle : CircleMarker
    {
        private readonly string setRadius = "setRadius";
        private readonly string getRadius = "getRadius";
        private readonly string getBounds = "getBounds";

        internal Circle(JSObjectReference jsReference) : base (jsReference)
        {
            JsReference = jsReference;
        }

        public async Task<Circle> SetRadius(double radius)
        {
            await this.JsReference.InvokeAsync<Circle>(setRadius, radius);
            return this;
        }

        //TO DO
        //public async Task<LatLngBounds> GetBounds()
        //{
        //    return await this.JsReference.InvokeAsync<LatLngBounds>(getBounds);
        //}
    }
}