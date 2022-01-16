using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingStrategy : ShootingStrategy
{
    new protected float ShootingCooldownTimeInSec = 0.5f;

    public override Transform AcquireTarget() 
    {
        return null;
    }

    public override bool CanShoot(Transform _, Transform __)
    {
        if (!HasShootingCooldown()) return false;

        return Mouse.current.leftButton.isPressed;
    }

    protected override void ShootingImplementation(Transform self, Transform _)
    {
        var spawnPosition = self.position + (self.right * 2f);
        BulletBuilder.BuildBullet(BulletType.basic, spawnPosition, self.right, true);
    }
}