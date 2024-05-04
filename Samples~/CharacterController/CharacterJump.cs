using UnityEngine;

namespace Leaosoft.Samples.CharacterController
{
    public sealed class CharacterJump : EntityComponent
    {
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _minimumDistance = 0.06f;
        [SerializeField]
        private LayerMask _groundLayers;
        
        private BoxCollider2D _boxCollider;
        private Rigidbody2D _rigidBody;
        private bool _isJumping;
        private bool _isGrounded;

        public void Begin(Rigidbody2D rigidBody, BoxCollider2D boxCollider)
        {
            _boxCollider = boxCollider;
            _rigidBody = rigidBody;
            
            base.Begin();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            _isGrounded = DetectGroundCollision();
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);

            if (!CanJump())
            {
                return;
            }
            
            _rigidBody.AddForce(Vector2.up * _jumpForce);
        }

        private bool CanJump()
        {
            if (!_isJumping)
            {
                return false;
            }

            if (!_isGrounded)
            {
                return false;
            }

            return true;
        }

        private bool DetectGroundCollision()
        {
            Bounds bounds = _boxCollider.bounds;
            
            Vector3 origin = bounds.center;

            Vector3 boundsSize = bounds.size;

            RaycastHit2D raycastHit = Physics2D.BoxCast(origin, boundsSize, 0f, Vector2.down, _minimumDistance, _groundLayers);

            DrawGroundDetection(raycastHit, bounds, _minimumDistance);
            
            return raycastHit.collider != null;
        }

        private void DrawGroundDetection(RaycastHit2D raycastHit, Bounds bounds, float minimumDistance)
        {
            bool hitGround = raycastHit.collider != null;
            
            Color rayColor = hitGround ? Color.green : Color.red;

            Debug.DrawRay(bounds.center + new Vector3(bounds.extents.x, 0), Vector2.down * (bounds.extents.y + minimumDistance), rayColor);
            Debug.DrawRay(bounds.center - new Vector3(bounds.extents.x, 0), Vector2.down * (bounds.extents.y + minimumDistance), rayColor);
            Debug.DrawRay(bounds.center - new Vector3(bounds.extents.x, bounds.extents.y + minimumDistance), Vector2.right * (bounds.extents.x * 2f), rayColor);
        }
    }
}
