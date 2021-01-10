using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// An abstract class for layers that are interactive, i.e. they
    /// can react on events such as 'click', 'mouseover' etc.
    /// </summary>
    public abstract class Evented : JsReferenceBase
    {
        protected const string OffJsFunction = "off";
        protected IEventedJsInterop EventedJsInterop;
        protected readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();
        protected readonly IDictionary<string, Func<LocationEvent, Task>> LocationEvents = new Dictionary<string, Func<LocationEvent, Task>>();

        #region AddEventListener

        protected async Task AddMouseEventListener(MouseEventType eventType, Func<MouseEvent, Task> callback)
        {
            await this.AddEventListener(eventType, callback, this.MouseEvents);
        }

        protected async Task AddLocationEventListener(LocationEventType eventType, Func<LocationEvent, Task> callback)
        {
            await this.AddEventListener(eventType, callback, this.LocationEvents);
        }        

        private async Task AddEventListener<TEvent, TEventType>(
            TEventType eventTypeValue,
            Func<TEvent, Task> callback,
            IDictionary<string, Func<TEvent, Task>> events)
                where TEvent : Event
                where TEventType : struct, Enum
        {
            string eventType = Enum.GetName(eventTypeValue);
            if (events.ContainsKey(eventType))
            {
                return;
            }
            events.Add(eventType, callback);
            await this.AddEventListener(eventTypeValue, eventType);
        }

        private async Task AddEventListener<TEventType>(TEventType eventTypeValue, string eventType)
            where TEventType : Enum
        {
            DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
            await this.EventedJsInterop.AddEventListenerInJs(eventedClass, this.JsReference, eventTypeValue, eventType);
        }

        #endregion

        #region RemoveEventListener

        protected async Task RemoveMouseEventListener(MouseEventType eventType)
        {
            await this.RemoveEventListener(eventType, this.MouseEvents);
        }

        protected async Task RemoveLocationEventListener(LocationEventType eventType)
        {
            await this.RemoveEventListener(eventType, this.LocationEvents);
        }

        private async Task RemoveEventListener<TEvent, TEventType>(
            TEventType eventTypeValue, 
            IDictionary<string, Func<TEvent, Task>> events)
                where TEvent : Event
                where TEventType : struct, Enum
        {
            string eventType = Enum.GetName(eventTypeValue);
            if (events.ContainsKey(eventType))
            {
                events.Remove(eventType);
                await this.JsReference.InvokeAsync<IJSObjectReference>(OffJsFunction, eventType);
            }
        }

        #endregion

        #region OnCallbackCalled

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [JSInvokable]
        public async Task OnMouseCallbackCalled(string eventType, MouseEvent mouseEvent)
        {
            await this.OnCallbackCalled(eventType, mouseEvent, this.MouseEvents);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [JSInvokable]
        public async Task OnLocationCallbackCalled(string eventType, LocationEvent locationEvent)
        {
            await this.OnCallbackCalled(eventType, locationEvent, this.LocationEvents);
        }

        private async Task OnCallbackCalled<TEvent>(
            string eventType, 
            TEvent mouseEvent,
            IDictionary<string, Func<TEvent, Task>> events)
                where TEvent : Event
        {
            bool isEvented = events.TryGetValue(eventType, out Func<TEvent, Task> callback);
            if (isEvented)
            {
                await callback.Invoke(mouseEvent);
            }
        }

        #endregion 
    }
}
