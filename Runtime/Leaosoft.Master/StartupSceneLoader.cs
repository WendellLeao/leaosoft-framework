using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupSceneLoader
    {
        public static int FirstLoadedSceneIndex;
        public static bool HasLoadStartupScene;
        
        private const int StartupSceneIndex = 0;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CheckActiveScene()
        {
            if (HasLoadStartupScene)
            {
                return;
            }

            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            FirstLoadedSceneIndex = activeSceneIndex;
            
            if (activeSceneIndex == StartupSceneIndex)
            {
                return;
            }

            SceneManager.LoadScene(StartupSceneIndex);

            HasLoadStartupScene = true;
        }
    }
}
