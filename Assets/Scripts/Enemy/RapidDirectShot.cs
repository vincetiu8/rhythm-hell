using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class RapidDirectShot : ShooterController
    {
        [SerializeField] private int bulletAmount = 10;
        [SerializeField] private float fireDelay = 0.2f;
        private Coroutine _fireCoroutine;
    
        protected override void OnBeat(int beatPower)
        {
            if (_fireCoroutine != null) StopCoroutine(_fireCoroutine);
            _fireCoroutine = StartCoroutine(RapidFire(beatPower));
        }
    
        private IEnumerator RapidFire(int power)
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                FireBullet(GetPlayerAngle(), power);
                yield return new WaitForSeconds(fireDelay);
            }
        }
    }
}
