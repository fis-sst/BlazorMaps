using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops.Base
{
    interface IBaseJsInterop
    {
        ValueTask DisposeAsync();
    }
}
