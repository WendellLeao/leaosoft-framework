using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        private readonly List<IEntityManager> _entityManagers = new();
        
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

        protected void RegisterManagers(params IEntityManager[] entityManagers)
        {
            _entityManagers.AddRange(entityManagers);
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
            
            foreach (IEntityManager entityManager in _entityManagers)
            {
                entityManager.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            foreach (IEntityManager entityManager in _entityManagers)
            {
                entityManager.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (IEntityManager entityManager in _entityManagers)
            {
                entityManager.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }
        
        private void DisposeAllManagers()
        {
            foreach (IEntityManager entityManager in _entityManagers)
            {
                entityManager.Dispose();
            }
            
            _entityManagers.Clear();
        }
    }
}
