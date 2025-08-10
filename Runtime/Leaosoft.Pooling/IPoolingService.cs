using Leaosoft.Domain.Pooling;
using Leaosoft.Services;

namespace Leaosoft.Pooling
{
    public interface IPoolingService : IGameService
    {
        /// <summary>
        /// Attempts to get a pooled object from the given pool.
        /// </summary>
        /// <param name="poolId">ID of the pool.</param>
        /// <param name="result">Returned object if successful.</param>
        public bool TryGetObjectFromPool<T>(string poolId, out T result) where T : IPooledObject;
        
        /// <summary>
        /// Returns an object to its pool for reuse.
        /// </summary>
        /// <param name="pooledObject">Object to return.</param>
        public void ReleaseObjectToPool(IPooledObject pooledObject);
    }
}
