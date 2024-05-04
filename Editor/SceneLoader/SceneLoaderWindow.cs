using Leaosoft.Utilities;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.SceneLoader
{
    public sealed class SceneLoaderWindow : EditorWindow
    {
        [MenuItem(PathUtility.ToolsPath + "/Scene Loader")]
        public static void ShowWindow()
        {
            SceneLoaderWindow window = GetWindow<SceneLoaderWindow>();

            window.titleContent = new GUIContent("Scene Loader");
            window.minSize = new Vector2(800, 600);
        }

        private static void SetupLabel(string labelText)
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold,
                fontSize = 18
            };
            
            GUILayout.Label(labelText, labelStyle);
        }

        private void OnGUI()
        {
            if (Application.isPlaying)
            {
                GUI.enabled = false;
            }
            
            GUILayout.Space(20f);
            
            SetupLabel("Scene Loader");

            GUILayout.Space(20f);
            
            CreateScenesList();
        }
        
        private void CreateScenesList()
        {
            string[] scenePaths = ScenesUtility.GetBuildSettingsScenesPath();
            string[] sceneNames = GetSceneNames(scenePaths);

            for (int i = 0; i < scenePaths.Length; i++)
            {
                string scenePath = scenePaths[i];
                string sceneName = sceneNames[i];
                
                GUIStyle buttonStyle = new GUIStyle(EditorStyles.toolbarButton)
                {
                    fixedHeight = 45f
                };

                if (GUILayout.Button(sceneName, buttonStyle))
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                    EditorSceneManager.OpenScene(scenePath);
                }
            }
        }

        private string[] GetSceneNames(string[] scenePaths)
        {
            string[] sceneNames = new string[scenePaths.Length];
            
            for (int i = 0; i < sceneNames.Length; i++)
            {
                string scenePath = scenePaths[i];
                
                string sceneName = ExtractSceneNameFromPath(scenePath);
                
                sceneNames[i] = sceneName;
            }

            return sceneNames;
        }

        private string ExtractSceneNameFromPath(string scenePath)
        {
            string subString = scenePath.Substring(0, scenePath.Length - 6);

            string sceneName = subString.Substring(scenePath.LastIndexOf('/') + 1);

            return sceneName;
        }
    }
}
