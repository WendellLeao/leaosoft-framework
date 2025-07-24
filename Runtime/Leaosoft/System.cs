using UnityEngine;

namespace Leaosoft
{
    /// <summary>
    /// A System controls one or more <see cref="Manager"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class System : MonoBehaviour
    {
        [SerializeField]
        private Manager[] managers;
        
        /// <summary>
        /// Is called on <see cref="Awake"/> to initialize all <see cref="Manager"/>.
        /// </summary>
        protected abstract void InitializeManagers();
        
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
        
        /// <summary>
        /// Is called automatically by the <see cref="LateUpdate"/>.
        /// </summary>
        /// <param name="deltaTime">is the amount of time that has passed since the last frame update in seconds.</param>
        protected virtual void OnLateTick(float deltaTime)
        { }

        private void Awake()
        {
            InitializeManagers();
            
            OnInitialize();
        }

        private void OnDestroy()
        {
            foreach (IManager manager in managers)
            {
                manager.Dispose();
            }
            
            OnDispose();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (IManager manager in managers)
            {
                manager.Tick(deltaTime);
            }
            
            OnTick(deltaTime);
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            foreach (IManager manager in managers)
            {
                manager.FixedTick(fixedDeltaTime);
            }
            
            OnFixedTick(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (IManager manager in managers)
            {
                manager.LateTick(deltaTime);
            }
            
            OnLateTick(deltaTime);
        }
        
        /// <summary>
        /// Queries the registered <see cref="IManager"/> array to return the specified one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetManager<T>() where T : IManager
        {
            foreach (Manager manager in managers)
            {
                if (manager is T casted)
                {
                    return casted;
                }
            }

            return default;
        }
    }
}
