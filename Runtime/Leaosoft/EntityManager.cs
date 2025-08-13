using System.Collections.Generic;

namespace Leaosoft
{
    public abstract class EntityManager<T> : Manager, IEntityManager where T : IEntity
    {
        private readonly List<T> _entities = new();

        public void Initialize()
        {
            OnInitialize();
        }

        public void Dispose()
        {
            for (int i = _entities.Count - 1; i >= 0; i--)
            {
                T entity = _entities[i];
                
                DisposeEntity(entity);
            }
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            foreach (T entity in _entities)
            {
                entity.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            foreach (T entity in _entities)
            {
                entity.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        public void LateTick(float deltaTime)
        {
            foreach (T entity in _entities)
            {
                entity.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }
        
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
        
        protected virtual void DisposeEntity(T entity)
        {
            entity.Stop();
            entity.Dispose();

            UnRegisterEntity(entity);
        }
        
        protected void RegisterEntity(T entity)
        {
            _entities.Add(entity);
        }

        private void UnRegisterEntity(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
