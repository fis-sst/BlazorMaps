using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// An abstract class for layers that are interactive, i.e. they
    /// can react on events such as 'click', 'mouseover' etc.
    /// </summary>
    public abstract class Evented : JsReferenceBase
    {
        private const string OffJsFunction = "off";
        protected IEventedJsInterop EventedJsInterop;
        private readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();

        public async Task OnMouseEvent(MouseEventType mouseEventType, Func<MouseEvent, Task> callback)
        {
            string eventType = this.GetMouseEventType(mouseEventType);
            if (this.MouseEvents.ContainsKey(eventType))
            {
                return;
            }
            this.MouseEvents.Add(eventType, callback);
            await this.OnMouseCallback(eventType);
        }        

        public async Task OffMouseEvent(MouseEventType mouseEventType)
        {
            string eventType = this.GetMouseEventType(mouseEventType);
            if (this.MouseEvents.ContainsKey(eventType))
            {
                this.MouseEvents.Remove(eventType);
                await this.JsReference.InvokeAsync<IJSObjectReference>(OffJsFunction, eventType);
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [JSInvokable]
        public async Task OnMouseCallbackCalled(string eventType, MouseEvent mouseEvent)
        {
            bool isEvented = this.MouseEvents.TryGetValue(eventType, out Func<MouseEvent, Task> callback);
            if (isEvented)
            {
                await callback.Invoke(mouseEvent);
            }
        }

        private async Task OnMouseCallback(string eventType)
        {
            DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
            await this.EventedJsInterop.OnMouseCallback(eventedClass, this.JsReference, eventType);
        }        

        private string GetMouseEventType(MouseEventType mouseEventType)
        {
            return Enum.GetName(mouseEventType).ToLower();
        }
    }
}
