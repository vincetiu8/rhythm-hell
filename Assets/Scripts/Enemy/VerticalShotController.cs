using UnityEngine;

namespace Enemy
{
    public class VerticalShotController : ShooterController
    {
        protected override void OnBeat(int beatPower)
        {
            FireBullet(Player.transform.position.y > transform.position.y ? 90 : 270, beatPower);
        }
    }
}