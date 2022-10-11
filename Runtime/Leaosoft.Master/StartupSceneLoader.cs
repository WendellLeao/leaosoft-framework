using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupSceneLoader
    {
        public static string FirstLoadedSceneName;
        public static bool HasLoadStartupScene;
        
        private const string StartupSceneName = "StartupScene";
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CheckActiveScene()
        {
            if (HasLoadStartupScene)
            {
                return;
            }
            
            FirstLoadedSceneName = SceneManager.GetActiveScene().name;
            
            if (SceneManager.GetActiveScene().name == StartupSceneName)
            {
                return;
            }

            SceneManager.LoadScene(StartupSceneName);

            HasLoadStartupScene = true;
        }
    }
}
