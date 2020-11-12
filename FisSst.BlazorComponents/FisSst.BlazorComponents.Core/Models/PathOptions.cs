namespace FisSst.BlazorMaps.Models
{
    public class PathOptions : InteractiveLayerOptions
    {
        public PathOptions()
        {
            Stroke = true;
            Color = "#3388ff";
            Weight = 3;
            Opacity = 1.0;
            LineCap = "round";
            LineJoin = "round";
            DashArray = null;
            DashOffset = null;
            Fill = false;
            FillColor = null;
            FillOpacity = 0.2;
            FillRule = "evenodd";
            BubblingMouseEvents = true;
            ClassName = null;
            Interactive = true;
            Pane = "overlayPane";
            Attribution = null;
        }

        public bool Stroke { get; init; }
        public string Color { get; init; }
        public int Weight { get; init; }
        public double Opacity { get; init; }
        public string LineCap { get; init; }
        public string LineJoin { get; init; }
        public string DashArray { get; init; }
        public string DashOffset { get; init; }
        public bool Fill { get; init; }
        public string FillColor { get; init; }
        public double FillOpacity { get; init; }
        public string FillRule { get; init; }
        public string ClassName { get; init; }
    }
}
