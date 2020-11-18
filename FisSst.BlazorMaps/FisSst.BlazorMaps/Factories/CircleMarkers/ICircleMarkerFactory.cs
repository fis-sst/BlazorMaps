using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// It is responsible for creating CircleMarkers and optionally adding them to the Map.
    /// </summary>
    public interface ICircleMarkerFactory
    {
        Task<CircleMarker> Create(LatLng latLng);
        Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options);
    }
}
