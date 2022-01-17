using UnityEngine;

public abstract class EnemyFactory
{
    protected GameObject EnemyPrefab;
    protected Transform Target;

    public EnemyFactory()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyPrefab = Resources.Load("EnemyBasePrefab") as GameObject;
    }

    public abstract GameObject CreateEnemy();
}
