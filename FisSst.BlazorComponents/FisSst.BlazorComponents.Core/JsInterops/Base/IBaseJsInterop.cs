using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    interface IBaseJsInterop
    {
        ValueTask DisposeAsync();
    }
}
