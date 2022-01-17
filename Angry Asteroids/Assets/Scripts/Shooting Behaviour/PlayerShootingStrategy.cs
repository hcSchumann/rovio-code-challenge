using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingStrategy : ShootingStrategy
{
    protected override float ShootingCooldownTimeInSec { get { return 0.5f; }}
    public PlayerController PlayerController;

    public override Transform AcquireTarget() 
    {
        return null;
    }

    public override bool CanShoot(Transform _, Transform __)
    {
        if (!HasShootingCooldown(ShootingCooldownTimeInSec)) 
            return false;

        return PlayerController.IsShooting;
    }

    protected override void ShootingImplementation(Transform self, Transform _)
    {
        var spawnPosition = self.position + (self.right * BulletSpawnOffset);
        BulletBuilder.Instance.BuildBullet(BulletType, spawnPosition, self.right, true);
    }
}
