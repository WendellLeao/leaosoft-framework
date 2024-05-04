using System.Collections.Generic;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Leaosoft.Editor.Settings.Audio
{
    public static class AudiosDataCollectionIMGUIRegister
    {
        private const string SettingsProviderPath = PathUtility.SettingsProviderPath + "/AudioService";
        
        [SettingsProvider]
        public static SettingsProvider CreateAudiosDataCollectionSettingsProvider()
        {
            if (!AssetDatabase.IsValidFolder(PathUtility.AssetsPath))
            {
                return null;
            }

            SettingsProvider provider =
                new SettingsProvider(SettingsProviderPath, SettingsScope.Project)
                {
                    label = "Audio Service",
                    activateHandler = (searchContext, rootElement) =>
                    {
                        SerializedObject settings = AudiosDataCollectionSettings.GetSerializedObject();

                        VisualElement properties = new VisualElement()
                        {
                            style =
                            {
                                flexDirection = FlexDirection.Column
                            }
                        };

                        properties.AddToClassList("property-list");
                        rootElement.Add(properties);

                        properties.Add(new PropertyField(settings.FindProperty("_audiosData"), "Audios Data Collection"));

                        rootElement.Bind(settings);
                    },

                    keywords = new HashSet<string>(new[] { "Audios Data Collection" })
                };

            return provider;
        }
    }
}
