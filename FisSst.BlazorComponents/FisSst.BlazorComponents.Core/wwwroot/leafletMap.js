window.debugPrompt = {
    showPrompt: function (message) {
        alert(message);
    }
}

window.leafletMap = {
    initializeMap: function (mapId, startCenter, startZoom, urlTileLayer, mapOptions) {
        var newMap = L.map(mapId).setView(startCenter, startZoom);

        L.tileLayer(urlTileLayer, mapOptions).addTo(newMap);
    }
};