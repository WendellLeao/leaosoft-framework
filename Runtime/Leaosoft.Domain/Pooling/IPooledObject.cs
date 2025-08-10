using UnityEngine;

namespace Leaosoft.Domain.Pooling
{
    public interface IPooledObject
    {
        public GameObject GameObject { get; }
        public string PoolId { get; set; }
    }
}
