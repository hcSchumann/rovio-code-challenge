using UnityEngine;

internal class MediumEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "MediumEnemy";
        enemyObject.GetComponent<Health>().MaxHealth = 30;
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = new ForwardShootingStrategy();
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.blue);

        return enemyObject;
    }
}