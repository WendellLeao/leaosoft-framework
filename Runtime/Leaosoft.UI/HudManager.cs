using UnityEngine.UI;
using UnityEngine;

namespace Leaosoft.UI
{
    public sealed class HudManager : MonoBehaviour
    {
        [SerializeField] private Image _healthBarImage;

        public void Initialize()
        {}
        
        public void Dispose()
        {}
        
        public void Tick(float deltaTime)
        {}
    }
}
