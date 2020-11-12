using FisSst.BlazorMaps.Models;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Factories
{
    public interface IMarkerFactory
    {
        Task<Marker> Create(LatLng latLng);
        Task<Marker> Create(LatLng latLng, MarkerOptions options);
        Task<Marker> CreateAndAddToMap(LatLng latLng, Map map);
        Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options);
    }
}
