using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// An abstract class for beings that are interactive, i.e. they
    /// can react on events such as 'click', 'mouseover' etc.
    /// </summary>
    public abstract class Evented : JsReferenceBase
    {
        private const string ClickJsFunction = "click";
        private const string DblClickJsFunction = "dblclick";
        private const string MouseDownJsFunction = "mousedown";
        private const string MouseUpJsFunction = "mouseup";
        private const string MouseOverJsFunction = "mouseover";
        private const string MouseOutJsFunction = "mouseout";
        private const string ContextMenuJsFunction = "contextmenu";
        private const string OffJsFunction = "off";
        protected IEventedJsInterop EventedJsInterop;
        private readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();

        public async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await On(ClickJsFunction, callback);
        }

        public async Task OnDblClick(Func<MouseEvent, Task> callback)
        {
            await On(DblClickJsFunction, callback);
        }

        public async Task OnMouseDown(Func<MouseEvent, Task> callback)
        {
            await On(MouseDownJsFunction, callback);
        }

        public async Task OnMouseUp(Func<MouseEvent, Task> callback)
        {
            await On(MouseUpJsFunction, callback);
        }

        public async Task OnMouseOver(Func<MouseEvent, Task> callback)
        {
            await On(MouseOverJsFunction, callback);
        }

        public async Task OnMouseOut(Func<MouseEvent, Task> callback)
        {
            await On(MouseOutJsFunction, callback);
        }

        public async Task OnContextMenu(Func<MouseEvent, Task> callback)
        {
            await On(ContextMenuJsFunction, callback);
        }

        private async Task On(string eventType, Func<MouseEvent, Task> callback)
        {
            if (this.MouseEvents.ContainsKey(eventType))
            {
                return;
            }

            this.MouseEvents.Add(eventType, callback);
            await this.On(eventType);
        }

        private async Task On(string eventType)
        {
            DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
            await this.EventedJsInterop.OnCallback(eventedClass, this.JsReference, eventType);
        }

        public async Task Off(string eventType)
        {
            if (this.MouseEvents.ContainsKey(eventType))
            {
                this.MouseEvents.Remove(eventType);
                await this.JsReference.InvokeAsync<IJSObjectReference>(OffJsFunction, eventType);
            }
        }

        [JSInvokable]
        public async Task OnCallback(string eventType, MouseEvent mouseEvent)
        {
            bool isEvented = this.MouseEvents.TryGetValue(eventType, out Func<MouseEvent, Task> callback);
            if (isEvented)
            {
                await callback.Invoke(mouseEvent);
            }
        }
    }
}
