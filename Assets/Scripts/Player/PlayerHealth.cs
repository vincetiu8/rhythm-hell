using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int playerHealth;
        [SerializeField] private GameObject gameOverPrefab;
        [SerializeField] private Text timerText;
    
        private int _health;

        private void Awake()
        {
            _health = playerHealth;
        }

        public void ChangeHealth(int change)
        {
            _health += change;

            if (_health > 0) return;
            
            Destroy(gameObject);
            Counter.CounterInstance.StopIncrement();
            timerText.text = Counter.CounterInstance.GetTime().ToString();
            gameOverPrefab.SetActive(true);
        }
    }

}
