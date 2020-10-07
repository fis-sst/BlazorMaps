export function onCallback(dotnetHelper, eventType) {
    console.log(eventType);
    return dotnetHelper.invokeMethodAsync('OnCallback', eventType)
        .then(r => console.log(r));
}