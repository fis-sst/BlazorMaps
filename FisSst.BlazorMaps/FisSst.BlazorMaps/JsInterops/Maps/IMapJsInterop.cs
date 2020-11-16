using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Maps
{
    internal interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
    }
}
