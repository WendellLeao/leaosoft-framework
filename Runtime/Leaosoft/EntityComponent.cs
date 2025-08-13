using UnityEngine;

namespace Leaosoft
{
    public abstract class EntityComponent : MonoBehaviour
    {
        private bool _isEnabled;

        protected bool IsEnabled => _isEnabled;

        public void Initialize()
        {
            OnInitialize();
        }

        public void Dispose()
        {
            OnDispose();
        }

        public void Begin()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;

            OnBegin();
        }

        public void Stop()
        {
            if (!_isEnabled)
            {
                return;
            }

            _isEnabled = false;

            OnStop();
        }

        public void Tick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            OnTick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            OnFixedTick(fixedDeltaTime);
        }
        
        public void LateTick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            OnLateTick(deltaTime);
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDispose()
        { }
        
        protected virtual void OnBegin()
        { }

        protected virtual void OnStop()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }

        protected virtual void OnLateTick(float deltaTime)
        { }
    }
}
