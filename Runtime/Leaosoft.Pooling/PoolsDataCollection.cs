using UnityEngine;

namespace Leaosoft.Pooling
{
    public sealed class PoolsDataCollection : ScriptableObject
    {
        [SerializeField]
        private PoolData[] _poolsData;

        public PoolData[] PoolsData => _poolsData;
    }
}