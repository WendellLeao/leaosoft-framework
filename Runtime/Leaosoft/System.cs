using UnityEngine;

namespace Leaosoft
{
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        [SerializeField]
        private Manager[] managers;

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
            InitializeManagers();
            
            OnInitialize();
        }

        private void OnDestroy()
        {
            foreach (Manager manager in managers)
            {
                if (manager is EntityManager<IEntity> entityManager)
                {
                    entityManager.Dispose();
                }
            }
            
            OnDispose();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (Manager manager in managers)
            {
                if (manager is EntityManager<IEntity> entityManager)
                {
                    entityManager.Tick(deltaTime);
                }
            }
            
            OnTick(deltaTime);
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            foreach (Manager manager in managers)
            {
                if (manager is EntityManager<IEntity> entityManager)
                {
                    entityManager.FixedTick(fixedDeltaTime);
                }
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (Manager manager in managers)
            {
                if (manager is EntityManager<IEntity> entityManager)
                {
                    entityManager.LateTick(deltaTime);
                }
            }
            
            OnLateTick(deltaTime);
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

            result = default;
            return false;
        }
    }
}
