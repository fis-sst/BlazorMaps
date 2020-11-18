namespace FisSst.BlazorMaps
{
    public class CircleMarkerOptions : PathOptions
    {
        public CircleMarkerOptions()
        {
            Fill = true;
            Radius = DefaultRadius;
        }

        private const double DefaultRadius = 10;
        public double Radius { get; init; }
    }
}
