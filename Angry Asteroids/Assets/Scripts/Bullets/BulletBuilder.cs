using UnityEngine;

public class BulletBuilder
{
    private BulletPool bulletPool;

    private static BulletBuilder _instance;
    public static BulletBuilder Instance { 
        get 
        {
            if (_instance == null)
            {
                _instance = new BulletBuilder();
            }

            return _instance;
        } 
    }

    private BulletBuilder() { }

    public void Initialize()
    {
        Instance.bulletPool = new BulletPool();
    }

    public void BuildBullet(BulletType bulletType, Vector3 position, Vector3 direction, bool shooterIsPlayer = false)
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

    private void BuildBasicBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {
        var bulletObject = Instance.bulletPool.GetNewBullet();
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

    private void BuildBombBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {

    }

    private void BuildSpreadBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {

    }
}
