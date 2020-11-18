using Microsoft.JSInterop;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// An abstract class that makes it possible to call methods directly on JS objects.
    /// </summary>
    public abstract class JsReferenceBase
    {
        internal IJSObjectReference JsReference;
    }
}
