using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public abstract class Evented : JsReferenceBase
    {
        private readonly string on = "on";

        public async Task On(string eventType, Action func)
        {
            var objRef = DotNetObjectReference.Create(func);

            await this.JsReference.InvokeAsync<string>(on, eventType, objRef);
        }
    }
}
