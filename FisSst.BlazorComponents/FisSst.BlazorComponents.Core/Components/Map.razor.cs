using FisSst.BlazorComponents.Core;
using FisSst.BlazorComponents.Core.JsInterops;
using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps
{
    public partial class Map : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        internal IDebugJsInterop DebugJsInterop { get; set; }

        [Inject]
        internal IMapJsInterop MapJsInterop { get; set; }

        [Parameter]
        public MapOptions MapOptions { get; set; }        

        private JSObjectReference MapReference { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.MapReference = await this.MapJsInterop.Initialize(this.MapOptions);
            }            
        }

        public async Task Debug()
        {
            var center = await this.MapJsInterop.GetCenter(this.MapReference);
            await this.DebugJsInterop.Prompt($"{center.Latitude}, {center.Longitude}");
        }
    }
}
