using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        private readonly List<Manager> _managers = new();
        
        protected virtual void OnInitialize()
        { }

        protected virtual void OnApplicationQuit()
        {
            DisposeAllManagers();
        }
        
        protected virtual void OnDispose()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
        
        protected virtual void OnLateTick(float deltaTime)
        { }

        protected void RegisterManagers(params Manager[] managers)
        {
            _managers.AddRange(managers);
        }
        
        private void Awake()
        {
            OnInitialize();
        }

        private void OnDestroy()
        {
            DisposeAllManagers();
            
            OnDispose();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (Manager manager in _managers)
            {
                manager.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            foreach (Manager manager in _managers)
            {
                manager.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (Manager manager in _managers)
            {
                manager.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }
        
        private void DisposeAllManagers()
        {
            foreach (Manager manager in _managers)
            {
                manager.Dispose();
            }
            
            _managers.Clear();
        }
    }
}
