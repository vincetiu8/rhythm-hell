using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStorage : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private bool _insufficientBullets = true;
    private List<GameObject> bulletsToSpawn = new List<GameObject>();

    public GameObject GetBullet()
    {
        if (bulletsToSpawn.Count > 0)
        {
            for (int i = 0; i < bulletsToSpawn.Count; i++)
            {
                if (!bulletsToSpawn[i].activeInHierarchy)
                {
                    return bulletsToSpawn[i];
                }
            }
        }

        if (_insufficientBullets)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletsToSpawn.Add(bullet);
            return bullet;
        }

        return null;
    }
}
