// Added: New Interface to use Leaflet L.rectangle

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
  public interface IRectangleFactory
  {
    Task<Rectangle> Create(IEnumerable<LatLng> latLngs);
    Task<Rectangle> Create(IEnumerable<LatLng> latLngs, PolylineOptions options);
    Task<Rectangle> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map);
    Task<Rectangle> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options);
  }
}
