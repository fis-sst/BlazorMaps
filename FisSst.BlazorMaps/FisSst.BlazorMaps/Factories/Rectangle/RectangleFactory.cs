// Added: New Class to use Leaflet L.rectangle

using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
  internal class RectangleFactory : IRectangleFactory
  {
    private const string create = "L.rectangle";
    private readonly IJSRuntime jsRuntime;
    private readonly IEventedJsInterop eventedJsInterop;

    public RectangleFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
    {
      this.jsRuntime = jsRuntime;
      this.eventedJsInterop = eventedJsInterop;
    }

    public async Task<Rectangle> Create(IEnumerable<LatLng> latLngs)
    {
      IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs);
      return new Rectangle(jsReference, this.eventedJsInterop);
    }

    public async Task<Rectangle> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
    {
      IJSObjectReference jsReference = await this.jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs, options);
      return new Rectangle(jsReference, this.eventedJsInterop);
    }

    public async Task<Rectangle> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
    {
      Rectangle rectangle = await this.Create(latLngs);
      await rectangle.AddTo(map);
      return rectangle;
    }

    public async Task<Rectangle> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
    {
      Rectangle rectangle = await this.Create(latLngs, options);
      await rectangle.AddTo(map);
      return rectangle;
    }
  }
}
