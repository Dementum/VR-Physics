using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.Player
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _turnInput;
    
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private Transform _turnTarget;
        [SerializeField] private LayerMask _floorMask;
        [SerializeField] private CapsuleCollider _bodyCollider;
    
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _turnSpeed;
    
        private Vector2 _moveDirection;
        private float _turnAngle;
        private bool _isOnTheFloor;
    
        private void ReadInput()
        {
            _moveDirection = _moveInput.action.ReadValue<Vector2>();
            _turnAngle = _turnInput.action.ReadValue<Vector2>().x;
        }

        private void HandleMovement()
        {
            if (!_isOnTheFloor)
            {
                return;
            }
        
            var rotation = Quaternion.Euler(0f, _turnTarget.eulerAngles.y, 0f);
            var targetDirection = rotation * new Vector3(_moveDirection.x, 0f, _moveDirection.y);
            _rigidbody.MovePosition(_rigidbody.position + targetDirection * (_moveSpeed * Time.fixedDeltaTime));
        }

        private void HandleTurn()
        {
            if (!_isOnTheFloor)
            {
                return;
            }
        
            var axis = Vector3.up;
            float turnAmount = _turnSpeed * Time.fixedDeltaTime * _turnAngle;
            var rotation = Quaternion.AngleAxis(turnAmount, axis);
        
            _rigidbody.MoveRotation(_rigidbody.rotation * rotation);

            var targetPosition = rotation * (_rigidbody.position - _turnTarget.position) + _turnTarget.position;
            _rigidbody.MovePosition(targetPosition);
        }

        private bool IsOnTheFloor()
        {
            var origin = _bodyCollider.transform.position + _bodyCollider.center;
            var rayLength = _bodyCollider.height * 0.5f + _bodyCollider.radius + 0.1f;
        
            return Physics.SphereCast(origin, _bodyCollider.radius + 0.1f, Vector3.down, out RaycastHit _, rayLength, _floorMask);
        }
    
        private void Update()
        {
            ReadInput();
        }

        private void FixedUpdate()
        {
            _isOnTheFloor = IsOnTheFloor();
            HandleTurn();
            HandleMovement();
        }
    }
}
