export function onCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (mouseEvent) => {
        dotnetHelper.invokeMethodAsync('OnCallback', eventType, {
            type: mouseEvent.type,
            latLng: mouseEvent.latlng,
        });        
    });
}