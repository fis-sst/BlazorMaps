export function onCallback(dotnetHelper, evented, eventType) {
    evented.on(eventType, () => {
        dotnetHelper.invokeMethodAsync('OnCallback', eventType);
    });
}