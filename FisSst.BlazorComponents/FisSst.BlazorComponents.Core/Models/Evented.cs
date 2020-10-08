using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public abstract class Evented : JsReferenceBase
    {
        private const string click = "click";
        protected IEventedJsInterop EventedJsInterop;
        private readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();

        public async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await this.On(click, callback);
        }

        public async Task On(string eventType, Func<MouseEvent, Task> callback)
        {
            this.MouseEvents.Add(eventType, callback);
            DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
            await this.EventedJsInterop.OnCallback(eventedClass, this.JsReference, eventType);
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
