namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Determines Path's properties.
    /// </summary>
    public class PathOptions : InteractiveLayerOptions
    {
        public PathOptions()
        {
            Stroke = true;
            Color = DefaultColor;
            Weight = DefaultWeight;
            Opacity = DefaultOpacity;
            LineCap = DefaultLineCap;
            LineJoin = DefaultLineJoin;
            DashArray = null;
            DashOffset = null;
            Fill = false;
            FillColor = null;
            FillOpacity = DefaultFillOpacity;
            FillRule = DefaultFillRule;
            BubblingMouseEvents = true;
            ClassName = null;
            Interactive = true;
            Pane = DefaultPane;
            Attribution = null;
        }

        private const string DefaultColor = "#3388ff";
        private const int DefaultWeight = 3;
        private const double DefaultOpacity = 1.0;
        private const string DefaultLineCap = "round";
        private const string DefaultLineJoin = "round";
        private const double DefaultFillOpacity = 0.2;
        private const string DefaultFillRule = "evenodd";
        private const string DefaultPane = "overlayPane";
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
