using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.PackagesImporter
{
    public sealed class PackagesImporterWindow : EditorWindow
    {
        private static readonly string[] _essentialPackagesPath =
        {   
            EssentialsPackagePath,
        };

        private static PackagesImporterWindow _window;

        private const string EssentialsPackagePath = "Packages/com.leaosoft.core/Packages/Essentials.unitypackage";
        private const string InputServicePackagePath = "Packages/com.leaosoft.core/Packages/InputService.unitypackage";
        
        private const string StyleSheetPath = "Packages/com.leaosoft.core/Editor/PackagesImporter/PackagesImporterStyles.uss";
        
        private const float _minWindowWidth = 600f;
        private const float _minWindowHeight = 310f;
        
        [MenuItem("Leaosoft/Importer")]
        public static void ShowWindow()
        {
            _window = GetWindow<PackagesImporterWindow>();
        }
        
        private static void CenterWindow(PackagesImporterWindow window)
        {
            Rect main = EditorGUIUtility.GetMainWindowPosition();
            
            Rect pos = window.position;
            
            float width = (main.width - pos.width) * 0.5f;
            float height = (main.height - pos.height) * 0.5f;
            
            window.minSize = new Vector2(_minWindowWidth, _minWindowHeight);
            window.position = new Rect(main.x + width, main.y + height, _minWindowWidth, _minWindowHeight);
        }

        private static void DrawEssentialsLabelField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                richText = true,
                wordWrap = true,
                fontSize = 13
            };
            
            EditorGUILayout.LabelField("Thank you for download the <b>Leaosoft Framework package</b>. " +
                                       "To finish the setup, import the essentials files into the Assets folder " +
                                       "of your project. Importing the essentials, you will be able to " +
                                       "edit scripts and add new features much easier.", labelStyle);
        }
        
        private static void DrawInputServiceLabelField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                richText = true,
                wordWrap = true,
                fontSize = 13
            };
            
            EditorGUILayout.LabelField("If you wish to import the <b>Input Service</b> to handle inputs easily, " +
                                       "just hit the button bellow and edit the InputActions and InputsData struct", labelStyle);
            
            GUILayout.Space(10f);
            
            EditorGUILayout.LabelField("<b>**When you complete the importing, be sure to add the InputService prefab reference " +
                                       "on the ServicesRegister list.</b>**", labelStyle);
        }

        private static void DrawImportEssentialsField()
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
                ImportEssentials();
            }
        }

        private static void DrawImportInputServiceField()
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 13
            };
            
            GUILayout.Label("Import the Input Service: ", labelStyle);

            GUILayout.Space(10f);
            
            DrawInputServiceLabelField();

            GUILayout.Space(20f);

            if (GUILayout.Button("Import Input Service"))
            {
                ImportInputService();
            }
        }

        private static void ImportEssentials()
        {
            foreach (string package in _essentialPackagesPath)
            {
                AssetDatabase.ImportPackage(package, false);
            }
        }
        
        private static void ImportInputService()
        {
            AssetDatabase.ImportPackage(InputServicePackagePath, false);
        }
        
        private void Awake()
        {
            SetupStyles();

            SetupWindow();
        }

        private void OnGUI()
        {
            GUILayout.Space(10f);
            
            DrawImportEssentialsField();

            GUILayout.Space(20f);
            
            DrawImportInputServiceField();
        }
        
        private void SetupStyles()
        {
            StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(StyleSheetPath);

            rootVisualElement.styleSheets.Add(styleSheet);
        }

        private void SetupWindow()
        {
            _window = GetWindow<PackagesImporterWindow>();

            _window.titleContent = new GUIContent("Leaosoft Importer");

            CenterWindow(_window);

            Focus();
        }
    }
}
