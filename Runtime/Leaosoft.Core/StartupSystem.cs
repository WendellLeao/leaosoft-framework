namespace Leaosoft.Core
{
    /// <summary>
    /// Controls the game's initialization.
    /// </summary>
    public sealed class StartupSystem : System
    {
        protected override void InitializeManagers()
        {
            if (TryGetManager(out ServiceManager serviceManager))
            {
                serviceManager.Initialize();
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            StartupSceneLoader.HandleLoadScene();
        }
    }
}
