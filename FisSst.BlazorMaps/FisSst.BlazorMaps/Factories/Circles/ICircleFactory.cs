using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    ///  ICircleFactory is responsible for creating Circles and optionally adding them to the map.
    /// </summary>
    public interface ICircleFactory
    {
        Task<Circle> Create(LatLng latLng);
        Task<Circle> Create(LatLng latLng, CircleOptions options);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map);
        Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options);
    }
}
