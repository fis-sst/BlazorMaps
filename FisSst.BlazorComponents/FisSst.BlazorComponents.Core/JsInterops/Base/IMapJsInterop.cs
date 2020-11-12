using FisSst.BlazorMaps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
    }
}
