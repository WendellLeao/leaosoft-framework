#if UNITY_EDITOR
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaosoft.Editor.StartupSceneLoader
{
    [InitializeOnLoad]
    public static class StartupScenePlayModeHandler
    {
        private const string StartupScenePath = PathUtility.AssetsPath + "/Scenes/StartupScene.unity";
        private const string HasRedirectedKey = "StartupScene_HasRedirected";

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

            EditorPrefs.SetString(PlayerPrefsUtility.OriginalScenePathKey, currentScenePath);
            EditorPrefs.SetBool(PlayerPrefsUtility.ShouldReturnToOriginalSceneKey, shouldReturn);
            
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
                string originalScenePathKey = PlayerPrefsUtility.OriginalScenePathKey;
                string shouldReturnToOriginalSceneKey = PlayerPrefsUtility.ShouldReturnToOriginalSceneKey;
                
                string originalScenePath = EditorPrefs.GetString(originalScenePathKey, "");
                bool shouldReturnToOriginal = EditorPrefs.GetBool(shouldReturnToOriginalSceneKey, false);
                
                PlayerPrefs.SetString(originalScenePathKey, originalScenePath);
                PlayerPrefs.SetInt(shouldReturnToOriginalSceneKey, shouldReturnToOriginal ? 1 : 0);
                PlayerPrefs.Save();
                
                EditorSceneManager.OpenScene(StartupScenePath);
                
                EditorApplication.isPlaying = true;
            };
        }

        private static void HandleEnteredEditMode()
        {
            string originalScenePath = EditorPrefs.GetString(PlayerPrefsUtility.OriginalScenePathKey, "");
            bool shouldReturn = EditorPrefs.GetBool(PlayerPrefsUtility.ShouldReturnToOriginalSceneKey, false);
            
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
            EditorPrefs.DeleteKey(PlayerPrefsUtility.OriginalScenePathKey);
            EditorPrefs.DeleteKey(PlayerPrefsUtility.ShouldReturnToOriginalSceneKey);
            EditorPrefs.DeleteKey(HasRedirectedKey);
        }
    }
}
#endif
