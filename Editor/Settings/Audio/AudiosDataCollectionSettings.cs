using Leaosoft.Audio;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.Settings.Audio
{
    public static class AudiosDataCollectionSettings
    {
        private static AudioData[] _audioData;

        private const string AudiosDataCollectionPath = PathUtility.DataAssetsPath + "/Audio/AudioDataCollection.asset";
        
        internal static SerializedObject GetSerializedObject()
        {
            return new SerializedObject(GetOrCreateSettings());
        }

        private static AudioDataCollection GetOrCreateSettings()
        {
            AudioDataCollection settings = AssetDatabase.LoadAssetAtPath<AudioDataCollection>(AudiosDataCollectionPath);
            
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<AudioDataCollection>();

                AssetDatabase.CreateAsset(settings, AudiosDataCollectionPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }
    }
}