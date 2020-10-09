using FisSst.Maps.Models;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    public interface ICircleMarkerFactory
    {
        Task<CircleMarker> Create(LatLng latLng);
        Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options);
    }
}
