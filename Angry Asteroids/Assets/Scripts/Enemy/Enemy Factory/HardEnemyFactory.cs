using UnityEngine;

internal class HardEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "HardEnemy";
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.black);

        enemyObject.GetComponent<Health>().MaxHealth = 50;

        var movementBehaviour = enemyObject.GetComponent<MovementBehaviour>();
        movementBehaviour.MovementSpeed = 30f;
        movementBehaviour.MovementStrategy = new FollowTargetMovementStrategy();
        movementBehaviour.MovementStrategy.Self = enemyObject.transform;
        movementBehaviour.MovementStrategy.Target = Target;

        var shootingStrategy = new AimShootingStrategy();
        shootingStrategy.Precision = 1f;
        shootingStrategy.SetBulletType(BulletType.bomb);
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = shootingStrategy;

        return enemyObject;
    }
}