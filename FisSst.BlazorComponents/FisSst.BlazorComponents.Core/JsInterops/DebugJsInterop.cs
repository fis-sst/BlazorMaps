using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorComponents.Core.JsInterops
{
    internal class DebugJsInterop
    {
        internal static async Task<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            return await jsRuntime.InvokeAsync<string>(
                "debugPrompt.showPrompt",
                message);
        }
    }
}
