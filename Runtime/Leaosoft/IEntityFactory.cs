using UnityEngine;

namespace Leaosoft
{
    public interface IEntityFactory
    {
        public IEntity CreateEntity(GameObject prefab, Transform parent);
    }
}
