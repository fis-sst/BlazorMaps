using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public interface IMarkerFactory
    {
        Task<Marker> Create(LatLng latLng);
        Task<Marker> Create(LatLng latLng, MarkerOptions options);
        Task<Marker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options);
    }
}
