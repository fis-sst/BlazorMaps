using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// It is used to display clickable/draggable icons on the Map.
    /// </summary>
    public class TileLayer : Layer
    {
        internal TileLayer(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
