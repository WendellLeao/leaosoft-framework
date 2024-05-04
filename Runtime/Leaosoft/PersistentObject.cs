using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// Make a game object not be destroyed when loading a new scene.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(null);

            DontDestroyOnLoad(gameObject);
        }
    }
}
