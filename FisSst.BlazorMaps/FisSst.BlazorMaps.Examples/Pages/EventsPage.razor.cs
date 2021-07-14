using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class EventsPage
    {
        private readonly LatLng center;
        private Map mapRef;
        private Polygon polygon;
        private Circle circle;
        private Marker marker1;
        private Marker marker2;
        private Marker marker3;
        private MapOptions mapOptions;

        public EventsPage()
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
        [Inject]
        private IMarkerFactory MarkerFactory { get; init; }
        [Inject]
        private IPolygonFactory PolygonFactory { get; init; }
        [Inject]
        private ICircleFactory CircleFactory { get; init; }

        private async Task AddMarkersToMap()
        {
            this.marker1 = await this.MarkerFactory.CreateAndAddToMap(new LatLng(50.278133, 18.683578), this.mapRef);
            this.marker2 = await this.MarkerFactory.CreateAndAddToMap(new LatLng(50.277133, 18.670578), this.mapRef);
            this.marker3 = await this.MarkerFactory.CreateAndAddToMap(new LatLng(50.255133, 18.66578), this.mapRef);
        }

        private async Task HandleMouseEvent(MouseEvent mouseEvent)
        {
            await this.JsRuntime.InvokeVoidAsync("alert", $"Event type: {mouseEvent.Type} Lat: {mouseEvent.LatLng.Lat}, Lng: {mouseEvent.LatLng.Lng}");
        }

        private async Task AddPolygonToMap()
        {
            LatLng FirstLatLng = new LatLng(50.2905456, 18.634743);
            LatLng SecondLatLng = new LatLng(50.287532, 18.615791);
            LatLng ThirdLatLng = new LatLng(50.295247, 18.579297);
            this.polygon = await this.PolygonFactory.CreateAndAddToMap(new List<LatLng> { FirstLatLng, SecondLatLng, ThirdLatLng }, this.mapRef);
            await this.polygon.OnClick(async (MouseEvent mouseEvent) => await ChangePolygonStyle());
        }

        private async Task ChangePolygonStyle()
        {
            PolygonOptions PolygonOptions = new PolygonOptions()
            {
                Weight = 5,
                Color = "green"
            };

            await this.polygon.SetStyle(PolygonOptions);
        }

        private async Task AddCircleToMap()
        {
            CircleOptions CircleOptionsInit = new CircleOptions()
            {
                Radius = 300
            };

            this.circle = await this.CircleFactory.CreateAndAddToMap(new LatLng(50.263766, 18.705137), this.mapRef, CircleOptionsInit);
            await this.circle.OnClick(async (MouseEvent mouseEvent) => await ChangeCircleStyle());
        }

        private async Task ChangeCircleStyle()
        {
            CircleOptions CircleOptions = new CircleOptions()
            {
                Color = "green"
            };

            await this.circle.SetLatLng(new LatLng(50.283783, 18.724827));
        }

        private async Task AddEventsToMarkers()
        {
            await this.marker1.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
            await this.marker2.OnContextMenu(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
            await this.marker3.OnDblClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
        }

        private async Task RemoveEventsFromMarkers()
        {
            await this.marker1.Off("click");
            await this.marker2.Off("contextmenu");
            await this.marker3.Off("dblclick");
        }

        private async Task AddEventsToMap()
        {
            await this.mapRef.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
        }

        private async Task RemoveEventsFromMap()
        {
            await this.mapRef.Off("click");
        }
    }
}
