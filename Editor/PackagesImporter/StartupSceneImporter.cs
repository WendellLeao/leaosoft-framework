using System.Collections.Generic;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Leaosoft.Editor.PackagesImporter
{
    public static class StartupSceneImporter
    {
        private static readonly List<EditorBuildSettingsScene> BuildSettingsScenes = new();

        private const string StartupScenePath = PathUtility.AssetsPath + "/Scenes/StartupScene.unity";
        
        public static void AddStartupSceneIntoBuildSettings()
        {
            EditorBuildSettingsScene[] buildSettingsScenes = GetPopulatedBuildSettingsScene();

            EditorBuildSettings.scenes = buildSettingsScenes;
            
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(StartupScenePath);
        }

        private static EditorBuildSettingsScene[] GetPopulatedBuildSettingsScene()
        {
            BuildSettingsScenes.Clear();

            BuildSettingsScenes.Add(new EditorBuildSettingsScene(StartupScenePath, true));
            
            foreach (string scenePath in ScenesUtility.GetBuildSettingsScenesPath())
            {
                BuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
            }

            return BuildSettingsScenes.ToArray();
        }
    }
}