using UnityEngine;

public class EasyEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "EasyEnemy";
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.red);

        enemyObject.GetComponent<Health>().MaxHealth = 15;

        var movementBehaviour = enemyObject.GetComponent<MovementBehaviour>();
        movementBehaviour.MovementStrategy = new MoveForwardStrategy(enemyObject.transform);
        movementBehaviour.MovementStrategy.Target = Target; 

        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = new ForwardShootingStrategy();

        return enemyObject;
    }
}
