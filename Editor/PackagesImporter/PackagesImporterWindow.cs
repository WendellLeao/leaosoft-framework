using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.PackagesImporter
{
    public sealed class PackagesImporterWindow : EditorWindow
    {
        private const string MenuItemPath = "Tools/Leaosoft/Importer";

        private const string LeaosoftPackagePath = "Packages/com.leaosoft.core";
        private const string EssentialsPackagePath = LeaosoftPackagePath + "/Packages/Essentials.unitypackage";
        private const string StyleSheetPath = LeaosoftPackagePath + "/Editor/PackagesImporter/PackagesImporterStyles.uss";
        
        private const float MinWindowWidth = 600f;
        private const float MinWindowHeight = 145f;
        
        [MenuItem(MenuItemPath, false, 10)]
        public static void ShowWindow()
        {
            PackagesImporterWindow window = GetWindow<PackagesImporterWindow>();
            
            window.SetupWindow();
        }

        public void SetupWindow()
        {
            SetupStyles();

            titleContent = new GUIContent("Leaosoft Importer");

            CenterWindow(this);
            
            Focus();
        }

        private void SetupStyles()
        {
            if (AssetDatabase.IsValidFolder(StyleSheetPath))
            {
                StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(StyleSheetPath);

                rootVisualElement.styleSheets.Add(styleSheet);
            }
        }

        private void CenterWindow(PackagesImporterWindow window)
        {
            Rect main = EditorGUIUtility.GetMainWindowPosition();
            
            Rect pos = window.position;
            
            float width = (main.width - pos.width) * 0.5f;
            float height = (main.height - pos.height) * 0.5f;
            
            window.minSize = new Vector2(MinWindowWidth, MinWindowHeight);
            window.position = new Rect(main.x + width, main.y + height, MinWindowWidth, MinWindowHeight);
        }

        private void OnGUI()
        {
            GUILayout.Space(10f);
            
            DrawImportEssentialsField();
        }

        private void DrawImportEssentialsField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 13
            };
            
            GUILayout.Label("Import the Essentials: ", labelStyle);

            GUILayout.Space(10f);

            DrawEssentialsLabelField();

            GUILayout.Space(20f);

            if (GUILayout.Button("Import Essentials"))
            {
                AssetDatabase.onImportPackageItemsCompleted += HandleEssentialsImportCompleted;

                AssetDatabase.ImportPackage(EssentialsPackagePath, false);
            }
        }

        private void HandleEssentialsImportCompleted(string[] obj)
        {
            AssetDatabase.onImportPackageItemsCompleted -= HandleEssentialsImportCompleted;

            StartupSceneImporter.AddStartupSceneIntoBuildSettings();
            
            Close();
        }

        private void DrawEssentialsLabelField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                richText = true,
                wordWrap = true,
                fontSize = 13
            };
            
            EditorGUILayout.LabelField(GetEssentialsLabelText(), labelStyle);
        }

        private string GetEssentialsLabelText()
        {
            return "Thank you for downloading the <b>Leaosoft Framework package</b>! " +
                   "To finish configuring, please import the Essentials files into the Assets folder " +
                   "of your project. By importing the essentials, it will be much easier " +
                   "edit scripts and add new features.";
        }
    }
}
