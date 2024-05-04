using Leaosoft.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Core
{
    public static class StartupSceneLoader
    {
        private const int StartupSceneIndex = 0;

        private static int FirstLoadedSceneIndex { get; set; }
        private static bool HasLoadedStartupScene { get; set; }

        public static void HandleLoadScene()
        {
            if (HasLoadedStartupScene)
            {
                LoadFirstLoadedScene();

                return;
            }

            ScenesUtility.LoadNextScene();
        }

        private static void LoadFirstLoadedScene()
        {
            SceneManager.LoadSceneAsync(FirstLoadedSceneIndex);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CheckActiveScene()
        {
            if (HasLoadedStartupScene)
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

            HasLoadedStartupScene = true;
        }
    }
}
