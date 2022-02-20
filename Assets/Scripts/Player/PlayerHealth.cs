using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    private int health;

    private void Awake()
    {
        health = playerHealth;
    }

    public void ChangeHealth(int change)
    {
        health = health + change;
        Debug.Log($"Health changed with value {change}!");
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
