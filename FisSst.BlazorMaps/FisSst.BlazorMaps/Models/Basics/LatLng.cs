namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Represents coordinates - latitude and longitude.
    /// </summary>
    public class LatLng 
    {
        public LatLng()
        {
        }

        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
            Alt = 0;
        }

        public LatLng(double lat, double lng, double alt)
        {
            Lat = lat;
            Lng = lng;
            Alt = alt;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Alt { get; set; }
    }
}
