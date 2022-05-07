using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace Game.Events
{
    public sealed class EventService : IEventService
    {
        private Dictionary<Type, UnityEvent<ServiceEvent>> _eventDictionary = new Dictionary<Type, UnityEvent<ServiceEvent>>();

        public void AddEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent
        {
            var type = typeof(T);

            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.AddListener(listener);

                return;
            }

            thisEvent = new UnityEvent<ServiceEvent>();

            thisEvent.AddListener(listener);

            _eventDictionary.Add(type, thisEvent);
        }

        public void RemoveEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent
        {
            var type = typeof(T);

            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public void DispatchEvent(ServiceEvent serviceEvent)
        {
            var type = serviceEvent.GetType();

            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke(serviceEvent);
            }
        }
    }
}
