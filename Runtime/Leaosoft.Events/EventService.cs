using System.Collections.Generic;
using UnityEngine.Events;
using Leaosoft.Services;
using System;

namespace Leaosoft.Events
{
    /// <summary>
    /// The EventService provides the abstraction <see cref="IEventService"/> to dispatch, add or remove a event anywhere in the project.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    public sealed class EventService : IEventService
    {
        private Dictionary<Type, UnityEvent<ServiceEvent>> _eventDictionary = new Dictionary<Type, UnityEvent<ServiceEvent>>();

        public void RegisterService()
        {
            ServiceLocator.RegisterService<IEventService>(this);
        }
        
        public void UnregisterService()
        {
            ServiceLocator.DeregisterService<IEventService>();
        }
        
        public void AddEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent
        {
            Type type = typeof(T);

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
            Type type = typeof(T);

            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
        
        public void DispatchEvent(ServiceEvent serviceEvent)
        {
            Type type = serviceEvent.GetType();

            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke(serviceEvent);
            }
        }
    }
}
