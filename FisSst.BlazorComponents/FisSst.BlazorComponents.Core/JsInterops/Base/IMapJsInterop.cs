using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<JSObjectReference> Initialize(MapOptions mapOptions);
    }
}
