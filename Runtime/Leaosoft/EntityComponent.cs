using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A Component attached on a <see cref="Entity"/>.
    /// </summary>
    [RequireComponent(typeof(Entity))]
    public abstract class EntityComponent : MonoBehaviour
    {
        private bool _isEnabled;
        
        public bool IsEnabled => _isEnabled;
        
        /// <summary>
        /// Begins the Component.
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
        /// Stops the Component.
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
        /// Updates the Component each frame, if it is enabled.
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
        /// Updates the Component in a fixed time, if it is enabled.
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
        /// OnBegin is called after the Component begins.
        /// </summary>
        protected virtual void OnBegin()
        { }
        
        /// <summary>
        /// OnStop is called after the Component stops.
        /// </summary>
        protected virtual void OnStop()
        { }
        
        /// <summary>
        /// OnTick is called every frame, if the Component is enabled.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }
        
        /// <summary>
        /// OnFixedTick is called in a fixed time, if the Component is enabled.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}
