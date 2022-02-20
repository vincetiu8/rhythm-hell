using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 3 is player layer
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth == null) return;
        playerHealth.ChangeHealth(-damage);
    }
}
