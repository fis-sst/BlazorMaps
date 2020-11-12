using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    interface IDebugJsInterop : IBaseJsInterop
    {
        ValueTask<string> Prompt(string message);
    }
}
