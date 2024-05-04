using System.Collections.Generic;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Leaosoft.Editor.Settings.Services
{
    public static class GameServicesCollectionIMGUIRegister
    {
        private const string SettingsProviderPath = PathUtility.SettingsProviderPath + "/GameServices";
        
        [SettingsProvider]
        public static SettingsProvider CreateGameServicesCollectionSettingsProvider()
        {
            if (!AssetDatabase.IsValidFolder(PathUtility.AssetsPath))
            {
                return null;
            }

            SettingsProvider provider =
                new SettingsProvider(SettingsProviderPath, SettingsScope.Project)
                {
                    label = "Game Services",
                    activateHandler = (searchContext, rootElement) =>
                    {
                        SerializedObject settings = GameServicesCollectionSettings.GetSerializedObject();

                        VisualElement properties = new VisualElement()
                        {
                            style =
                            {
                                flexDirection = FlexDirection.Column
                            }
                        };

                        properties.AddToClassList("property-list");
                        rootElement.Add(properties);

                        properties.Add(new PropertyField(settings.FindProperty("_gameServices"), "Game Services Collection"));

                        rootElement.Bind(settings);
                    },

                    keywords = new HashSet<string>(new[] { "Game Services Collection" })
                };

            return provider;
        }
    }
}
