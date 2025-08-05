#if UNITY_EDITOR
using Leaosoft.Utilities;
using UnityEditor;

namespace Leaosoft.Editor
{
    public static class StartupScenePreferences
    {
        public static bool IsEnabled => EditorPrefs.GetBool(LoadStartupSceneOnPlayKey, false);

        private const string MenuPath = PathUtility.ToolsPath + "/Load Startup Scene On Play";
        private const string LoadStartupSceneOnPlayKey = "LoadStartupSceneOnPlay";

        [MenuItem(MenuPath)]
        private static void Toggle()
        {
            bool newValue = !IsEnabled;
            
            EditorPrefs.SetBool(LoadStartupSceneOnPlayKey, newValue);
            
            Menu.SetChecked(MenuPath, newValue);
        }

        [MenuItem(MenuPath, isValidateFunction: true)]
        private static bool ToggleValidate()
        {
            Menu.SetChecked(MenuPath, IsEnabled);
            return true;
        }
    }
}
#endif
