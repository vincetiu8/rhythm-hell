using System;
using Audio;
using UnityEngine;

namespace Enemy
{
    public abstract class ShooterController : AudioSyncer
    {
        [SerializeField] protected GameObject projectilePrefab;
        [SerializeField] protected float bulletVelocity = 2.5f;

        protected Transform Player;

        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private Vector2 GetPlayerDirection()
        {
            return Player.position - transform.position;
        }

        protected float GetPlayerAngle()
        {
            Vector2 playerDirection = GetPlayerDirection();
            return Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        }

        protected void FireBullet(float angle)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            float directionX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float directionY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 velocity = new Vector2(directionX, directionY) * bulletVelocity;
            projectile.GetComponent<Rigidbody2D>().velocity = velocity;
            projectile.GetComponent<Rigidbody2D>().rotation = angle;
        }
    }
}