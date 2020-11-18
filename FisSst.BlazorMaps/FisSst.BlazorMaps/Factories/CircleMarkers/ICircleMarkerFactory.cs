using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// ICircleMarkerFactory is responsible for creating Circlemarkers and optionally adding them to the map.
    /// </summary>
    public interface ICircleMarkerFactory
    {
        Task<CircleMarker> Create(LatLng latLng);
        Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options);
    }
}
