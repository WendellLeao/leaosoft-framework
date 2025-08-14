using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour
    {
        private readonly List<EntityComponent> _components = new();
        
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
            
            foreach (EntityComponent component in _components)
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

            foreach (EntityComponent component in _components)
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

            foreach (EntityComponent component in _components)
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

            foreach (EntityComponent component in _components)
            {
                component.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }

        public void RegisterComponents(params EntityComponent[] components)
        {
            _components.AddRange(components);
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
