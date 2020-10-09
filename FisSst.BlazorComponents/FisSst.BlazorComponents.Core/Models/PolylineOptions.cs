namespace FisSst.Maps.Models
{
    public class PolylineOptions : PathOptions
    {
        public PolylineOptions()
        {
            SmoothFactor = 1.0;
            NoClip = false;
        }

        public double SmoothFactor { get; init; }
        public bool NoClip { get; init; }
    }
}
