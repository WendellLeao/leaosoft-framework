using UnityEngine;

namespace Leaosoft
{
    public interface IEntity
    {
        public GameObject gameObject { get; }
        public void Initialize();
        public void Dispose();
        public void Begin();
        public void Stop();
        public void Tick(float deltaTime);
        public void FixedTick(float fixedDeltaTime);
        public void LateTick(float deltaTime);
    }
}
