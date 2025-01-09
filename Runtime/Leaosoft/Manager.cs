using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A Manager controls one or more <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Manager : MonoBehaviour
    {
        private bool _isInitialized;

        public bool IsInitialized => _isInitialized;

        /// <summary>
        /// Initializes the Manager in case it hasn't been yet.
        /// </summary>
        public void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;

            OnInitialize();
        }

        /// <summary>
        /// Disposes the Manager in case it hasn't been yet.
        /// </summary>
        public void Dispose()
        {
            if (!_isInitialized)
            {
                return;
            }

            _isInitialized = false;

            OnDispose();
        }

        /// <summary>
        /// If enabled, updates the Manager each frame.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (!_isInitialized)
            {
                return;
            }

            OnTick(deltaTime);
        }

        /// <summary>
        /// If enabled, updates the Manager in a fixed time.
        /// </summary>
        public void FixedTick(float fixedDeltaTime)
        {
            if (!_isInitialized)
            {
                return;
            }

            OnFixedTick(fixedDeltaTime);
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
    }
}
