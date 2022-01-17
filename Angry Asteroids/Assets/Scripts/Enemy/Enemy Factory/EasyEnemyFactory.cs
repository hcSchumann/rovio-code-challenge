using UnityEngine;

public class EasyEnemyFactory : EnemyFactory
{
    public override GameObject CreateEnemy()
    {
        var enemyObject = GameObject.Instantiate(EnemyPrefab);
        enemyObject.name = "EasyEnemy";
        enemyObject.GetComponent<Health>().MaxHealth = 15;
        enemyObject.GetComponent<ShootingBehaviour>().ShootingStrategy = new ForwardShootingStrategy();
        enemyObject.GetComponent<EnemyVisual>().SetEnemyColor(Color.red);

        return enemyObject;
    }
}
