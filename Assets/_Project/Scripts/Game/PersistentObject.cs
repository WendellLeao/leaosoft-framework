using UnityEngine;

namespace Game
{
    public sealed class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
