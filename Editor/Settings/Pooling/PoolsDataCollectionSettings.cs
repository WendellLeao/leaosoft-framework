using Leaosoft.Pooling;
using Leaosoft.Utilities;
using UnityEditor;
using UnityEngine;

namespace Leaosoft.Editor.Settings.Pooling
{
    public sealed class PoolsDataCollectionSettings
    {
        private PoolData[] _poolsData;

        private const string PoolsDataCollectionPath = PathUtility.DataAssetsPath + "/Pooling/PoolsDataCollection.asset";
        
        internal static SerializedObject GetSerializedObject()
        {
            return new SerializedObject(GetOrCreateSettings());
        }

        private static PoolDataCollection GetOrCreateSettings()
        {
            PoolDataCollection settings = AssetDatabase.LoadAssetAtPath<PoolDataCollection>(PoolsDataCollectionPath);
            
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<PoolDataCollection>();

                AssetDatabase.CreateAsset(settings, PoolsDataCollectionPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }
    }
}