using FisSst.Maps.JsInterops.Base;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    internal class MapEvented : Evented
    {
        public MapEvented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            this.JsReference = jsReference;
            this.EventedJsInterop = eventedJsInterop;
        }
    }
}
