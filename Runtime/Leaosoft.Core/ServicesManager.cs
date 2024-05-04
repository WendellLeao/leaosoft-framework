﻿using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Core
{
    public sealed class ServicesManager : Manager
    {
        [SerializeField]
        private GameServicesCollection _gameServicesCollection;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            GameObject servicesContainer = CreateServicesContainer();

            GameService[] gameServices = _gameServicesCollection.GameServices;
            
            foreach (GameService gameService in gameServices)
            {
                Instantiate(gameService, servicesContainer.transform);
            }
        }

        private static GameObject CreateServicesContainer()
        {
            GameObject gameServicesContainer = new GameObject();

            gameServicesContainer.name = "GameServices";
            
            DontDestroyOnLoad(gameServicesContainer);

            return gameServicesContainer;
        }
    }
}
