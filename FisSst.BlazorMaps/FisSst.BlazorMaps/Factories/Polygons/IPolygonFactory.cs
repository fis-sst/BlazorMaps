using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// It is responsible for creating Polygons and optionally adding them to the Map.
    /// </summary>
    public interface IPolygonFactory
    {
        Task<Polygon> Create(IEnumerable<LatLng> latLngs);
        Task<Polygon> Create(IEnumerable<LatLng> latLngs, PolylineOptions options);
        Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map);
        Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options);
    }
}
