using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float speed;

    private void OnEnable()
    {
        Invoke("ResetBullet", 3f);
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void ResetBullet()
    {
        gameObject.SetActive(false);
    }
}
