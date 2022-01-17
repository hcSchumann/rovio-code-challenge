using UnityEngine;

internal class MediumEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "MediumEnemy";
        enemyObject.GetComponent<Health>().MaxHealth = 30;
        var shootingStrategy = new ForwardShootingStrategy();
        shootingStrategy.SetBulletType(BulletType.spread);
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = shootingStrategy;
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.blue);

        return enemyObject;
    }
}