using Audio;
using UnityEngine;

namespace Enemy
{
    public class SpreadshotFire : TargetedShooter
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int bulletAmount;
        [SerializeField] private float spread = 180f;
        [SerializeField] private float bulletVelocity = 2.5f;

        protected override void OnBeat()
        {
            base.OnBeat();

            Vector2 direction = GetPlayerDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - spread / 2;
            float interval = spread / (bulletAmount - 1);

            for (int i = 0; i < bulletAmount; i++)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                float directionX = Mathf.Cos(angle * Mathf.Deg2Rad);
                float directionY = Mathf.Sin(angle * Mathf.Deg2Rad);
                Vector2 velocity = new Vector2(directionX, directionY) * bulletVelocity;
                projectile.GetComponent<Rigidbody2D>().velocity = velocity;
                projectile.GetComponent<Rigidbody2D>().rotation = angle;
                angle += interval;
            }
        }
    }
}