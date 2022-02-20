using UnityEngine;

namespace Enemy
{
    public class DirectShotController : ShooterController
    {
        protected override void OnBeat(int beatPower)
        {
            FireBullet(GetPlayerAngle(), beatPower);
        }
    }
}