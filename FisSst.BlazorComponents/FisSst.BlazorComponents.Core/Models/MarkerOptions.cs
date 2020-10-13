using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class MarkerOptions : InteractiveLayerOptions
    {
        public MarkerOptions()
        {
            Icon = null;
            Keyboard = true;
            Title = string.Empty;
            Alt = string.Empty;
            ZIndexOffset = 0;
            Opacity = 1;
            RiseOnHover = false;
            RiseOffset = 250;
            Pane = "markerPane";
            ShadowPane = "shadowPane";
            BubblingMouseEvents = false;
            Interactive = true;
        }

        private Icon iconRef;
        [JsonIgnore]
        public Icon Icon 
        {
            get
            {
                return iconRef;
            }
            init
            {
                iconRef = value;
                if (value != null)
                {
                    IconReference = iconRef.JsReference;
                }
                else
                {
                    IconReference = null;
                }
                
            }
        }
        [JsonPropertyName("icon")]
        internal JSObjectReference IconReference { get; init; }
        public bool Keyboard { get; init; }
        public string Title { get; init; }
        public string Alt { get; init; }
        public int ZIndexOffset { get; init; }
        public double Opacity { get; init; }
        public bool RiseOnHover { get; init; }
        public int RiseOffset { get; init; }
        public string ShadowPane { get; init; }
        public bool Draggable { get; init; }
        public bool AutoPan { get; init; }
        public Point AutoPanPadding { get; init; }
        public int AutoPanSpeed { get; init; }
    }
}
