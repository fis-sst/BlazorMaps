using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Events
{
    /// <summary>
    /// It is responsible for dealing with events in a way that
    /// allows to call C# methods when an event fires on the JS side.
    /// </summary>
    public interface IEventedJsInterop
    {
        ValueTask OnCallback(DotNetObjectReference<Evented> eventedClass, IJSObjectReference eventedReference, string eventType);
    }
}
