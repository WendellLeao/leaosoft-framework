using UnityEngine;

namespace Leaosoft
{
    public interface IEntityFactory
    {
        public T CreateEntity<T>(GameObject prefab, Transform parent) where T : IEntity;
    }
}
