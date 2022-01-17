using UnityEngine;

internal class HardEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "HardEnemy";
        enemyObject.GetComponent<Health>().MaxHealth = 50;
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = new ForwardShootingStrategy();
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.black);

        return enemyObject;
    }
}