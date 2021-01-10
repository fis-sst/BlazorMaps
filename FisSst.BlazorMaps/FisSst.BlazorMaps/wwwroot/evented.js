export function onMouseCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, (mouseEvent) => {
        dotnetHelper.invokeMethodAsync('OnMouseCallbackCalled', eventType, {
            type: mouseEvent.type,
            latLng: mouseEvent.latlng,
        });        
    });
}