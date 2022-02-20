using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class VerticalShotFire : MonoBehaviour

{
    [SerializeField] private int bulletAmount;

    private Vector2 _bulletDirection;

    private void Start()
    {
        InvokeRepeating("VerticalFire", 0f, 0.3f);
    }

    private void VerticalFire()
    {

        float interval = bulletAmount;

        for (int i = 0; i < bulletAmount + 1; i++)
        {
            float directionX = transform.position.x;
            float directionY = transform.position.y + 5;

            Vector3 movementVector = new Vector3(directionX, directionY, 0f);
            Vector2 bulletDirection = (movementVector - transform.position).normalized;

            GameObject bulletSpawn = GetComponentInChildren<BulletStorage>().GetBullet();
            bulletSpawn.transform.position = transform.position;
            bulletSpawn.SetActive(true);
            //bulletSpawn.GetComponent<Bullet>().SetDirection(bulletDirection);
        }
    }
} 
