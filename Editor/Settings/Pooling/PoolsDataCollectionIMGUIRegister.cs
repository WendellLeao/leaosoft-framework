using System.Collections.Generic;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Leaosoft.Editor.Settings.Pooling
{
    public static class PoolsDataCollectionIMGUIRegister
    {
        private const string SettingsProviderPath = PathUtility.SettingsProviderPath + "/PoolingService";
        
        [SettingsProvider]
        public static SettingsProvider CreatePoolsDataCollectionSettingsProvider()
        {
            if (!AssetDatabase.IsValidFolder(PathUtility.AssetsPath))
            {
                return null;
            }

            SettingsProvider provider =
                new SettingsProvider(SettingsProviderPath, SettingsScope.Project)
                {
                    label = "Pooling Service",
                    activateHandler = (searchContext, rootElement) =>
                    {
                        SerializedObject settings = PoolsDataCollectionSettings.GetSerializedObject();

                        VisualElement properties = new VisualElement()
                        {
                            style =
                            {
                                flexDirection = FlexDirection.Column
                            }
                        };

                        properties.AddToClassList("property-list");
                        rootElement.Add(properties);

                        properties.Add(new PropertyField(settings.FindProperty("_poolsData"), "Pools Data Collection"));

                        rootElement.Bind(settings);
                    },

                    keywords = new HashSet<string>(new[] { "Pools Data Collection" })
                };

            return provider;
        }
    }
}
