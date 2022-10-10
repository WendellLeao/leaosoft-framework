using UnityEngine;

namespace Leaosoft.Samples.BeginThePlayer.Playing
{
    public sealed class Character : Entity
    {
        protected override void OnBegin()
        {
            base.OnBegin();

            Debug.Log("I have been begun!");
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            Debug.Log("I have been stopped!");
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            Debug.Log("I'm updating each frame!");
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            Debug.Log("I'm updating at fixed time!");
        }
    }
}
