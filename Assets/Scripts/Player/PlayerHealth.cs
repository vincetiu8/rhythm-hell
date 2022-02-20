using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int initialHealth;
        [SerializeField] private GameObject gameOverPrefab;
        [SerializeField] private Text timerText;
        [SerializeField] private RectTransform healthBar;
        [SerializeField] private float regenHealthRate;
    
        private int _health;
        private float _initialWidth;
        private float _carryHealth;

        private void Awake()
        {
            _health = initialHealth;
            _initialWidth = healthBar.sizeDelta.x;
        }

        private void Update()
        {
            _carryHealth += regenHealthRate * Time.deltaTime;
            ChangeHealth((int) _carryHealth);
            _carryHealth %= 1;
        }

        public void ChangeHealth(int change)
        {
            _health = Math.Min(_health + change, initialHealth);

            healthBar.sizeDelta = new Vector2(_initialWidth * _health / initialHealth, healthBar.sizeDelta.y);

            if (_health > 0) return;
            Destroy(gameObject);
            Counter.CounterInstance.StopIncrement();
            timerText.text = Counter.CounterInstance.GetTime().ToString();
            gameOverPrefab.SetActive(true);
        }
    }

}
