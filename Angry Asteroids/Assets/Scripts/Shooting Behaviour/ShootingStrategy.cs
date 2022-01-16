using UnityEngine;

public abstract class ShootingStrategy
{
    protected BulletType BulletType = BulletType.basic;
    protected float ShootingCooldownTimeInSec = 1f;
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

    protected bool HasShootingCooldown()
    {
        if (Time.time >= _lastShootTime + ShootingCooldownTimeInSec) return true;
        return false;
    }
}