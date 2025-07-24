namespace Leaosoft
{
    public interface IManager
    {
        public void Initialize();
        public void Dispose();
        public void Tick(float deltaTime);
        public void FixedTick(float fixedDeltaTime);
        public void LateTick(float deltaTime);
    }
}
