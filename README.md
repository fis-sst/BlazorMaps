# BlazorMaps

BlazorMaps is a Blazor library that provides a C# interface for maps provided by [Leaflet.js library](https://leafletjs.com/). It includes several Leaflet.js features which are easily accessible from C# level within a project and it does not require any use of JavaScript.

## Table of contents
- [Setup](setup)
- [Functionalities](functionalities)
- [Usage](usage)
- [License](license)

## Setup

1. Add NuGet package to your project in Visual Studio by choosing Tools -> NuGet Package Manager -> Browse -> Type "BlazorMaps" in a search field and find the right package.
2. Add ```builder.Services.AddBlazorLeafletMaps();``` in Main method of your Program class.
3. Add import ```@using FisSst.BlazorMaps``` to your _Import.cshtml file.
4. Add stylesheets and scripts that are required for Leaflet.js library. You can find them at [Leaflet.js website](https://leafletjs.com/).
	```
	<head>
	  <link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css"
		   integrity="sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A=="
		   crossorigin="" />
	</head>
	<body>
	    <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js"
		    integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA=="
		    crossorigin=""></script>
	</body>
	```
5. Remember to include proper dependency injections in your code, e.g.

	```
	[Inject]
	private IMarkerFactory MarkerFactory { get; init; }
	```
	Get familiar with our examples of usage and descriptive comments in public classes if you are not sure which interfaces should be injected in a given case.
## Functionalities
So far, BlazorMap includes:
* initialization of Leaflet map component,
* markers,
* objects (circles, polylines, polygons),
* events,
* popups,
* tooltips.

The above functionalities have been developed in a way that allows to use them in the same way (or at least similar) to those from Leaflet.js library. Some of them are limited or incomplete but the main goal of BlazorMaps is to cover them all.

## Usage
There is an example project available in this repository. You can play around with functionalities and execute performance tests.

An example below shows how to initialize a component with Leaflet's map in Blazor: 
```
<Map @ref="mapRef" MapOptions="@mapOptions"></Map>

<style>
    #mapId {
        height: 400px;
    }
</style>

@code {
    private Map mapRef;
    private MapOptions mapOptions = new MapOptions()
    {
        DivId = "mapId",
        Center = new LatLng(50.279133, 18.685578),
        Zoom = 13,
        UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
	SubOptions = new MapSubOptions()
        {
            Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
            TileSize = 512,
            ZoomOffset = -1,
            MaxZoom = 19,
        }
    };
}
```


## Contributing
Feel free to report issues regarding bugs and improvements. If you want to report an issue, try to stick to the rules:
* before reporting a bug make sure it is caused by BlazorMaps
* include steps to reproduce
* include information about your environment
* include minimal scope of code that is needed to reproduce your issue

In case of not being sure how to report, contact us **info@fis-sst.pl**.
## License
BlazorMaps works under MIT license. You can find the license in LICENSE.txt file in the root directory of our project.
