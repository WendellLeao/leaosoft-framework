using System.Collections.Generic;

namespace Leaosoft.Services
{
    /// <summary>
    /// The ServiceLocator can provide service abstractions.
    /// Request any registered <see cref="IGameService"/> by calling the <see cref="GetService{T}"/> method.
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<int, object> ServiceMap;

        static ServiceLocator()
        {
            ServiceMap = new Dictionary<int, object>();
        }

        public static void RegisterService<T>(T service) where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();

            ServiceMap[serviceHashCode] = service;
        }

        public static void UnregisterService<T>() where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();

            ServiceMap.Remove(serviceHashCode);
        }

        /// <summary>
        /// Returns some <see cref="IGameService"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="IGameService"/></typeparam>
        public static T GetService<T>() where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();

            ServiceMap.TryGetValue(serviceHashCode, out object service);

            return (T)service;
        }

        private static int GetServiceHashCode<T>() where T : IGameService
        {
            int serviceHashCode = typeof(T).GetHashCode();

            return serviceHashCode;
        }
    }
}
