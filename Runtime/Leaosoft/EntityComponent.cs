using UnityEngine;

namespace Leaosoft
{
    public abstract class EntityComponent : MonoBehaviour
    {
        private bool _isEnabled;

        protected bool IsEnabled => _isEnabled;

        public void SetUp()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;

            OnSetUp();
        }

        public void Dispose()
        {
            if (!_isEnabled)
            {
                return;
            }

            _isEnabled = false;

            OnDispose();
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
        
        protected virtual void OnSetUp()
        { }

        protected virtual void OnDispose()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }

        protected virtual void OnLateTick(float deltaTime)
        { }
    }
}
