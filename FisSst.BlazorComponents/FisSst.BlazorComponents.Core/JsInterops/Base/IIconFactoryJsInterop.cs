using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IIconFactoryJsInterop
    {
        ValueTask<IJSObjectReference> CreateDefaultIcon();
    }
}
