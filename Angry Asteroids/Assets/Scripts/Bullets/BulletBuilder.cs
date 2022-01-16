using UnityEngine;

public static class BulletBuilder
{
    private static BulletPool bulletPool;

    public static void Initialize()
    {
        bulletPool = new BulletPool();
    }

    public static void BuildBullet(BulletType bulletType, Vector3 position, Vector3 direction, bool shooterIsPlayer = false)
    {
        switch(bulletType)
        {
            case BulletType.basic:
                BuildBasicBullet(position, direction, shooterIsPlayer);
                break;
            case BulletType.bomb:
                break;
            case BulletType.spread:
                break;
        }
    }

    private static void BuildBasicBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {
        var bulletObject = bulletPool.GetNewBullet();
        var bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();

        bulletObject.transform.position = position;
        bulletBehaviour.Direction = direction;
        bulletBehaviour.LifeSpam = 10;
        bulletBehaviour.Power = 5;
        bulletBehaviour.Speed = 200;

        if(shooterIsPlayer)
        {
            bulletObject.layer = LayerMask.NameToLayer("Player");
            bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private static void BuildBombBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {

    }

    private static void BuildSpreadBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {

    }
}
