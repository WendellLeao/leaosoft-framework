using UnityEngine;

namespace Leaosoft.Services
{
    public abstract class GameService : MonoBehaviour
    {
        protected virtual void OnDispose()
        {}
        
        protected virtual void OnTick(float deltaTime)
        {}
        
        private void OnDestroy()
        {
            OnDispose();
        }

        private void Update()
        {
            OnTick(Time.deltaTime);
        }
    }
}
