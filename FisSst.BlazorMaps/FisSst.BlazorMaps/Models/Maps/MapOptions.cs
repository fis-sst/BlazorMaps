namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Determines Map's properties.
    /// </summary>
    public class MapOptions
    {
        public string DivId { get; set; }
        public LatLng Center { get; set; }
        public int Zoom { get; set; }
        public string UrlTileLayer { get; set; }
        public TileLayerOptions SubOptions { get; set; }
    }
}
