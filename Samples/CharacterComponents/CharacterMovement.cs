using Leaosoft.Input;
using UnityEngine;

namespace Leaosoft.Gameplay.Playing
{
    public sealed class CharacterMovement : EntityComponent
    {
        [SerializeField] private float _moveSpeed;
        
        private IInputService _inputService;
        private Rigidbody2D _rigidBody;
        private Vector2 _movement;

        public void Begin(IInputService inputService, Rigidbody2D rigidBody)
        {
            _inputService = inputService;
            _rigidBody = rigidBody;
            
            base.Begin();
        }

        protected override void OnBegin()
        {
            base.OnBegin();
            
            _inputService.OnReadInputs += HandleReadInputs;
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _inputService.OnReadInputs -= HandleReadInputs;
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            float horizontalMovement = _movement.x * _moveSpeed;
            float verticalMovement = _rigidBody.velocity.y;
            
            _rigidBody.velocity = new Vector2(horizontalMovement, verticalMovement);
        }

        private void HandleReadInputs(InputsData inputsData)
        {
            _movement = inputsData.Movement;
        }
    }
}
