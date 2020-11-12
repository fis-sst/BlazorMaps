using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.JsInterops.Base
{
    internal abstract class BaseJsInterop : IAsyncDisposable, IBaseJsInterop
    {
        protected readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public BaseJsInterop(IJSRuntime jsRuntime, string jsFilePath)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               JsInteropConfig.Import, jsFilePath).AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
