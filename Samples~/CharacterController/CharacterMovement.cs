using UnityEngine;

namespace Leaosoft.Samples.CharacterController
{
    public sealed class CharacterMovement : EntityComponent
    {
        [SerializeField]
        private float _moveSpeed;
        
        private Rigidbody2D _rigidBody;
        private Vector2 _movement;

        public void Begin(Rigidbody2D rigidBody)
        {
            _rigidBody = rigidBody;
            
            base.Begin();
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            float horizontalMovement = _movement.x * _moveSpeed;
            float verticalMovement = _rigidBody.velocity.y;
            
            _rigidBody.velocity = new Vector2(horizontalMovement, verticalMovement);
        }
    }
}
