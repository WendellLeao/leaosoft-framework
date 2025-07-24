using System;
using System.Collections.Generic;
using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A Manager controls one or more <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Manager : MonoBehaviour, IEntityFactory
    {
        private readonly List<IEntity> _allSpawnedEntities = new();
        private bool _hasInitialized;

        public bool HasInitialized => _hasInitialized;

        /// <summary>
        /// Initializes the Manager in case it hasn't been yet.
        /// </summary>
        public void Initialize()
        {
            if (_hasInitialized)
            {
                return;
            }

            _hasInitialized = true;

            OnInitialize();
        }

        /// <summary>
        /// Disposes the Manager in case it hasn't been yet.
        /// </summary>
        public void Dispose()
        {
            if (!_hasInitialized)
            {
                return;
            }

            _hasInitialized = false;

            foreach (IEntity entity in _allSpawnedEntities)
            {
                entity.Stop();
                entity.Dispose();
            }
            
            _allSpawnedEntities.Clear();
            
            OnDispose();
        }

        /// <summary>
        /// If enabled, updates the Manager each frame.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (!_hasInitialized)
            {
                return;
            }

            foreach (IEntity entity in _allSpawnedEntities)
            {
                entity.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        /// <summary>
        /// If enabled, updates the Manager in a fixed time.
        /// </summary>
        public void FixedTick(float fixedDeltaTime)
        {
            if (!_hasInitialized)
            {
                return;
            }
            
            foreach (IEntity entity in _allSpawnedEntities)
            {
                entity.FixedTick(fixedDeltaTime);
            }

            OnFixedTick(fixedDeltaTime);
        }
        
        /// <summary>
        /// If enabled, updates the Manager each frame during LateUpdate.
        /// </summary>
        public void LateTick(float deltaTime)
        {
            if (!_hasInitialized)
            {
                return;
            }

            foreach (IEntity entity in _allSpawnedEntities)
            {
                entity.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IEntity CreateEntity(GameObject prefab, Transform parent)
        {
            if (!prefab.TryGetComponent(out IEntity _))
            {
                throw new InvalidOperationException($"The prefab '{prefab.name}' does not contain a component of type '{nameof(IEntity)}'");
            }

            Entity entity = Instantiate(prefab, parent).GetComponent<Entity>();
            
            _allSpawnedEntities.Add(entity);
            
            return entity;
        }
        
        /// <summary>
        /// Is called after the Manager initializes.
        /// </summary>
        protected virtual void OnInitialize()
        { }

        /// <summary>
        /// Is called after the Manager disposes.
        /// </summary>
        protected virtual void OnDispose()
        { }

        /// <summary>
        /// Is called after the Manager ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// Is called after the Manager ticks in a fixed frame.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
        
        /// <summary>
        /// Is called after the Manager late ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnLateTick(float deltaTime)
        { }

        /// <summary>
        /// Disposes the <see cref="IEntity"/>.
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DisposeEntity(IEntity entity)
        {
            entity.Stop();
            entity.Dispose();

            _allSpawnedEntities.Remove(entity);
        }
    }
}
