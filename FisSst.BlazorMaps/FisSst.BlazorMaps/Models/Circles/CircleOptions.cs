namespace FisSst.BlazorMaps
{
    /// <summary>
    /// CircleOptions include circles' radius and determine whether it's filled or not.
    /// </summary>
    public class CircleOptions : PathOptions
    {
        public CircleOptions()
        {
            Fill = true;
            Radius = DefaultRadius;
        }

        private const double DefaultRadius = 10;
        public double Radius { get; init; }
    }
}
