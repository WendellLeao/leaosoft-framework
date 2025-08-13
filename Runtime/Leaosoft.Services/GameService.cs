using UnityEngine;

namespace Leaosoft.Services
{
    /// <summary>
    /// Base class for global game services.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class GameService : MonoBehaviour
    {
        protected abstract void RegisterService();

        protected abstract void UnregisterService();

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDispose()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        private void Awake()
        {
            RegisterService();

            OnInitialize();
        }

        private void OnDestroy()
        {
            UnregisterService();

            OnDispose();
        }

        private void Update()
        {
            OnTick(Time.deltaTime);
        }
    }
}
