using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public sealed class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(p: null);

            DontDestroyOnLoad(gameObject);
        }
    }
}
