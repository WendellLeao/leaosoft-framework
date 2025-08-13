using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        [SerializeField]
        private Manager[] managers;

        private readonly List<IEntityManager> _entityManagers = new();
        
        protected abstract void InitializeManagers();
        
        protected virtual void OnInitialize()
        { }

        protected virtual void OnDispose()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
        
        protected virtual void OnLateTick(float deltaTime)
        { }

        private void Awake()
        {
            PopulateEntityManagers();
            
            InitializeManagers();
            
            OnInitialize();
        }

        private void OnDestroy()
        {
            foreach (IEntityManager entityManager in _entityManagers)
            {
                entityManager.Dispose();
            }
            
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
        
        private void PopulateEntityManagers()
        {
            foreach (Manager manager in managers)
            {
                if (manager is not IEntityManager entityManager)
                {
                    continue;
                }
                
                _entityManagers.Add(entityManager);
            }
        }
        
        protected bool TryGetManager<T>(out T result) where T : Manager
        {
            foreach (Manager manager in managers)
            {
                if (manager is T casted)
                {
                    result = casted;
                    return true;
                }
            }

            Debug.LogError($"Wasn't possible to get the manager '{typeof(T)}'");
            
            result = null;
            return false;
        }
    }
}
