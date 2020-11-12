using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    interface IIconFactoryJsInterop
    {
        ValueTask<IJSObjectReference> CreateDefaultIcon();
    }
}
