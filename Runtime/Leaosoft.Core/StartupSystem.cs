namespace Leaosoft.Core
{
    /// <summary>
    /// Controls the game's initialization.
    /// </summary>
    public sealed class StartupSystem : System
    {
        protected override void InitializeManagers()
        {
            ServicesManager servicesManager = GetManager<ServicesManager>();
            servicesManager.Initialize();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            StartupSceneLoader.HandleLoadScene();
        }
    }
}
