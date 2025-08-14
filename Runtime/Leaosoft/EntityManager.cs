using System.Collections.Generic;

namespace Leaosoft
{
    public abstract class EntityManager<TEntity> : Manager, IEntityManager where TEntity : IEntity
    {
        private readonly List<TEntity> _entities = new();

        protected override void OnDispose()
        {
            base.OnDispose();
            
            for (int i = _entities.Count - 1; i >= 0; i--)
            {
                TEntity entity = _entities[i];
                
                DisposeEntity(entity);
            }
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            foreach (TEntity entity in _entities)
            {
                entity.Tick(deltaTime);
            }
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            foreach (TEntity entity in _entities)
            {
                entity.FixedTick(fixedDeltaTime);
            }
        }

        protected override void OnLateTick(float deltaTime)
        {
            base.OnLateTick(deltaTime);
            
            foreach (TEntity entity in _entities)
            {
                entity.LateTick(deltaTime);
            }
        }
        
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
