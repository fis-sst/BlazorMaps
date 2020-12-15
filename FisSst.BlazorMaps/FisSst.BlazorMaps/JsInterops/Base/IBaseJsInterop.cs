using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    internal interface IBaseJsInterop
    {
        ValueTask DisposeAsync();
    }
}
