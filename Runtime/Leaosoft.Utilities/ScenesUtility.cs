using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaosoft.Utilities
{
    public static class ScenesUtility
    {
        public static void LoadNextScene(bool async = false)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning($"There's no scene to load after '{SceneManager.GetActiveScene().name}'!");
                return;
            }

            if (async)
            {
                SceneManager.LoadSceneAsync(nextSceneIndex);
                return;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        public static string[] GetBuildSettingsScenesPath()
        {
            string[] scenesPath = new string[SceneManager.sceneCountInBuildSettings];

            for (int i = 0; i < scenesPath.Length; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);

                scenesPath[i] = scenePath;
            }

            return scenesPath;
        }
    }
}
