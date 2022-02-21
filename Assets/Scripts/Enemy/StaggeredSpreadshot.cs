using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class StaggeredSpreadshot : ShooterController
    {
        [SerializeField] private int bulletAmount = 10;
        [SerializeField] private float spread = 180f;
        [SerializeField] private float delay;
        private Coroutine _fireCoroutine;

        protected override void OnBeat(int beatPower)
        {
            if(_fireCoroutine != null) StopCoroutine(_fireCoroutine);
            _fireCoroutine = StartCoroutine(StaggeredFire(beatPower));
        }

        private IEnumerator StaggeredFire(int power)
        {
            float angle = GetPlayerAngle() - spread / 2;
            float interval = spread / (bulletAmount - 1);

            for (int i = 0; i < bulletAmount; i++)
            {
                FireBullet(angle, power);
                angle += interval;
                yield return new WaitForSeconds(delay);
            }
        }

    }
}
