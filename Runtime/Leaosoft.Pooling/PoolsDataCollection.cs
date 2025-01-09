using UnityEngine;

namespace Leaosoft.Pooling
{
    public sealed class PoolsDataCollection : ScriptableObject
    {
        [SerializeField]
        private PoolData[] poolsData;

        public PoolData[] PoolsData => poolsData;
    }
}
