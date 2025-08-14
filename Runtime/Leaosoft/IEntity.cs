namespace Leaosoft
{
    public interface IEntity
    {
        public void SetUp();
        public void Dispose();
        public void Tick(float deltaTime);
        public void FixedTick(float fixedDeltaTime);
        public void LateTick(float deltaTime);
    }
}
