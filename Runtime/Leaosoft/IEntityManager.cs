namespace Leaosoft
{
    public interface IEntityManager
    {
        public void Dispose();
        public void Tick(float deltaTime);
        public void FixedTick(float fixedDeltaTime);
        public void LateTick(float deltaTime);
    }
}
