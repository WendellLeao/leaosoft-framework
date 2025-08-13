using UnityEngine.Events;
using Leaosoft.Services;

namespace Leaosoft.Events
{
    public interface IEventService : IGameService
    {
        /// <summary>
        /// Subscribe a listener to a <see cref="GameEvent"/>.
        /// </summary>
        /// <param name="listener">the method that will be called after the <see cref="GameEvent"/> be dispatched.</param>
        /// <typeparam name="T">the <see cref="GameEvent"/> you want to subscribe.</typeparam>
        public void AddEventListener<T>(UnityAction<T> listener) where T : GameEvent;

        /// <summary>
        /// Unsubscribe a listener to a <see cref="GameEvent"/>.
        /// </summary>
        /// <param name="listener">the method that will be called after the <see cref="GameEvent"/> be dispatched.</param>
        /// <typeparam name="T">the <see cref="GameEvent"/> you want to unsubscribe.</typeparam>
        public void RemoveEventListener<T>(UnityAction<T> listener) where T : GameEvent;

        /// <summary>
        /// Invoke a <see cref="GameEvent"/>.
        /// </summary>
        /// <param name="eventToDispatch"> the event you want to invoke.</param>
        public void DispatchEvent<T>(T eventToDispatch) where T : GameEvent;
    }
}
