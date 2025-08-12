using UnityEngine;

namespace Leaosoft.Pooling
{
    public interface IPooledObject
    {
        public GameObject gameObject { get; }
        public Transform transform { get; }
        public string PoolId { get; set; }
    }
}
