using UnityEngine;

namespace Leaosoft.Samples.ApplicationWorkflow.Playing
{
    public sealed class CharacterManager : Manager
    {
        [SerializeField]
        private Character _character;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _character.Begin();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _character.Stop();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            _character.Tick(deltaTime);
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            _character.FixedTick(fixedDeltaTime);
        }
    }
}
