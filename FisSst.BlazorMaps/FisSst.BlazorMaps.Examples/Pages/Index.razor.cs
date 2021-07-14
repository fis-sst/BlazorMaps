using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class Index
    {
        private readonly LatLng center;
        private Map mapRef;
        private MapOptions mapOptions;

        public Index()
        {
            this.center = new LatLng(50.279133, 18.685578);
            this.mapOptions = new MapOptions()
            {
                DivId = "mapId",
                Center = center,
                Zoom = 13,
                UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                SubOptions = new TileLayerOptions()
                {
                    Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                    MaxZoom = 18,
                    TileSize = 512,
                    ZoomOffset = -1,
                }
            };
        }

        [Inject]
        private IJSRuntime JsRuntime { get; init; }

        private async Task GetCenterExample()
        {
            LatLng center = await this.mapRef.GetCenter();
            await this.JsRuntime.InvokeAsync<string>("alert", $"Map centered at: Lat: {center.Lat}, Lng: {center.Lng}");
        }
    }
}
