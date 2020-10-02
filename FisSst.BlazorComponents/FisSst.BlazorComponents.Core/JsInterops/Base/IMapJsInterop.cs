using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<JSObjectReference> Initialize(MapOptions mapOptions);
        ValueTask<LatLng> GetCenter(JSObjectReference mapReference);
        ValueTask SetView(JSObjectReference mapReference, LatLng latLng);
        Task SetZoom(JSObjectReference mapReference, int zoom);
        Task ZoomIn(JSObjectReference mapReference, int? zoomDelta);
        Task ZoomOut(JSObjectReference mapReference, int? zoomDelta);
        Task SetZoomAround(JSObjectReference mapReference, LatLng latLng, int zoom);
    }
}
