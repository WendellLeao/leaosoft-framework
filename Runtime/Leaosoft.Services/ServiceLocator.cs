using System.Collections.Generic;
using Leaosoft.Master;

namespace Leaosoft.Services
{
    /// <summary>
    /// The ServiceLocator can provide service abstractions.
    /// Request any registered <see cref="IGameService"/> by calling the <see cref="GetService{T}"/> method.
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<int, object> _serviceMap;

        static ServiceLocator()
        {
            _serviceMap = new Dictionary<int, object>();
        }

        public static void RegisterService<T>(T service) where T : IGameService
        {
            _serviceMap[typeof(T).GetHashCode()] = service;
        }

        public static void DeregisterService<T>() where T : IGameService
        {
            _serviceMap.Remove(typeof(T).GetHashCode());
        }

        /// <summary>
        /// Returns some <see cref="IGameService"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="IGameService"/></typeparam>
        public static T GetService<T>() where T : IGameService
        {
            _serviceMap.TryGetValue(typeof(T).GetHashCode(), out object service);

            return (T) service;
        }
    }
}
