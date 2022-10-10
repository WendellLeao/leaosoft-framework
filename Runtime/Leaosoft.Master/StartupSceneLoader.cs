using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupSceneLoader
    {
        public static string FirstLoadedSceneName;
        public static bool HasLoadStartupScene;
        
        private const int StartupSceneIndex = 0;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CheckActiveScene()
        {
            if (HasLoadStartupScene)
            {
                return;
            }
            
            FirstLoadedSceneName = SceneManager.GetActiveScene().name;
            
            if (SceneManager.GetActiveScene().buildIndex == StartupSceneIndex)
            {
                return;
            }

            SceneManager.LoadScene(StartupSceneIndex);

            HasLoadStartupScene = true;
        }
    }
}
