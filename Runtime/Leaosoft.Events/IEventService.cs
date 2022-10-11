using UnityEngine.Events;
using Leaosoft.Master;

namespace Leaosoft.Events
{
    public interface IEventService : IGameService
    {
        /// <summary>
        /// Subscribe a listener to an <see cref="ServiceEvent"/>.
        /// </summary>
        /// <param name="listener">the method that will be called after the <see cref="ServiceEvent"/> be dispatched.</param>
        /// <typeparam name="T">the <see cref="ServiceEvent"/> you want to subscribe.</typeparam>
        public void AddEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent;
        
        /// <summary>
        /// Unsubscribe a listener to an <see cref="ServiceEvent"/>.
        /// </summary>
        /// <param name="listener">the method that will be called after the <see cref="ServiceEvent"/> be dispatched.</param>
        /// <typeparam name="T">the <see cref="ServiceEvent"/> you want to unsubscribe.</typeparam>
        public void RemoveEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent;
        
        /// <summary>
        /// Invoke a <see cref="ServiceEvent"/>.
        /// </summary>
        /// <param name="serviceEvent"> the event you want to invoke.</param>
        public void DispatchEvent(ServiceEvent serviceEvent);
    }
}
