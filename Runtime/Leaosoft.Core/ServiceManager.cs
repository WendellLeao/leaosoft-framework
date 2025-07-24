using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Core
{
    /// <summary>
    /// Initializes the services.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    public sealed class ServiceManager : Manager
    {
        [SerializeField]
        private GameServicesCollection gameServicesCollection;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            GameObject servicesContainer = CreateServicesContainer();

            GameService[] gameServices = gameServicesCollection.GameServices;

            foreach (GameService gameService in gameServices)
            {
                Instantiate(gameService, servicesContainer.transform);
            }
        }

        private static GameObject CreateServicesContainer()
        {
            GameObject gameServicesContainer = new GameObject
            {
                name = "GameServices"
            };

            DontDestroyOnLoad(gameServicesContainer);

            return gameServicesContainer;
        }
    }
}
