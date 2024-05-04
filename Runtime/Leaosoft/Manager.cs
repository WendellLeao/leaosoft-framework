using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A Manager can controls one or more <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Manager : MonoBehaviour
    {
        private bool _isInitialized;

        public bool IsInitialized => _isInitialized;
        
        /// <summary>
        /// Initializes the Manager.
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
        /// Disposes the Manager.
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
        /// Updates the Manager each frame, if it has initialized.
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
        /// Updates the Manager in a fixed time, if it has initialized.
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
        /// OnInitialize is called after the Manager initializes.
        /// </summary>
        protected virtual void OnInitialize()
        { }

        /// <summary>
        /// OnDispose is called after the Manager disposes.
        /// </summary>
        protected virtual void OnDispose()
        { }

        /// <summary>
        /// OnTick is called every frame, if it has begun.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// OnFixedTick is called in a fixed time, if it has begun.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}
