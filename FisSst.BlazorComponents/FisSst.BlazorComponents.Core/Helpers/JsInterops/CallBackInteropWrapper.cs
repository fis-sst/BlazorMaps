using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FisSst.Maps.Helpers.JsInterops
{
    public class CallBackInteropWrapper
    {
        [JsonPropertyName("__isCallBackWrapper")]
        public string IsCallBackWrapper { get; set; } = "";

        public object CallbackRef { get; set; }

        private CallBackInteropWrapper()
        {

        }

        public static CallBackInteropWrapper Create<T>(Func<T, Task> callback)
        {
            var res = new CallBackInteropWrapper
            {
                CallbackRef = DotNetObjectReference.Create(new JSInteropActionWrapper<T>(callback))
            };
            return res;
        }

        public static CallBackInteropWrapper Create(Func<Task> callback)
        {
            var res = new CallBackInteropWrapper
            {
                CallbackRef = DotNetObjectReference.Create(new JSInteropActionWrapper(callback))
            };
            return res;
        }       


        private class JSInteropActionWrapper
        {
            private readonly Func<Task> toDo;

            internal JSInteropActionWrapper(Func<Task> toDo)
            {
                this.toDo = toDo;
            }
            [JSInvokable]
            public async Task Invoke()
            {
                await toDo.Invoke();
            }
        }
        private class JSInteropActionWrapper<T>
        {
            private readonly Func<T, Task> toDo;

            internal JSInteropActionWrapper(Func<T, Task> toDo)
            {
                this.toDo = toDo;
            }
            [JSInvokable]
            public async Task Invoke(T arg1)
            {
                await toDo.Invoke(arg1);
            }
        }
    }
}
