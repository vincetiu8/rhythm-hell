using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private GameObject gameOverPrefab;
    [SerializeField] private Text timerText;
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
            Counter.CounterInstance.StopIncrement();
            timerText.text = Counter.CounterInstance.GetTime().ToString();
            gameOverPrefab.SetActive(true);
        }
    }
}
