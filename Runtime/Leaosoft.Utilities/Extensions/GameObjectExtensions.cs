using UnityEngine;

namespace Leaosoft.Utilities.Extensions
{
    public static class GameObjectExtensions
    {
        public static string GetRootName(this GameObject gameObject)
        {
            Transform gameObjectTransform = gameObject.transform;

            return gameObjectTransform.GetRootName();
        }
    }
}
