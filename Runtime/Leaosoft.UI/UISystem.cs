using UnityEngine;

namespace Leaosoft.UI
{
    public sealed class UISystem : MonoBehaviour
    {
        [SerializeField] private HudManager hudManager;

        private void Awake()
        {
            hudManager.Initialize();
        }

        private void OnDestroy()
        {
            hudManager.Dispose();
        }

        public void Update()
        {
            hudManager.Tick(Time.deltaTime);
        }
    }
}
