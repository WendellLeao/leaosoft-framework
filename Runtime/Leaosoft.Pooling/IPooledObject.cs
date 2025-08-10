using UnityEngine;

namespace Leaosoft.Pooling
{
    public interface IPooledObject
    {
        public GameObject GameObject { get; }
        public string PoolId { get; set; }
    }
}
