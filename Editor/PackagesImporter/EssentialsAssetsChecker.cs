using Leaosoft.Utilities;
using UnityEditor;

namespace Leaosoft.Editor.PackagesImporter
{
    [InitializeOnLoad]
    public static class EssentialsAssetsChecker
    {
        static EssentialsAssetsChecker()
        {
            if (AssetDatabase.IsValidFolder(PathUtility.AssetsPath))
            {
                return;
            }
            
            if (EditorWindow.HasOpenInstances<PackagesImporterWindow>())
            {
                return;
            }

            PackagesImporterWindow packagesImporterWindow = EditorWindow.GetWindow<PackagesImporterWindow>();
            
            packagesImporterWindow.SetupWindow();
        }
    }
}
