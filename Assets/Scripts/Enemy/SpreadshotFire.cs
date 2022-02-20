using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadshotFire : MonoBehaviour
{
    [SerializeField] private int bulletAmount;

    [SerializeField] private float startAngle = 90f;
    [SerializeField] private float endAngle = 270f;

    private Vector2 _bulletDirection;

    private void Start()
    {
        InvokeRepeating("SpreadFire", 0f, 2f);
    }

    private void SpreadFire()
    {
        float interval = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount + 1; i++)
        {
            float directionX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float directionY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 movementVector = new Vector3(directionX, directionY, 0f);
            Vector2 bulletDirection = (movementVector - transform.position).normalized;

            GameObject bulletSpawn = GetComponentInChildren<BulletStorage>().GetBullet();
            bulletSpawn.transform.position = transform.position;
            bulletSpawn.SetActive(true);
            bulletSpawn.GetComponent<Bullet>().SetDirection(bulletDirection);

            angle += interval;
        }
    }
}
