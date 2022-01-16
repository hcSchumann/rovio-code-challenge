using UnityEngine;

public class BulletPool
{
    private GameObject _bulletPrefab;
    private GameObject _bulletPoolParentObject;
    private GameObject[] _bulletPool;
    private int poolCapacity = 300;

    private int _availableBulletsOnPool = 0;

    public BulletPool()
    {
        _bulletPrefab = Resources.Load("BulletPrefab") as GameObject;
        _bulletPool = new GameObject[poolCapacity];
        _bulletPoolParentObject = new GameObject();
        _bulletPoolParentObject.name = "BulletPool";
    }

    public GameObject GetNewBullet()
    {
        if(_availableBulletsOnPool > 0)
        {
            return GetPooledBullet();
        }

        var newBulletObject = GameObject.Instantiate(_bulletPrefab);
        newBulletObject.transform.parent = _bulletPoolParentObject.transform;

        if (_availableBulletsOnPool < poolCapacity)
        {
            newBulletObject.GetComponent<BulletBehaviour>().OnBulletDie += OnTrackedBulletDied;
        }

        return newBulletObject;
    }

    private GameObject GetPooledBullet()
    {
        var pooledBullet =_bulletPool[--_availableBulletsOnPool];
        pooledBullet.SetActive(true);
        return pooledBullet;
    }

    private void OnTrackedBulletDied(GameObject bulletObject)
    {
        if (_availableBulletsOnPool >= poolCapacity)
        {
            GameObject.Destroy(bulletObject);
            return;
        }

        bulletObject.SetActive(false);
        _bulletPool[_availableBulletsOnPool++] = bulletObject;
    }
}