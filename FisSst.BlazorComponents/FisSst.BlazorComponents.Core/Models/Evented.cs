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
        protected IEventedJsInterop EventedJsInterop;
        private readonly IDictionary<string, Func<Task>> events = new Dictionary<string, Func<Task>>();

        public async Task On(string eventType, Func<Task> callback)
        {
            this.events.Add(eventType, callback);
            DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
            await this.EventedJsInterop.OnCallback(eventedClass, eventType);
        }

        [JSInvokable]
        public async Task OnCallback(string eventType)
        {
            bool isEvented = this.events.TryGetValue(eventType, out Func<Task> callback);
            if (isEvented)
            {
                await callback.Invoke();
            }
        }
    }
}
