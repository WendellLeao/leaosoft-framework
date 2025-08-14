using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        private List<EntityComponent> components = new();
        
        private bool _isEnabled;

        protected bool IsEnabled => _isEnabled;

        public void SetUp()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;
            
            SetUpComponents();
            
            OnSetUp();
        }

        public void Dispose()
        {
            if (!_isEnabled)
            {
                return;
            }

            _isEnabled = false;
            
            foreach (EntityComponent component in components)
            {
                component.Dispose();
            }
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            foreach (EntityComponent component in components)
            {
                component.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            foreach (EntityComponent component in components)
            {
                component.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }
        
        public void LateTick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }

            foreach (EntityComponent component in components)
            {
                component.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }

        protected abstract void SetUpComponents();
        
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

#if UNITY_EDITOR
        public void AddComponentsForTests(params EntityComponent[] newComponents)
        {
            components.AddRange(newComponents);
        }
#endif
    }
}
