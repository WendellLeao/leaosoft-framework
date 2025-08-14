using UnityEngine;

namespace Leaosoft
{
    public abstract class Manager : MonoBehaviour
    {
        public void SetUp()
        {
            OnSetUp();
        }

        public void Dispose()
        {
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            OnTick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            OnFixedTick(fixedDeltaTime);
        }

        public void LateTick(float deltaTime)
        {
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
