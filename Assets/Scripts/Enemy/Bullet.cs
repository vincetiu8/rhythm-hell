using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float lifetime;

        private void Start()
        {
            Invoke(nameof(Destroy), lifetime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                playerHealth.ChangeHealth(-damage);
            }
            Destroy(gameObject);
        }

        protected virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}