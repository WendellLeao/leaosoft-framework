using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A System controls one or more <see cref="Manager"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        /// <summary>
        /// Is called automatically by the <see cref="Awake"/>.
        /// </summary>
        protected virtual void OnInitialize()
        { }

        /// <summary>
        /// Is called automatically by the <see cref="OnDestroy"/>.
        /// </summary>
        protected virtual void OnDispose()
        { }

        /// <summary>
        /// Is called automatically by the <see cref="Update"/>.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnTick(float deltaTime)
        { }

        /// <summary>
        /// Is called automatically by the <see cref="FixedUpdate"/>.
        /// </summary>
        /// <param name="fixedDeltaTime">is the amount of time that has passed since the last FixedUpdate call.</param>
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }

        private void Awake()
        {
            OnInitialize();
        }

        private void OnDestroy()
        {
            OnDispose();
        }

        private void Update()
        {
            OnTick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedTick(Time.fixedDeltaTime);
        }
    }
}
