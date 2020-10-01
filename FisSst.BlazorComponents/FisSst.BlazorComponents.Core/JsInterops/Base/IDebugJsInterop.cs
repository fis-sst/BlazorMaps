using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IDebugJsInterop : IBaseJsInterop
    {
        ValueTask<string> Prompt(string message);
    }
}
