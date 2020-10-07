export function initialize(mapOptions) {
    var newMap = L.map(mapOptions.divId).setView(mapOptions.center, mapOptions.zoom);
    L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(newMap);
    return newMap;
}

export function sayHello(dotnetHelper) {
return dotnetHelper.invokeMethodAsync('SayHello')
    .then(r => console.log(r));
}

function testCallback(callback){
    if(confirm('are you sure ?')){
        callback("test");
    }
}