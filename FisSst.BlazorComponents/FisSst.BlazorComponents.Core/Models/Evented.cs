using FisSst.Maps.Helpers.JsInterops;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public abstract class Evented : JsReferenceBase
    {
        private readonly string on = "on";

        public async Task On(string eventType, CallBackInteropWrapper callback)
        {
            await this.JsReference.InvokeVoidAsync(on, eventType, callback);
        }
    }
}
