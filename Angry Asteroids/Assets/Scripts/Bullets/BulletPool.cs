using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private GameObject _bulletPrefab;
    private GameObject _bulletPoolParentObject;
    private GameObject[] _bulletPool;
    private List<GameObject> _trackedBullets;
    private int poolCapacity = 300;

    private int _availableBulletsOnPool = 0;

    public BulletPool()
    {
        _bulletPrefab = Resources.Load("BulletPrefab") as GameObject;
        _bulletPool = new GameObject[poolCapacity];
        _trackedBullets = new List<GameObject>();
        _bulletPoolParentObject = new GameObject();
        _bulletPoolParentObject.name = "BulletPool";
    }

    public void Reset()
    {
        _availableBulletsOnPool = 0;
        _bulletPool = new GameObject[poolCapacity];
        foreach (var bullet in _trackedBullets)
        {
            bullet.GetComponent<BulletBehaviour>().OnBulletDie -= OnTrackedBulletDied;
            GameObject.Destroy(bullet);
        }
        _trackedBullets.Clear();
    }

    public GameObject GetNewBullet()
    {
        if(_availableBulletsOnPool > 0)
        {
            return GetPooledBullet();
        }

        var newBulletObject = GameObject.Instantiate(_bulletPrefab);
        _trackedBullets.Add(newBulletObject);

        newBulletObject.transform.parent = _bulletPoolParentObject.transform;
        newBulletObject.GetComponent<BulletBehaviour>().OnBulletDie += OnTrackedBulletDied;

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