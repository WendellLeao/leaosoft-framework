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

        public void Initialize()
        {
            InitializeComponents();
            
            OnInitialize();
        }

        public void Dispose()
        {
            foreach (EntityComponent component in components)
            {
                component.Stop();
                component.Dispose();
            }
            
            OnDispose();
        }
        
        public void Begin()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;

            foreach (EntityComponent component in components)
            {
                component.Begin();
            }
            
            OnBegin();
        }

        public void Stop()
        {
            if (!_isEnabled)
            {
                return;
            }

            _isEnabled = false;

            foreach (EntityComponent component in components)
            {
                component.Stop();
            }
            
            OnStop();
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

        protected abstract void InitializeComponents();
        
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

#if UNITY_EDITOR
        public void AddComponentsForTests(params EntityComponent[] newComponents)
        {
            components.AddRange(newComponents);
        }
#endif
    }
}
