using FisSst.BlazorMaps.Models;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public interface ICircleFactory
    {
        Task<Circle> Create(LatLng latLng);
        Task<Circle> Create(LatLng latLng, CircleOptions options);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options);
    }
}
