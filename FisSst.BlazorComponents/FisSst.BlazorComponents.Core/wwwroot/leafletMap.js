window.debugPrompt = {
    showPrompt: function (message) {
        alert(message);
    }
}

window.leafletMap = {
    initializeMap: function (mapOptions) {
        console.log(mapOptions);
        var newMap = L.map(mapOptions.divId).setView(mapOptions.center, mapOptions.zoom);
        L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(newMap);
    }
};