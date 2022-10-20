namespace Leaosoft.Services
{
    public interface IGameService
    {
        void Initialize();
        
        /// <summary>
        /// Registers a <see cref="IGameService"/>.
        /// </summary>
        /// <param name="service">the <see cref="IGameService"/> you want to register.</param>
        /// <typeparam name="T"><see cref="IGameService"/></typeparam>
        void RegisterService();
        
        /// <summary>
        /// Unregisters a <see cref="IGameService"/>.
        /// </summary>
        /// <param name="service">the <see cref="IGameService"/> you want to unregister.</param>
        /// <typeparam name="T"><see cref="IGameService"/></typeparam>
        void UnregisterService();
    }
}