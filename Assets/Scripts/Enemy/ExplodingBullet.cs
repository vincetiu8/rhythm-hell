using UnityEngine;

namespace Enemy
{
    public class ExplodingBullet : Bullet
    {
        [SerializeField] private GameObject childBulletPrefab;
        [SerializeField] private int childBulletCount;
        [SerializeField] private float childBulletVelocity;

        protected override void Destroy()
        {
            float angle = Random.Range(0, 360);
            float increment = 360f / (childBulletCount - 1);
            for (int i = 0; i < childBulletCount; i++)
            {
                GameObject child = Instantiate(childBulletPrefab, transform.position, transform.rotation);
                
                float directionX = Mathf.Cos(angle * Mathf.Deg2Rad);
                float directionY = Mathf.Sin(angle * Mathf.Deg2Rad);
                Vector2 velocity = new Vector2(directionX, directionY) * childBulletVelocity;
                child.GetComponent<Rigidbody2D>().velocity = velocity;
                child.GetComponent<Rigidbody2D>().rotation = angle;
                angle += increment;
            }
            
            base.Destroy();
        }
    }
}