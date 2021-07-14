using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class TestsPage
    {
        private readonly double firstLat;
        private readonly double secondLat;
        private readonly double firstLng;
        private readonly double secondLng;
        private readonly MatTheme matTheme;
        private Map mapRef;
        private List<Marker> markers = new List<Marker>();
        private Stopwatch stopwatch = new Stopwatch();
        private MapOptions mapOptions;

        public TestsPage()
        {
            this.firstLat = 50.24;
            this.secondLat = 50.30;
            this.firstLng = 18.62;
            this.secondLng = 18.75;
            this.matTheme = new MatTheme()
            {
                Primary = "#CBE54E"
            };
            this.mapOptions = new MapOptions()
            {
                DivId = "mapId",
                Center = new LatLng(50.279133, 18.685578),
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
        public int NumberOfMarkers { get; set; }

        private async Task AddMarkers()
        {
            List<LatLng> coordinates = GenerateListOfCoordinates();

            this.stopwatch.Restart();
            this.stopwatch.Start();

            for (int i = 0; i < this.NumberOfMarkers; i++)
            {
                Marker marker = await MarkerFactory.CreateAndAddToMap(coordinates[i], this.mapRef);
                this.markers.Add(marker);
            }

            this.stopwatch.Stop();
            StateHasChanged();
        }

        private void RemoveMarkers()
        {
            this.stopwatch.Restart();
            this.stopwatch.Start();
            this.markers.ForEach(async marker => await marker.Remove());
            this.stopwatch.Stop();
            this.markers = new List<Marker>();
            StateHasChanged();
        }

        private List<LatLng> GenerateListOfCoordinates()
        {
            List<LatLng> coordinates = new List<LatLng>();
            for (int i = 0; i < this.NumberOfMarkers; i++)
            {
                coordinates.Add(GetRandomLatLng());
            }

            return coordinates;
        }

        private LatLng GetRandomLatLng()
        {
            Random random = new Random();
            double lat = random.NextDouble() * (this.secondLat - this.firstLat) + this.firstLat;
            double lng = random.NextDouble() * (this.secondLng - this.firstLng) + this.firstLng;
            return new LatLng(lat, lng);
        }
    }
}
