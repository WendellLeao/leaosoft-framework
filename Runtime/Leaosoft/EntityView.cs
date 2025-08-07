using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// Controls the visual of an <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class EntityView : MonoBehaviour
    {
        [SerializeField]
        private EntityComponent[] components;
        
        private bool _hasInitialized;
        private bool _isEnabled;

        /// <summary>
        /// Initializes the view in case it hasn't been yet.
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
        /// Disposes the view in case it hasn't been yet.
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
            
            OnDispose();
        }
        
        /// <summary>
        /// Begins the view in case it hasn't been yet.
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
            
            OnBegin();
        }

        /// <summary>
        /// Stops the view in case it hasn't been yet.
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
            
            OnStop();
        }

        /// <summary>
        /// If enabled, updates the view each frame.
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
            
            OnTick(deltaTime);
        }

        /// <summary>
        /// If enabled, updates the view in a fixed time.
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
            
            OnFixedTick(fixedDeltaTime);
        }
        
        /// <summary>
        /// If enabled, updates the view each frame during LateUpdate.
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
            
            OnLateTick(deltaTime);
        }

        /// <summary>
        /// TDB
        /// </summary>
        protected abstract void InitializeComponents();
        
        /// <summary>
        /// Is called after the view initializes.
        /// </summary>
        protected virtual void OnInitialize()
        { }

        /// <summary>
        /// Is called after the view disposes.
        /// </summary>
        protected virtual void OnDispose()
        { }
        
        /// <summary>
        /// Is called after the view begins.
        /// </summary>
        protected virtual void OnBegin()
        { }

        /// <summary>
        /// Is called after the view stops.
        /// </summary>
        protected virtual void OnStop()
        { }

        /// <summary>
        /// Is called after the view ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// Is called after the view ticks in a fixed frame.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
        
        /// <summary>
        /// Is called after the view late ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnLateTick(float deltaTime)
        { }
    }
}
