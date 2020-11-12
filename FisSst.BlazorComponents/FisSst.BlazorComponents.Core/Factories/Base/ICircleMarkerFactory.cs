using FisSst.BlazorMaps.Models;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Factories
{
    public interface ICircleMarkerFactory
    {
        Task<CircleMarker> Create(LatLng latLng);
        Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options);
    }
}
