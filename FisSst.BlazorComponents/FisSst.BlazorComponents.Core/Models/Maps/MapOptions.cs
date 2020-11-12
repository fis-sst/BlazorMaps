namespace FisSst.BlazorMaps.Models
{
    public class MapOptions
    {
        public string DivId { get; set; }
        public LatLng Center { get; set; }
        public int Zoom { get; set; }
        public string UrlTileLayer { get; set; }
        public MapSubOptions SubOptions { get; set; }
    }
}
