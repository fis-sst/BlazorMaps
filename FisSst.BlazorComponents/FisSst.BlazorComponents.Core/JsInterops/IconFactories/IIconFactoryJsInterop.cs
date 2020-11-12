using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.IconFactories
{
    interface IIconFactoryJsInterop
    {
        ValueTask<IJSObjectReference> CreateDefaultIcon();
    }
}
