using Leaosoft.Services;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.Settings.Services
{
    public static class GameServicesCollectionSettings
    {
        private static GameService[] gameServices;

        private const string AudiosDataCollectionPath = PathUtility.DataAssetsPath + "/Services/GameServicesCollection.asset";
        
        internal static SerializedObject GetSerializedObject()
        {
            return new SerializedObject(GetOrCreateSettings());
        }

        private static GameServicesCollection GetOrCreateSettings()
        {
            GameServicesCollection settings = AssetDatabase.LoadAssetAtPath<GameServicesCollection>(AudiosDataCollectionPath);
            
            if (!settings)
            {
                settings = ScriptableObject.CreateInstance<GameServicesCollection>();

                AssetDatabase.CreateAsset(settings, AudiosDataCollectionPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }
    }
}
