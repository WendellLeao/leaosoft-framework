using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// An Entity is a dynamic game object, it can be composed by one or more <see cref="EntityComponent"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        private EntityComponent[] components;
        [SerializeField]
        private EntityView view;
        
        private bool _hasInitialized;
        private bool _isEnabled;

        public GameObject GameObject => gameObject;
        public EntityView View => view;
        public bool IsEnabled => _isEnabled;

        /// <summary>
        /// Initializes the Entity in case it hasn't been yet.
        /// </summary>
        public void Initialize()
        {
            if (_hasInitialized)
            {
                return;
            }

            _hasInitialized = true;

            InitializeComponents();
            
            OnInitialize();
        }

        /// <summary>
        /// Disposes the Entity in case it hasn't been yet.
        /// </summary>
        public void Dispose()
        {
            if (!_hasInitialized)
            {
                return;
            }

            _hasInitialized = false;

            foreach (EntityComponent component in components)
            {
                component.Stop();
                component.Dispose();
            }
            
            view?.Dispose();
            
            OnDispose();
        }
        
        /// <summary>
        /// Begins the Entity in case it hasn't been yet.
        /// </summary>
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
            
            view?.Begin();
            
            OnBegin();
        }

        /// <summary>
        /// Stops the Entity in case it hasn't been yet.
        /// </summary>
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
            
            view?.Stop();
            
            OnStop();
        }

        /// <summary>
        /// If enabled, updates the Entity each frame.
        /// </summary>
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
            
            view?.Tick(deltaTime);
            
            OnTick(deltaTime);
        }

        /// <summary>
        /// If enabled, updates the Entity in a fixed time.
        /// </summary>
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
            
            view?.FixedTick(fixedDeltaTime);
            
            OnFixedTick(fixedDeltaTime);
        }
        
        /// <summary>
        /// If enabled, updates the Entity each frame during LateUpdate.
        /// </summary>
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
            
            view?.LateTick(deltaTime);
            
            OnLateTick(deltaTime);
        }

        /// <summary>
        /// TDB
        /// </summary>
        protected abstract void InitializeComponents();
        
        /// <summary>
        /// Is called after the Entity initializes.
        /// </summary>
        protected virtual void OnInitialize()
        { }

        /// <summary>
        /// Is called after the Entity disposes.
        /// </summary>
        protected virtual void OnDispose()
        { }
        
        /// <summary>
        /// Is called after the Entity begins.
        /// </summary>
        protected virtual void OnBegin()
        { }

        /// <summary>
        /// Is called after the Entity stops.
        /// </summary>
        protected virtual void OnStop()
        { }

        /// <summary>
        /// Is called after the Entity ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// Is called after the Entity ticks in a fixed frame.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
        
        /// <summary>
        /// Is called after the Entity late ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnLateTick(float deltaTime)
        { }
    }
}
