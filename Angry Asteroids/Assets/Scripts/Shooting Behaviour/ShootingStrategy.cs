using UnityEngine;

public abstract class ShootingStrategy
{
    protected virtual float ShootingCooldownTimeInSec { get { return 1f; }}

    protected BulletType BulletType = BulletType.basic;
    protected float BulletSpawnOffset = 10f;

    private float _lastShootTime;

    public abstract Transform AcquireTarget();
    
    public void SetBulletType(BulletType newType)
    {
        BulletType = newType;
    }
    
    public abstract bool CanShoot(Transform self, Transform target);

    public void ExecuteShoot(Transform self, Transform target)
    {
        _lastShootTime = Time.time;
        ShootingImplementation(self, target);
    }

    protected abstract void ShootingImplementation(Transform self, Transform target);

    protected bool HasShootingCooldown(float cooldown)
    {
        if (Time.time >= _lastShootTime + cooldown) return true;
        return false;
    }

    protected bool HasShootingCooldown()
    {
        return HasShootingCooldown(ShootingCooldownTimeInSec);
    }
}