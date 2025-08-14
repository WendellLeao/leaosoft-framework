using System.Collections.Generic;

namespace Leaosoft
{
    public abstract class EntityManager<TEntity> : Manager, IEntityManager where TEntity : IEntity
    {
        private readonly List<TEntity> _entities = new();

        public void Initialize()
        {
            OnInitialize();
        }

        public void Dispose()
        {
            for (int i = _entities.Count - 1; i >= 0; i--)
            {
                TEntity entity = _entities[i];
                
                DisposeEntity(entity);
            }
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            foreach (TEntity entity in _entities)
            {
                entity.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            foreach (TEntity entity in _entities)
            {
                entity.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        public void LateTick(float deltaTime)
        {
            foreach (TEntity entity in _entities)
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
        
        protected virtual void DisposeEntity(TEntity entity)
        {
            entity.Dispose();

            UnregisterEntity(entity);
        }
        
        protected void RegisterEntity(TEntity entity)
        {
            _entities.Add(entity);
        }

        private void UnregisterEntity(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
