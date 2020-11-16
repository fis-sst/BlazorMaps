using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace FisSst.BlazorMaps
{
    public class MarkerOptions : InteractiveLayerOptions
    {
        public MarkerOptions()
        {
            IconRef = null;
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
        public Icon IconRef
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
                    Icon = iconRef.JsReference;
                }
                else
                {
                    Icon = null;
                }
            }
        }
        public IJSObjectReference Icon { get; init; }
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
