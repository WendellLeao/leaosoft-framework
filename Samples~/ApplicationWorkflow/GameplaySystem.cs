using UnityEngine;

namespace Leaosoft.Samples.ApplicationWorkflow
{
    public class GameplaySystem : System
    {
        [SerializeField]
        private CharacterManager _characterManager;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _characterManager.Initialize();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _characterManager.Dispose();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            _characterManager.Tick(deltaTime);
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            _characterManager.FixedTick(fixedDeltaTime);
        }
    }
}
