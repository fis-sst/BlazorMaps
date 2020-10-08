﻿export function onCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (event) => {
        dotnetHelper.invokeMethodAsync('OnCallback', eventType, {
            type: event.type,
            latLng: event.latlng,
        });        
    });
}