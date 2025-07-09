using UnityEngine;

namespace Leaosoft.Core
{
    /// <summary>
    /// Controls the game's initialization.
    /// </summary>
    public sealed class StartupSystem : System
    {
        [SerializeField]
        private ServicesManager servicesManager;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            servicesManager.Initialize();

            StartupSceneLoader.HandleLoadScene();
        }
    }
}
