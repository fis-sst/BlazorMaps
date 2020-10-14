using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IDebugJsInterop : IBaseJsInterop
    {
        ValueTask<string> Prompt(string message);
    }
}
