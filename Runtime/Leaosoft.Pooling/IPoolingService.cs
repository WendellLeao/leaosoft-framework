using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Pooling
{
    public interface IPoolingService : IGameService
    {
        /// <summary>
        /// Returns some <see cref="GameObject"/> that has being spawned by the <see cref="PoolingService"/>.
        /// </summary>
        /// <param name="poolId">the id of the pool you want to get an <see cref="GameObject"/> from.</param>
        /// <returns>the requested <see cref="GameObject"/>.</returns>
        public GameObject GetObjectFromPool(string poolId);

        /// <summary>
        /// Returns an <see cref="GameObject"/> to the selected pool, so it can be used again later.
        /// </summary>
        /// <param name="poolId">the id of the pool you want to return the <see cref="GameObject"/>.</param>
        /// <param name="objectToReturn">the <see cref="GameObject"/> you want to return.</param>
        public void ReturnObjectToPool(string poolId, GameObject objectToReturn);
    }
}
