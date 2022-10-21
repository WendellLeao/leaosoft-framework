using Leaosoft.Editor.PackagesImporter;
using UnityEditor;

namespace Leaosoft.Master
{
    [InitializeOnLoad]
    public static class EssentialsChecker
    {
        private const string LeaosoftAssetsPath = "Assets/Leaosoft";
        
        static EssentialsChecker()
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
