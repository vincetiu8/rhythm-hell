using UnityEngine;

namespace Background
{
    public class CloudManager : MonoBehaviour
    {
        private static CloudManager _instance;
    
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
