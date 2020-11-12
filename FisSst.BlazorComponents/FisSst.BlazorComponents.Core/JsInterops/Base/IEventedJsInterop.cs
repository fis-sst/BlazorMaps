using FisSst.BlazorMaps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    public interface IEventedJsInterop
    {
        ValueTask OnCallback(DotNetObjectReference<Evented> eventedClass, IJSObjectReference eventedReference, string eventType);
    }
}
