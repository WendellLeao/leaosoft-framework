using UnityEngine;

namespace Leaosoft.Samples.ApplicationWorkflow.Playing
{
    public sealed class Character : Entity
    {
        protected override void OnBegin()
        {
            base.OnBegin();

            Debug.Log("I have begun!");
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            Debug.Log("I have stopped!");
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
