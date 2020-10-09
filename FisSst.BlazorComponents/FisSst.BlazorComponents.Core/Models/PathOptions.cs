namespace FisSst.Maps.Models
{
    public class PathOptions : InteractiveLayerOptions
    {
        public PathOptions()
        {
            Stroke = true;
            Color = "#3388ff";
            Weight = 3;
            Opacity = 1.0;
            Fill = false;
            FillColor = null;
            FillOpacity = 0.2;
            BubblingMouseEvents = true;
            ClassName = null;
        }

        public bool Stroke { get; init; }
        public string Color { get; init; }
        public int Weight { get; init; }
        public double Opacity { get; init; }
        public bool Fill { get; init; }
        public string FillColor { get; init; }
        public double FillOpacity { get; init; }
        public bool BubblingMouseEvents { get; init; }
        public string ClassName { get; init; }
    }
}
