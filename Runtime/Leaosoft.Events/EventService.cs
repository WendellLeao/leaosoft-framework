using System.Collections.Generic;
using UnityEngine.Events;
using Leaosoft.Services;
using System;
using UnityEngine;

namespace Leaosoft.Events
{
    /// <summary>
    /// The EventService provides the abstraction <see cref="IEventService"/> to dispatch, add or remove an event anywhere in the game.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    public sealed class EventService : GameService, IEventService
    {
        private readonly Dictionary<Type, object> _eventDictionary = new();

        public void AddEventListener<T>(UnityAction<T> listener) where T : GameEvent
        {
            Type type = typeof(T);

            if (_eventDictionary.TryGetValue(type, out object existingEvent))
            {
                UnityEvent<T> unityEvent = (UnityEvent<T>)existingEvent;
                
                unityEvent.AddListener(listener);
                
                return;
            }

            UnityEvent<T> newEvent = new();

            newEvent.AddListener(listener);

            _eventDictionary.Add(type, newEvent);
        }

        public void RemoveEventListener<T>(UnityAction<T> listener) where T : GameEvent
        {
            Type type = typeof(T);

            if (!_eventDictionary.TryGetValue(type, out object existingEvent))
            {
                Debug.LogWarning($"There's no listener registered for the event '{type.Name}'!");
                return;
            }
            
            UnityEvent<T> unityEvent = (UnityEvent<T>)existingEvent;
            
            unityEvent.RemoveListener(listener);
        }

        public void DispatchEvent<T>(T eventToDispatch) where T : GameEvent
        {
            Type type = typeof(T);

            if (!_eventDictionary.TryGetValue(type, out object gameEvent))
            {
                Debug.LogWarning($"There's no listener registered for the event '{type.Name}'!");
                return;
            }
            
            UnityEvent<T> unityEvent = (UnityEvent<T>)gameEvent;
            
            unityEvent.Invoke(eventToDispatch);
        }

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IEventService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IEventService>();
        }
    }
}
