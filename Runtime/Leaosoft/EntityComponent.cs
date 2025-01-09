using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A component attached on an <see cref="Entity"/> that provides it determined behaviors.
    /// </summary>
    [RequireComponent(typeof(Entity))]
    public abstract class EntityComponent : MonoBehaviour
    {
        private bool _isEnabled;

        public bool IsEnabled => _isEnabled;

        /// <summary>
        /// Begins the component in case it hasn't been yet.
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
        /// Stops the component in case it hasn't been yet.
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
        /// If enabled, updates the component each frame.
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
        /// If enabled, updates the component in a fixed time.
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
        /// Is called after the component begins.
        /// </summary>
        protected virtual void OnBegin()
        { }

        /// <summary>
        /// Is called after the component stops.
        /// </summary>
        protected virtual void OnStop()
        { }

        /// <summary>
        /// Is called after the component ticks each frame.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// Is called after the component ticks in a fixed frame.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}
