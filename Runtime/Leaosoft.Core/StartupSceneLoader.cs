using Leaosoft.Utilities;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Core
{
    public static class StartupSceneLoader
    {
        private const string MenuPath = PathUtility.ToolsPath + "/Load Startup Scene On Play";
        private const string LoadStartupSceneOnPlayKey = "LoadStartupSceneOnPlay";
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
            bool isLoadStartupOnPlayToggled  = IsLoadStartupOnPlayToggled();
            
            if (!isLoadStartupOnPlayToggled || HasLoadedStartupScene)
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

        [MenuItem(MenuPath)]
        private static void ToggleFullscreen()
        {
            bool isLoadStartupOnPlayToggled = !IsLoadStartupOnPlayToggled();
            
            EditorPrefs.SetBool(LoadStartupSceneOnPlayKey, isLoadStartupOnPlayToggled);
            
            Menu.SetChecked(MenuPath, isLoadStartupOnPlayToggled);
        }

        [MenuItem(MenuPath, isValidateFunction: true)]
        private static bool ToggleFullscreenValidate()
        {
            bool isLoadStartupOnPlayToggled  = IsLoadStartupOnPlayToggled();
            
            Menu.SetChecked(MenuPath, isLoadStartupOnPlayToggled);
            
            return true;
        }

        private static bool IsLoadStartupOnPlayToggled()
        {
            return EditorPrefs.GetBool(LoadStartupSceneOnPlayKey, false);
        }
    }
}
