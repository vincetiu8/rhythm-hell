using System;
using Menus;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int initialHealth;
        [SerializeField] private MenuManager _menuManager;
        [SerializeField] private GameObject endMenu;
        [SerializeField] private TMP_Text endText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private RectTransform healthBar;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private float regenHealthRate;
        [SerializeField] private GameObject healthPopupPrefab;
    
        private int _health;
        private float _initialWidth;
        private float _carryHealth;

        private void Awake()
        {
            _initialWidth = healthBar.sizeDelta.x;
            ChangeHealth(initialHealth);
        }

        private void Update()
        {
            _carryHealth += regenHealthRate * Time.deltaTime;
            ChangeHealth((int) _carryHealth);
            _carryHealth %= 1;
        }

        public void ChangeHealth(int change)
        {
            int newHealth = Math.Min(_health + change, initialHealth);
            
            if (newHealth == _health) return;

            _health = newHealth;

            healthBar.sizeDelta = new Vector2(_initialWidth * _health / initialHealth, healthBar.sizeDelta.y);
            healthText.text = $"{_health}/{initialHealth}";
            
            GameObject healthPopup = Instantiate(healthPopupPrefab, transform.position, transform.rotation);
            healthPopup.GetComponent<HealthPopupController>().Setup(change);
            
            if (_health > 0) return;
            Destroy(gameObject);
            Counter.CounterInstance.StopIncrement();
            float minutes = Counter.CounterInstance.GetTime();
            int seconds = (int)(minutes % 1 * 60);
            timerText.text = $"You survived {((int)minutes).ToString()} minutes and {seconds} seconds";
            _menuManager.OpenMenu(endMenu);
            endText.text = "You Lose";
        }
    }

}
