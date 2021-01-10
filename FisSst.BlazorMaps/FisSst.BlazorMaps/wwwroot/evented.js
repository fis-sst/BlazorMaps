export function onMouseCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (mouseEvent) => {
        const mappedEvent = {
            type: mouseEvent.type,
            latLng: mouseEvent.latlng,
            layerPoint: mouseEvent.layerPoint,
            containerPoint: mouseEvent.containerPoint,
        };
        dotnetHelper.invokeMethodAsync('OnMouseCallbackCalled', eventType, mappedEvent);        
    });
}

export function onLocationCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (locationEvent) => {
        const mappedEvent = {
            type: locationEvent.type,
            latLng: locationEvent.latlng,
            latLngBounds: locationEvent.latLngBounds,
            accuracy: locationEvent.accuracy,
            altitude: locationEvent.altitude,
            altitudeAccuracy: locationEvent.altitudeAccuracy,
            heading: locationEvent.heading,
            speed: locationEvent.speed,
            timestamp: locationEvent.timestamp,
        };
        dotnetHelper.invokeMethodAsync('OnLocationCallbackCalled', eventType, mappedEvent);
    });
}