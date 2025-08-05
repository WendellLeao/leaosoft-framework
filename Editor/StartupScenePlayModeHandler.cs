#if UNITY_EDITOR
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Leaosoft.Editor
{
    [InitializeOnLoad]
    public static class StartupScenePlayModeHandler
    {
        private const string OriginalScenePathKey = "StartupScene_OriginalScenePath";
        private const string ShouldReturnToOriginalSceneKey = "StartupScene_ShouldReturn";
        private const string HasRedirectedKey = "StartupScene_HasRedirected";
        
        private const string StartupScenePath = PathUtility.AssetsPath + "/Scenes/StartupScene.unity";

        static StartupScenePlayModeHandler()
        {
            EditorApplication.playModeStateChanged += HandlePlayModeStateChanged;
        }

        private static void HandlePlayModeStateChanged(PlayModeStateChange state)
        {
            if (!StartupScenePreferences.IsEnabled)
            {
                return;
            }

            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode:
                {
                    HandleExitingEditMode();
                    break;
                }
                case PlayModeStateChange.EnteredEditMode:
                {
                    HandleEnteredEditMode();
                    break;
                }
            }
        }

        private static void HandleExitingEditMode()
        {
            if (EditorPrefs.GetBool(HasRedirectedKey, false))
            {
                return;
            }
            
            string currentScenePath = SceneManager.GetActiveScene().path;
            bool shouldReturn = currentScenePath != StartupScenePath;

            EditorPrefs.SetString(OriginalScenePathKey, currentScenePath);
            EditorPrefs.SetBool(ShouldReturnToOriginalSceneKey, shouldReturn);
            
            if (!shouldReturn)
            {
                return;
            }
            
            PauseApplicationAndOpenStartupScene();

            EditorPrefs.SetBool(HasRedirectedKey, true);
        }

        private static void PauseApplicationAndOpenStartupScene()
        {
            EditorApplication.isPlaying = false;

            EditorApplication.delayCall += () =>
            {
                EditorSceneManager.OpenScene(StartupScenePath);
                EditorApplication.isPlaying = true;
            };
        }

        private static void HandleEnteredEditMode()
        {
            string originalScenePath = EditorPrefs.GetString(OriginalScenePathKey, "");
            bool shouldReturn = EditorPrefs.GetBool(ShouldReturnToOriginalSceneKey, false);
            
            DeleteAllKeys();

            if (!shouldReturn || string.IsNullOrEmpty(originalScenePath))
            {
                return;
            }
            
            EditorApplication.delayCall += () =>
            {
                EditorSceneManager.OpenScene(originalScenePath);
            };
        }

        private static void DeleteAllKeys()
        {
            EditorPrefs.DeleteKey(OriginalScenePathKey);
            EditorPrefs.DeleteKey(ShouldReturnToOriginalSceneKey);
            EditorPrefs.DeleteKey(HasRedirectedKey);
        }
    }
}
#endif
