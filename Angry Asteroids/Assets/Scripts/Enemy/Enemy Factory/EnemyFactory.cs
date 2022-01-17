using UnityEngine;

public abstract class EnemyFactory
{
    protected GameObject EnemyPrefab;

    public EnemyFactory()
    {
        EnemyPrefab = Resources.Load("EnemyBasePrefab") as GameObject;
    }

    public abstract GameObject CreateEnemy();
}
