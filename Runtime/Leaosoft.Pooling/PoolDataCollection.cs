using UnityEngine;

namespace Leaosoft.Pooling
{
    public sealed class PoolDataCollection : ScriptableObject
    {
        [SerializeField]
        private PoolData[] poolData;

        public PoolData[] PoolData => poolData;

        public bool TryGetDataById(string poolId, out PoolData result)
        {
            foreach (PoolData data in poolData)
            {
                if (string.Equals(data.Id, poolId))
                {
                    result = data;
                    return true;
                }
            }
            
            Debug.LogError($"Couldn't find any {nameof(PoolData)} with id '{poolId}'");

            result = null;
            return false;
        }
    }
}
