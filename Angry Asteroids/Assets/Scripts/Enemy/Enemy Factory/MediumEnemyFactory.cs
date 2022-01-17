using UnityEngine;

internal class MediumEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.blue);
        enemyObject.name = "MediumEnemy";

        enemyObject.GetComponent<Health>().MaxHealth = 30;

        var movementBehaviour = enemyObject.GetComponent<MovementBehaviour>();
        movementBehaviour.MovementSpeed = 200f;
        movementBehaviour.MovementStrategy = new MoveForwardStrategy(enemyObject.transform);
        movementBehaviour.MovementStrategy.Target = Target;

        var shootingStrategy = new AimShootingStrategy();
        shootingStrategy.Precision = 0f;
        shootingStrategy.MaxErrorOffset = 100f;
        shootingStrategy.SetBulletType(BulletType.spread);
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = shootingStrategy;


        return enemyObject;
    }
}