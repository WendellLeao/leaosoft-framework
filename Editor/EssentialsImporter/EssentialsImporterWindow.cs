using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.EssentialsImporter
{
    public sealed class EssentialsImporterWindow : EditorWindow
    {
        private static string[] _essentialPackagesPath =
        {   
            EssentialsPackagePath,
            InputServicePackagePath
        };
        
        private static string[] _essentialPackagesName =
        {   
            EssentialsPackageName,
            InputServicePackageName
        };
        
        private const string LeaosoftAssetsPath = "Assets/Leaosoft";
        private const string EssentialsPackagePath = "Packages/com.leaosoft.core/Packages/Essentials.unitypackage";
        private const string InputServicePackagePath = "Packages/com.leaosoft.core/Packages/InputService.unitypackage";
        
        private const string EssentialsPackageName = "Essentials";
        private const string InputServicePackageName = "InputService";

        private const float _minWindowWidth = 600f;
        private const float _minWindowHeight = 120f;
        
        [MenuItem("Leaosoft/Import Essentials")]
        public static void ShowWindow()
        {
            EssentialsImporterWindow window = GetWindow<EssentialsImporterWindow>();

            window.titleContent = new GUIContent("Leaosoft Importer");
            
            CenterWindow(window);
            
            window.Focus();
        }

        [InitializeOnLoadMethod]
        private static void CheckAndShowWindow()
        {
            if (HasOpenInstances<EssentialsImporterWindow>())
            {
                return;
            }
            
            EditorSceneManager.sceneOpened += (scene, mode) =>
            {
                //TODO: Fix this hard coded check
                bool hasEssentials = AssetDatabase.IsValidFolder(LeaosoftAssetsPath);
                
                if (hasEssentials)
                {
                    return;
                }
                
                ShowWindow();
            };
        }
        
        [InitializeOnLoadMethod]
        private static void CheckImportingAndCloseWindow()
        {
            if (!HasOpenInstances<EssentialsImporterWindow>())
            {
                return;
            }
            
            AssetDatabase.importPackageCompleted += (string importedPackageName) =>
            {
                foreach (string essentialPackageName in _essentialPackagesName)
                {
                    if (!importedPackageName.Contains(essentialPackageName))
                    {
                        continue;
                    }
                    
                    EssentialsImporterWindow window = GetWindow<EssentialsImporterWindow>();
                    
                    window.Close();
                    
                    return;
                }
            };
        }

        private static void CenterWindow(EssentialsImporterWindow window)
        {
            Rect main = EditorGUIUtility.GetMainWindowPosition();
            
            Rect pos = window.position;
            
            float width = (main.width - pos.width) * 0.5f;
            float height = (main.height - pos.height) * 0.5f;
            
            window.minSize = new Vector2(_minWindowWidth, _minWindowHeight);
            window.position = new Rect(main.x + width, main.y + height, _minWindowWidth, _minWindowHeight);
        }

        private static void SetupLabelField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                richText = true,
                wordWrap = true,
                fontSize = 13
            };
            
            EditorGUILayout.LabelField("Thank you for download the <b>Leaosoft Framework package</b>. " +
                                       "Import the essentials to integrate new services and resources " +
                                       "to your project. Importing the essentials you will be able to " +
                                       "edit scripts and add new features much easier.", labelStyle);
        }
        
        private void OnGUI()
        {
            GUILayout.Space(10);
            
            SetupLabelField();

            GUILayout.Space(20);
            
            if (GUILayout.Button("Import"))
            {
                ImportEssentials();
            }
        }

        private static void ImportEssentials()
        {
            foreach (string package in _essentialPackagesPath)
            {
                AssetDatabase.ImportPackage(package, false);
            }
        }
    }
}
