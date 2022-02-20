using System;
using UnityEngine;

namespace Enemy
{
    public class TrackingBullet : Bullet
    {
        [SerializeField] private float maxTurnSpeed;

        private float _velocity;
        private Transform _player;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _velocity = 10;  //_rigidbody2D.velocity.magnitude;
        }

        private void FixedUpdate()
        {
            Vector2 disp = _player.position - transform.position;
            float maxTurn = maxTurnSpeed * Time.deltaTime;
            float turnAngle = Mathf.Clamp(Mathf.Atan2(disp.y, disp.x) * Mathf.Rad2Deg - _rigidbody2D.rotation, -maxTurn, maxTurn);
            _rigidbody2D.SetRotation(_rigidbody2D.rotation + turnAngle);
            
            float directionX = Mathf.Cos(_rigidbody2D.rotation * Mathf.Deg2Rad);
            float directionY = Mathf.Sin(_rigidbody2D.rotation * Mathf.Deg2Rad);
            _rigidbody2D.velocity = new Vector2(directionX, directionY) * _velocity;
        }
    }
}