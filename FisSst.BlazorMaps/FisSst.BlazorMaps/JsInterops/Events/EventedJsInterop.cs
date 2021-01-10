using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Events
{
    internal class EventedJsInterop : BaseJsInterop, IEventedJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.EventedFile}";
        private const string OnMouseCallback = "onMouseCallback";
        private const string OnLocationCallback = "onLocationCallback";

        public EventedJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask AddEventListenerInJs<TEventType>(
            DotNetObjectReference<Evented> eventedClass,
            IJSObjectReference evented,
            TEventType eventTypeValue,
            string eventType)
                where TEventType : Enum
        {
            string onCallbackJsFunction = this.GetJsFunctionName(eventTypeValue);
            IJSObjectReference module = await moduleTask.Value;
            await module.InvokeVoidAsync(onCallbackJsFunction, eventedClass, evented, eventType);
        }

        private string GetJsFunctionName<TEventType>(TEventType eventTypeValue)
            where TEventType : Enum
        {
            if (eventTypeValue is MouseEventType)
                return OnMouseCallback;
            if (eventTypeValue is LocationEventType)
                return OnLocationCallback;
            throw new InvalidOperationException("Not supported event type");
        }
    }
}
