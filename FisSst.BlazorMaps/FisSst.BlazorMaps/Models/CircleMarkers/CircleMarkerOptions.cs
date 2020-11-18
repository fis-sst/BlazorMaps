namespace FisSst.BlazorMaps
{
    /// <summary>
    /// CircleMarkerOptions include circlemarkers' radius and determine whether it's is filled or not.
    /// </summary>
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
