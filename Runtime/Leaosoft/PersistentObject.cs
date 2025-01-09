using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// Makes a <see cref="GameObject"/> not be destroyed when loading a new scene.
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
