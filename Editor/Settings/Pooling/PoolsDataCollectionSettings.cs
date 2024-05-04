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

        private static PoolsDataCollection GetOrCreateSettings()
        {
            PoolsDataCollection settings = AssetDatabase.LoadAssetAtPath<PoolsDataCollection>(PoolsDataCollectionPath);
            
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<PoolsDataCollection>();

                AssetDatabase.CreateAsset(settings, PoolsDataCollectionPath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }
    }
}