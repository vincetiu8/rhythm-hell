using UnityEngine;

namespace UI
{
    public class Counter : MonoBehaviour
    {
        private float _secondsLasted;
        public static Counter CounterInstance;    
    
        private void Awake()
        {
            CounterInstance = this;
            _secondsLasted = 0;
        }

        private void Increment()
        {
            _secondsLasted++;
        }

        private void Start()
        {
            InvokeRepeating("Increment", 0, 1);
        }

        public void StopIncrement()
        {
            CancelInvoke();
        }

        public float GetTime()
        {
            return _secondsLasted / 60f;
        }
    }
}
