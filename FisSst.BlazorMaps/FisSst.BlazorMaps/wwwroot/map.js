export function initialize(mapOptions) {
    const newMap = L.map(mapOptions.divId).setView(mapOptions.center, mapOptions.zoom);
    if (mapOptions.urlTileLayer)
        L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(newMap);
    return newMap;
}