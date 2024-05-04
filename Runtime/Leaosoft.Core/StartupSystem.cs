using UnityEngine;

namespace Leaosoft.Core
{
    public sealed class StartupSystem : System
    {
        [SerializeField]
        private ServicesManager _servicesManager;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _servicesManager.Initialize();

            StartupSceneLoader.HandleLoadScene();
        }
    }
}
