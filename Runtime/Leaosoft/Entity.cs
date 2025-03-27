using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// An Entity is a dynamic game object, it can be composed by one or more <see cref="EntityComponent"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour
    {
        private bool _hasInitialized;
        private bool _hasBegun;

        public bool HasInitialized => _hasInitialized;
        public bool HasBegun => _hasBegun;

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

            OnDispose();
        }
        
        /// <summary>
        /// Begins the Entity in case it hasn't been yet.
        /// </summary>
        public void Begin()
        {
            if (_hasBegun)
            {
                return;
            }

            _hasBegun = true;

            OnBegin();
        }

        /// <summary>
        /// Stops the Entity in case it hasn't been yet.
        /// </summary>
        public void Stop()
        {
            if (!_hasBegun)
            {
                return;
            }

            _hasBegun = false;

            OnStop();
        }

        /// <summary>
        /// If enabled, updates the Entity each frame.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (!_hasBegun)
            {
                return;
            }

            OnTick(deltaTime);
        }

        /// <summary>
        /// If enabled, updates the Entity in a fixed time.
        /// </summary>
        public void FixedTick(float fixedDeltaTime)
        {
            if (!_hasBegun)
            {
                return;
            }

            OnFixedTick(fixedDeltaTime);
        }

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
    }
}
