using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IBaseJsInterop
    {
        ValueTask DisposeAsync();
    }
}
