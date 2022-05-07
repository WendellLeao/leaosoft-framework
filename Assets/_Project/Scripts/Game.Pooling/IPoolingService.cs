using UnityEngine;

namespace Game.Pooling
{
    public interface IPoolingService
    {
        GameObject GetObjectFromPool(PoolType poolType);
        void ReturnObjectToPool(PoolType objectType, GameObject objectToReturn);
    }
}
