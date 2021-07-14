using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class ObjectsPage
    {
        private readonly LatLng center;
        private readonly LatLng firstLatLng;
        private readonly LatLng secondLatLng;
        private readonly LatLng thirdLatLng;
        private readonly LatLng fourthLatLng;
        private readonly LatLng fifthLatLng;
        private readonly LatLng sixthLatLng;
        private readonly LatLng seventhLatLng;
        private readonly LatLng eighthLatLng;
        private readonly LatLng ninthLatLng;
        private readonly LatLng tenthLatLng;
        private readonly LatLng eleventhLatLng;
        private readonly LatLng twelfthLatLng;
        private readonly LatLng thirteenthLatLng;
        private readonly LatLng fourteenthLatLng;
        private readonly LatLng fifteenthLatLng;
        private readonly LatLng sixteenthLatLng;
        private readonly LatLng seventeenthLatLng;
        private readonly LatLng eighteenthLatLng;
        private Map mapRef;
        private Polyline polyline1;
        private Polyline polyline2;
        private Polygon polygon1;
        private Polygon polygon2;
        private CircleMarker circleMarker1;
        private CircleMarker circleMarker2;
        private Circle circle1;
        private Circle circle2;
        private MapOptions mapOptions;
        private PolylineOptions polylineOptions;
        private PolylineOptions polylineOptions2;
        private PolygonOptions polygonOptions;
        private PolygonOptions polygonOptions2;
        private CircleMarkerOptions circleMarkerOptionsInit;
        private CircleMarkerOptions circleMarkerOptions;
        private CircleMarkerOptions circleMarkerOptions2;
        private CircleOptions circleOptionsInit;
        private CircleOptions circleOptions;
        private CircleOptions circleOptions2;

        public ObjectsPage()
        {
            this.center = new LatLng(50.279133, 18.685578);
            this.firstLatLng = new LatLng(50.284324, 18.664683);
            this.secondLatLng = new LatLng(50.285495, 18.691064);
            this.thirdLatLng = new LatLng(50.306061, 18.707469);
            this.fourthLatLng = new LatLng(50.279103, 18.685534);
            this.fifthLatLng = new LatLng(50.268534, 18.673535);
            this.sixthLatLng = new LatLng(50.268235, 18.695198);
            this.seventhLatLng = new LatLng(50.273202, 18.705697);
            this.eighthLatLng = new LatLng(50.2905456, 18.634743);
            this.ninthLatLng = new LatLng(50.287532, 18.615791);
            this.tenthLatLng = new LatLng(50.295247, 18.579297);
            this.eleventhLatLng = new LatLng(50.298249, 18.650836);
            this.twelfthLatLng = new LatLng(50.304129, 18.635537);
            this.thirteenthLatLng = new LatLng(50.304403, 18.613286);
            this.fourteenthLatLng = new LatLng(50.31915, 18.633894);
            this.fifteenthLatLng = new LatLng(50.276159, 18.599046);
            this.sixteenthLatLng = new LatLng(50.270142, 18.641009);
            this.seventeenthLatLng = new LatLng(50.263766, 18.705137);
            this.eighteenthLatLng = new LatLng(50.283783, 18.724827);
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
            this.polylineOptions = new PolylineOptions()
            {
                Weight = 10,
                Color = "red"
            };
            this.polylineOptions2 = new PolylineOptions()
            {
                Weight = 5,
                Color = "green"
            };
            this.polygonOptions = new PolygonOptions()
            {
                Weight = 10,
                Color = "red"
            };
            this.polygonOptions2 = new PolygonOptions()
            {
                Weight = 5,
                Color = "green"
            };
            this.circleMarkerOptionsInit = new CircleMarkerOptions()
            {
                Radius = 50
            };
            this.circleMarkerOptions = new CircleMarkerOptions()
            {
                Color = "red",
                Radius = 5
            };
            this.circleMarkerOptions2 = new CircleMarkerOptions()
            {
                Color = "green",
                Radius = 30
            };
            this.circleOptionsInit = new CircleOptions()
            {
                Radius = 100
            };
            this.circleOptions = new CircleOptions()
            {
                Color = "red"
            };
            this.circleOptions2 = new CircleOptions()
            {
                Color = "green"
            };
        }

        [Inject]
        private IPolylineFactory PolylineFactory { get; init; }
        [Inject]
        private IPolygonFactory PolygonFactory { get; init; }
        [Inject]
        private ICircleMarkerFactory CircleMarkerFactory { get; init; }
        [Inject]
        private ICircleFactory CircleFactory { get; init; }

        private async Task AddPolylines()
        {
            this.polyline1 = await this.PolylineFactory.CreateAndAddToMap(new List<LatLng> { this.firstLatLng, this.eighteenthLatLng, this.secondLatLng, this.thirdLatLng }, this.mapRef);
            this.polyline2 = await this.PolylineFactory.CreateAndAddToMap(new List<LatLng> { this.fourthLatLng, this.fifthLatLng }, this.mapRef);
        }

        private async Task ChangePolylineStyle()
        {
            await this.polyline1.SetStyle(this.polylineOptions);
            await this.polyline2.SetStyle(this.polylineOptions2);
        }

        private async Task DeletePolylines()
        {
            await this.polyline1.Remove();
            await this.polyline2.Remove();
        }

        private async Task AddPolygons()
        {
            this.polygon1 = await this.PolygonFactory.CreateAndAddToMap(new List<LatLng> { this.eighthLatLng, this.ninthLatLng, this.tenthLatLng }, this.mapRef);
            this.polygon2 = await this.PolygonFactory.CreateAndAddToMap(new List<LatLng> { this.eleventhLatLng, this.twelfthLatLng, this.thirteenthLatLng, this.fourteenthLatLng }, this.mapRef);
        }

        private async Task ChangePolygonStyle()
        {
            await this.polygon1.SetStyle(this.polygonOptions);
            await this.polygon2.SetStyle(this.polygonOptions2);
        }

        private async Task DeletePolygons()
        {
            await this.polygon1.Remove();
            await this.polygon2.Remove();
        }

        private async Task AddCircleMarkers()
        {
            this.circleMarker1 = await this.CircleMarkerFactory.CreateAndAddToMap(this.fifteenthLatLng, this.mapRef, this.circleMarkerOptionsInit);
            this.circleMarker2 = await this.CircleMarkerFactory.CreateAndAddToMap(this.sixteenthLatLng, this.mapRef);
        }

        private async Task ChangeCircleMarkerStyle()
        {
            await this.circleMarker1.SetStyle(this.circleMarkerOptions);
            await this.circleMarker2.SetStyle(this.circleMarkerOptions2);
        }

        private async Task DeleteCircleMarkers()
        {
            await this.circleMarker1.Remove();
            await this.circleMarker2.Remove();
        }

        private async Task AddCircles()
        {
            this.circle1 = await this.CircleFactory.CreateAndAddToMap(this.seventeenthLatLng, this.mapRef, this.circleOptionsInit);
            this.circle2 = await this.CircleFactory.CreateAndAddToMap(this.eighteenthLatLng, this.mapRef);
        }

        private async Task ChangeCircleStyle()
        {
            await this.circle1.SetStyle(this.circleOptions);
            await this.circle2.SetStyle(this.circleOptions2);
            await this.circle2.SetRadius(300);
        }

        private async Task DeleteCircles()
        {
            await this.circle1.Remove();
            await this.circle2.Remove();
        }
    }
}
