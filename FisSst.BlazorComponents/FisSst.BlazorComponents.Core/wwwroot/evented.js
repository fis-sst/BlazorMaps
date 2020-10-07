export function onCallback(dotnetHelper, eventType) {
    return dotnetHelper.invokeMethodAsync('OnCallback', eventType);
}