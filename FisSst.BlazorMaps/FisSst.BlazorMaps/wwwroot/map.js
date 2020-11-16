export function initialize(mapOptions) {
    const newMap = L.map(mapOptions.divId).setView(mapOptions.center, mapOptions.zoom);
    L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(newMap);
    return newMap;
}