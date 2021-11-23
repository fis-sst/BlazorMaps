// Added: Model Class for Rectangle

using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
  /// <summary>
  /// A rectangle
  /// </summary>
  public class Rectangle : Polyline
  {
    internal Rectangle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
  }
}
