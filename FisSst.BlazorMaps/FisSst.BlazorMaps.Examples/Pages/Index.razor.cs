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
                SubOptions = new MapSubOptions()
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

        [Inject]
        private IRectangleFactory RectangleFactory { get; init; }
        
        private async Task GetCenterExample()
        {
            LatLng center = await this.mapRef.GetCenter();
            await this.JsRuntime.InvokeAsync<string>("alert", $"Map centered at: Lat: {center.Lat}, Lng: {center.Lng}");
        }
        
        // Sample to demonstrate getBounds, fitBounds and Rectangle
        // At end a There will be a zoomed square with 500m radius
        private async Task SetMapInitialView(LatLng pOrigem)
        {
            CircleOptions zDummyOptions = new CircleOptions { Radius = 500, Color = "red" };                 // Set Circle Options
            Circle zDummy = await this.CircleFactory.CreateAndAddToMap(pOrigem, this.mapRef, zDummyOptions); // Place circle on map
            LatLngBounds zBounds = await zDummy.GetBounds();                                                 // Get Circle bounds (SW/NE coords)
            await zDummy.Remove();                                                                           // Remove Circle from map
            RectangleOptions zROptions = new RectangleOptions { Color = "blue" };                            // Set Rectangle Options
            Rectangle retangulo = await this.RectangleFactory.CreateAndAddToMap(zBounds.ToLatLng(), mapRef, zROptions); // Place Rectangle on map using Bounds from Circle
            await this.mapRef.FitBounds(zBounds.ToLatLng());                                                 // FitBounds, some king of Zoom All
        }
    }
}
