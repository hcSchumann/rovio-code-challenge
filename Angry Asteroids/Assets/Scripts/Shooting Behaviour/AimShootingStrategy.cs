using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShootingStrategy : ShootingStrategy
{
    public float Precision = 1f;
    public float MaxErrorOffset = 0f;

    public override Transform AcquireTarget()
    {
        return GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override bool CanShoot(Transform self, Transform target)
    {
        return HasShootingCooldown();
    }

    protected override void ShootingImplementation(Transform self, Transform target)
    {
        var spawnPosition = self.position + (self.right * BulletSpawnOffset);
        var randomAimError = GetAimError();
        var bulletDirection = target.position + randomAimError - spawnPosition;
        
        self.right = bulletDirection.normalized;

        BulletBuilder.Instance.BuildBullet(BulletType, spawnPosition, self.right);

    }

    private Vector3 GetAimError()
    {
        var precision = Mathf.Min(1, Mathf.Max(0,Precision));
        var error = 1 - precision;

        return new Vector3(
            Random.Range(0, error) * MaxErrorOffset,
            Random.Range(0, error) * MaxErrorOffset, 
            0);
    }
}
