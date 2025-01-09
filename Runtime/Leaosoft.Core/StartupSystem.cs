using UnityEngine;

namespace Leaosoft.Core
{
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
