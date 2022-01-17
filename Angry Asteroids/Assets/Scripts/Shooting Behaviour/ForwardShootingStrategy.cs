using UnityEngine;

public class ForwardShootingStrategy : ShootingStrategy
{
    public override Transform AcquireTarget()
    {
        return null;
    }

    public override bool CanShoot(Transform self, Transform target)
    {
        return HasShootingCooldown();
    }

    protected override void ShootingImplementation(Transform self, Transform _)
    {
        var spawnPosition = self.position + (self.right * BulletSpawnOffset);
        BulletBuilder.Instance.BuildBullet(BulletType, spawnPosition, self.right);

    }
}
