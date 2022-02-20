using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float accelerationAmount;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementDirection;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Debug.Log(_movementDirection * accelerationAmount);
            _rigidbody2D.AddForce(_movementDirection * accelerationAmount);
        }

        public void MovementAction(InputAction.CallbackContext context)
        {
            _movementDirection = context.ReadValue<Vector2>().normalized;
        }
    }
}