using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class MarkersPage
    {
        private readonly LatLng center;
        private readonly LatLng firstMarkerLatLng;
        private readonly LatLng secondMarkerLatLng;
        private readonly LatLng thirdMarkerLatLng;
        private readonly LatLng markerWithOptionsLatLng;
        private Map mapRef;
        private Marker markerWithOptions;
        private Marker marker1;
        private Marker marker2;
        private Marker marker3;
        private MapOptions mapOptions;

        public MarkersPage()
        {
            this.center = new LatLng(50.279133, 18.685578);
            this.firstMarkerLatLng = new LatLng(50.284324, 18.664683);
            this.secondMarkerLatLng = new LatLng(50.285495, 18.691064);
            this.thirdMarkerLatLng = new LatLng(50.279103, 18.685534);
            this.markerWithOptionsLatLng = new LatLng(50.273103, 18.684534);
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
        private IMarkerFactory MarkerFactory { get; init; }
        [Inject]
        private IIconFactory IconFactory { get; init; }

        private async Task AddMarkers()
        {
            this.marker1 = await this.MarkerFactory.CreateAndAddToMap(this.firstMarkerLatLng, this.mapRef);
            this.marker2 = await this.MarkerFactory.CreateAndAddToMap(this.secondMarkerLatLng, this.mapRef);
            this.marker3 = await this.MarkerFactory.CreateAndAddToMap(this.thirdMarkerLatLng, this.mapRef);
        }

        private async Task RemoveMarkers()
        {
            await this.marker1.Remove();
            await this.marker2.Remove();
            await this.marker3.Remove();
        }

        private async Task AddMarkerWithOptions()
        {
            IconOptions iconOptions = new IconOptions()
            {
                IconUrl = "http://leafletjs.com/examples/custom-icons/leaf-green.png",
                IconSize = new Point(38, 95),
                IconAnchor = new Point(22, 94),
                ShadowUrl = "http://leafletjs.com/examples/custom-icons/leaf-shadow.png",
                ShadowSize = new Point(50, 64),
                ShadowAnchor = new Point(4, 61),
                PopupAnchor = new Point(-3, -76),
            };

            MarkerOptions markerOptions = new MarkerOptions()
            {
                Opacity = 0.5,
                Draggable = true,
                IconRef = await this.IconFactory.Create(iconOptions),
            };

            this.markerWithOptions = await this.MarkerFactory.CreateAndAddToMap(this.markerWithOptionsLatLng, this.mapRef, markerOptions);
        }

        private async Task RemoveMarkerWithOptions()
        {
            await this.markerWithOptions.Remove();
        }
    }
}
