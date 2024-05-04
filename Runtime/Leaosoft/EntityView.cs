using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// Controls the view of a <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class EntityView : MonoBehaviour
    {
        private bool _isEnabled;

        public bool IsEnabled => _isEnabled;
        
        /// <summary>
        /// Setups the View.
        /// </summary>
        public void Begin()
        {
            if (_isEnabled)
            {
                return;
            }
            
            _isEnabled = true;
            
            OnSetup();
        }

        /// <summary>
        /// Disposes the View.
        /// </summary>
        public void Dispose()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _isEnabled = false;
            
            OnDispose();
        }

        /// <summary>
        /// Updates the View each frame, if it is enabled.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            OnTick(deltaTime);
        }
        
        /// <summary>
        /// Updates the View in a fixed time, if it is enabled.
        /// </summary>
        public void FixedTick(float fixedDeltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            OnFixedTick(fixedDeltaTime);
        }
        
        /// <summary>
        /// OnSetup is called after the View is setup.
        /// </summary>
        protected virtual void OnSetup()
        { }
        
        /// <summary>
        /// OnDispose is called after the View disposes.
        /// </summary>
        protected virtual void OnDispose()
        { }
        
        /// <summary>
        /// OnTick is called every frame, if it is enabled.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }
        
        /// <summary>
        /// OnFixedTick is called in a fixed time, if it is enabled.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}