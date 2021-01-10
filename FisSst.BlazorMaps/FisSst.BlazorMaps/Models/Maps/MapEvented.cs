using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class MapEvented : Evented
    {
        public MapEvented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            this.JsReference = jsReference;
            this.EventedJsInterop = eventedJsInterop;
        }

        public async Task OnMouseEvent(MouseEventType mouseEventType, Func<MouseEvent, Task> callback)
        {
            await this.AddMouseEventListener(mouseEventType, callback);
        }

        public async Task OffMouseEvent(MouseEventType mouseEventType)
        {
            await this.RemoveMouseEventListener(mouseEventType);
        }
    }
}
