using FisSst.BlazorMaps.JsInterops.Base;
using FisSst.BlazorMaps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Events
{
    internal class EventedJsInterop : BaseJsInterop, IEventedJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.EventedFile}";
        private const string onCallback = "onCallback";

        public EventedJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask OnCallback(
            DotNetObjectReference<Evented> eventedClass,
            IJSObjectReference evented, 
            string eventType)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(onCallback, eventedClass, evented, eventType);
        }
    }
}
