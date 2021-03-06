using Audio;
using UnityEngine;

namespace Enemy
{
    public class SpreadshotController : ShooterController
    {
        [SerializeField] private int bulletAmount = 10;
        [SerializeField] private float spread = 180f;

        protected override void OnBeat(int beatPower)
        {
            float angle = 180;
            float interval = spread / (bulletAmount - 1);

            for (int i = 0; i < bulletAmount; i++)
            {
                FireBullet(angle, beatPower);
                angle += interval;
            }
        }
    }
}