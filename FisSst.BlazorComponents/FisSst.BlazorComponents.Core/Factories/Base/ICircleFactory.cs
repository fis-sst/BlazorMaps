using FisSst.Maps.Models;
using System.Threading.Tasks;

namespace FisSst.Maps.Factories
{
    public interface ICircleFactory
    {
        Task<Circle> Create(LatLng latLng);
        Task<Circle> Create(LatLng latLng, CircleOptions options);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options);
    }
}
