using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    public interface IEventedJsInterop
    {
        ValueTask OnCallback(DotNetObjectReference<Evented> eventedClass, JSObjectReference eventedReference, string eventType);
    }
}
