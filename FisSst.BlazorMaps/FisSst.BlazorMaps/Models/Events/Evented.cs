using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Evented is an abstract class for beings that are interactive, i.e. they
    /// can react on events such as 'click', 'mouseover' etc.
    /// </summary>
    public abstract class Evented : JsReferenceBase
    {
        private const string click = "click";
        private const string dblclick = "dblclick";
        private const string mousedown = "mousedown";
        private const string mouseup = "mouseup";
        private const string mouseover = "mouseover";
        private const string mouseout = "mouseout";
        private const string contextmenu = "contextmenu";
        private const string off = "off";
        protected IEventedJsInterop EventedJsInterop;
        private readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();

        public async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await On(click, callback);
        }

        public async Task OnDblClick(Func<MouseEvent, Task> callback)
        {
            await On(dblclick, callback);
        }

        public async Task OnMouseDown(Func<MouseEvent, Task> callback)
        {
            await On(mousedown, callback);
        }

        public async Task OnMouseUp(Func<MouseEvent, Task> callback)
        {
            await On(mouseup, callback);
        }

        public async Task OnMouseOver(Func<MouseEvent, Task> callback)
        {
            await On(mouseover, callback);
        }

        public async Task OnMouseOut(Func<MouseEvent, Task> callback)
        {
            await On(mouseout, callback);
        }

        public async Task OnContextMenu(Func<MouseEvent, Task> callback)
        {
            await On(contextmenu, callback);
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
                await this.JsReference.InvokeAsync<IJSObjectReference>(off, eventType);
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
