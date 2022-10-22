using UnityEditor;

namespace Leaosoft.Editor.PackagesImporter
{
    [InitializeOnLoad]
    public static class EssentialsAssetsChecker
    {
        private const string LeaosoftAssetsPath = "Assets/Leaosoft";
        
        static EssentialsAssetsChecker()
        {
            if (HasImportedEssentials())
            {
                return;
            }
            
            if (EditorWindow.HasOpenInstances<PackagesImporterWindow>())
            {
                return;
            }

            EditorWindow.GetWindow<PackagesImporterWindow>();
        }
        
        private static bool HasImportedEssentials()
        {
            return AssetDatabase.IsValidFolder(LeaosoftAssetsPath);
        }
    }
}
