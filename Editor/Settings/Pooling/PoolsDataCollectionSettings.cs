using Leaosoft.Pooling;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.Settings.Pooling
{
    public static class PoolsDataCollectionSettings
    {
        private static PoolData[] poolData;

        private const string PoolsDataCollectionPath = PathUtility.DataAssetsPath + "/Pooling/PoolDataCollection.asset";
        
        internal static SerializedObject GetSerializedObject()
        {
            return new SerializedObject(GetOrCreateSettings());
        }

        private static PoolDataCollection GetOrCreateSettings()
        {
            PoolDataCollection settings = AssetDatabase.LoadAssetAtPath<PoolDataCollection>(PoolsDataCollectionPath);
            
            if (!settings)
            {
                settings = ScriptableObject.CreateInstance<PoolDataCollection>();

                AssetDatabase.CreateAsset(settings, PoolsDataCollectionPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }
    }
}
