using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class PopupsPage
    {
        private readonly LatLng center;
        private readonly LatLng firstMarkerLatLng;
        private readonly LatLng secondMarkerLatLng;
        private Map mapRef;
        private bool firstRender = true;
        private Marker marker1;
        private Marker marker2;
        private MapOptions mapOptions;

        public PopupsPage()
        {
            this.center = new LatLng(50.279133, 18.685578);
            this.firstMarkerLatLng = new LatLng(50.284324, 18.664683);
            this.secondMarkerLatLng = new LatLng(50.285495, 18.691064);
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

        protected async Task AddMarkers()
        {
            if (firstRender)
            {
                this.firstRender = false;
                this.marker1 = await this.MarkerFactory.CreateAndAddToMap(this.firstMarkerLatLng, this.mapRef);
                this.marker2 = await this.MarkerFactory.CreateAndAddToMap(this.secondMarkerLatLng, this.mapRef);
            }
        }

        private async Task BindPopup()
        {
            await this.marker1.BindPopup("Hi! This is a popup");
        }

        private async Task BindTooltip()
        {
            await this.marker2.BindTooltip("And this is a tooltip");
        }

        private async Task RemovePopup()
        {
            await this.marker1.UnbindPopup();
        }

        private async Task RemoveTooltip()
        {
            await this.marker2.UnbindTooltip();
        }

        private async Task UpdatePopup()
        {
            await this.marker1.SetPopupContent("Popup has changed its content");
        }

        private async Task UpdateTooltip()
        {
            await this.marker2.SetTooltipContent("Tooltip has changed its content");
        }

        private async Task TogglePopup()
        {
            await this.marker1.TogglePopup();
        }

        private async Task ToggleTooltip()
        {
            await this.marker2.ToggleTooltip();
        }
    }
}
