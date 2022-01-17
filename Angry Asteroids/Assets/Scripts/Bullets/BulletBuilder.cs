using UnityEngine;

public class BulletBuilder
{
    private BulletPool _bulletPool;

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
        Instance._bulletPool = new BulletPool();
    }

    public void ClearBullets()
    {
        Instance._bulletPool.Reset();
    }

    public void BuildBullet(BulletType bulletType, Vector3 position, Vector3 direction, bool shooterIsPlayer = false)
    {
        switch(bulletType)
        {
            case BulletType.basic:
                BuildBasicBullet(position, direction, shooterIsPlayer);
                break;
            case BulletType.bomb:
                BuildBombBullet(position, direction, shooterIsPlayer);
                break;
            case BulletType.spread:
                BuildSpreadBullet(position, direction, shooterIsPlayer);
                var rotationQuat = new Quaternion();
                rotationQuat.eulerAngles = new Vector3(0, 0, 30);
                BuildSpreadBullet(position, rotationQuat * direction, shooterIsPlayer);
                rotationQuat.eulerAngles = new Vector3(0, 0, -30);
                BuildSpreadBullet(position, rotationQuat * direction, shooterIsPlayer);
                break;
        }
    }

    private void BuildBasicBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {
        var bulletObject = Instance._bulletPool.GetNewBullet();
        var bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();

        bulletObject.transform.position = position;
        bulletObject.layer = LayerMask.NameToLayer("Player");
        bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.red;
        bulletBehaviour.Direction = direction;
        bulletBehaviour.Size = 15;
        bulletBehaviour.LifeSpam = 2;
        bulletBehaviour.Power = 5;
        bulletBehaviour.Speed = 700;

        if(shooterIsPlayer)
        {
            bulletObject.layer = LayerMask.NameToLayer("Enemy");
            bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void BuildBombBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {
        var bulletObject = Instance._bulletPool.GetNewBullet();
        var bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();

        bulletObject.transform.position = position;
        bulletObject.layer = LayerMask.NameToLayer("Player");
        bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.black;
        bulletBehaviour.Direction = direction;
        bulletBehaviour.Size = 50;
        bulletBehaviour.LifeSpam = 5;
        bulletBehaviour.Power = 25;
        bulletBehaviour.Speed = 100;

        if (shooterIsPlayer)
        {
            bulletObject.layer = LayerMask.NameToLayer("Enemy");
            bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void BuildSpreadBullet(Vector3 position, Vector3 direction, bool shooterIsPlayer)
    {
        var bulletObject = Instance._bulletPool.GetNewBullet();
        var bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();

        bulletObject.transform.position = position;
        bulletObject.layer = LayerMask.NameToLayer("Player");
        bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.blue;
        bulletBehaviour.Direction = direction;
        bulletBehaviour.Size = 10;
        bulletBehaviour.LifeSpam = 5;
        bulletBehaviour.Power = 5;
        bulletBehaviour.Speed = 700;

        if (shooterIsPlayer)
        {
            bulletObject.layer = LayerMask.NameToLayer("Enemy");
            bulletBehaviour.VisualObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
