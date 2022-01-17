using UnityEngine;

internal class HardEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "HardEnemy";
        enemyObject.GetComponent<Health>().MaxHealth = 50;
        var shootingStrategy = new ForwardShootingStrategy();
        shootingStrategy.SetBulletType(BulletType.bomb);
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = shootingStrategy;
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.black);

        return enemyObject;
    }
}