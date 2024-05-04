using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A Entity is a dynamic game object, it can be composed by one or more <see cref="EntityComponent"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour
    {
        private bool _isEnabled;
        
        public bool IsEnabled => _isEnabled;

        /// <summary>
        /// Begins the Entity.
        /// </summary>
        public void Begin()
        {
            if (_isEnabled)
            {
                return;
            }
            
            _isEnabled = true;
            
            OnBegin();
        }

        /// <summary>
        /// Stops the Entity.
        /// </summary>
        public void Stop()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _isEnabled = false;

            OnStop();
        }

        /// <summary>
        /// Updates the Entity each frame, if it has begun.
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
        /// Updates the Entity in a fixed time, if it has begun.
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
        /// OnBegin is called after the Entity begins.
        /// </summary>
        protected virtual void OnBegin()
        { }
        
        /// <summary>
        /// OnStop is called after the Entity stops.
        /// </summary>
        protected virtual void OnStop()
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
