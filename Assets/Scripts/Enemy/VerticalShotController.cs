using UnityEngine;

namespace Enemy
{
    public class VerticalShotController : ShooterController
    {
        protected override void OnBeat()
        {
            base.OnBeat();
            
            FireBullet(Player.transform.position.y > transform.position.y ? 90 : 270);
        }
    }
}