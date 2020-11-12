using FisSst.BlazorMaps.JsInterops.Base;
using FisSst.BlazorMaps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Maps
{
    interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
    }
}
