using System.Collections.Generic;

namespace FisSst.BlazorMaps
{
  public class LatLngBounds
  {
    public LatLngBounds()
    {
    }

    public LatLngBounds(LatLng southwest, LatLng northeast)
    {
      _southWest = southwest;
      _northEast = northeast;
    }

    public LatLng _southWest { get; set; }
    public LatLng _northEast { get; set; }

    public IEnumerable<LatLng> ToLatLng()
    {
      return new List<LatLng>() { _southWest, _northEast };
    }
  }
}
