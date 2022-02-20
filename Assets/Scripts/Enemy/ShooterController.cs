using System;
using Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public abstract class ShooterController : AudioSyncer
    {
        [SerializeField] protected GameObject[] projectilePrefabs = new GameObject[6];
        [SerializeField] protected float[] bulletVelocities = new float[6];

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

        protected void FireBullet(float angle, int beatPower)
        {
            GameObject projectile = Instantiate(projectilePrefabs[beatPower], transform.position, Quaternion.identity);

            float directionX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float directionY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 velocity = new Vector2(directionX, directionY) * bulletVelocities[beatPower];
            projectile.GetComponent<Rigidbody2D>().velocity = velocity;
            projectile.GetComponent<Rigidbody2D>().rotation = angle;
        }
    }
}