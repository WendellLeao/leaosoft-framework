using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// Controls the visual of an <see cref="Entity"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class EntityView : MonoBehaviour
    {
        private bool _isEnabled;

        public bool IsEnabled => _isEnabled;

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

            OnBegin();
        }

        /// <summary>
        /// Begins the view in case it hasn't been yet.
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
        /// If enabled, updates the view each frame.
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
        /// If enabled, updates the view in a fixed time.
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
    }
}
