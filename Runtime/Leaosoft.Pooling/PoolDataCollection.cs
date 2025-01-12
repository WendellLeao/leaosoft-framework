using UnityEngine;

namespace Leaosoft.Pooling
{
    public sealed class PoolDataCollection : ScriptableObject
    {
        [SerializeField]
        private PoolData[] poolData;

        public PoolData[] PoolData => poolData;
    }
}
