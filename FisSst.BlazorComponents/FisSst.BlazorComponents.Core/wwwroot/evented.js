export function onCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (event) => {
        console.log(event);
        dotnetHelper.invokeMethodAsync('OnCallback', eventType, {
            type: event.type,
            latLng: event.latlng,
        });        
    });
}