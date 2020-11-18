namespace FisSst.BlazorMaps
{
    /// <summary>
    /// PolylineOptions determine polyline's properties.
    /// </summary>
    public class PolylineOptions : PathOptions
    {
        public PolylineOptions()
        {
            SmoothFactor = DefaultSmoothFactor;
            NoClip = false;
        }

        private const double DefaultSmoothFactor = 1.0;
        public double SmoothFactor { get; init; }
        public bool NoClip { get; init; }
    }
}
