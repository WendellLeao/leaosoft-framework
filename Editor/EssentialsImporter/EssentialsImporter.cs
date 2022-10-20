using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.EssentialsImporter
{
    public class EssentialsImporter : EditorWindow
    {
        private const string InputServicePackagePath = "Packages/com.leaosoft.core/Essentials/InputService.unitypackage";

        private const float _minWindowWidth = 600f;
        private const float _minWindowHeight = 120f;
        
        [MenuItem("Leaosoft/Import Essentials")]
        public static void ShowWindow()
        {
            EssentialsImporter window = GetWindow<EssentialsImporter>();

            window.titleContent = new GUIContent("Leaosoft Import Essentials");
            
            CenterWindow(window);
            
            window.Focus();
        }

        private static void CenterWindow(EssentialsImporter window)
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
                wordWrap = true,
                fontSize = 13
            };
            
            EditorGUILayout.LabelField("Thank you for download the Leaosoft Framework package. " +
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
            string[] packageNames =
            {
                InputServicePackagePath
            };

            foreach (string package in packageNames)
            {
                AssetDatabase.ImportPackage(package, false);
            }
        }
    }
}
