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
        
        public static bool TryFindObjectOfInterface<T>(out T result) where T : class
        {
            foreach (MonoBehaviour monoBehaviours in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (monoBehaviours is T type)
                {
                    result = type;
                    return true;
                }
            }

            // TODO:
            Debug.LogError("TryFindObjectOfInterface");
            
            result = null;
            return false;
        }
    }
}
