using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private GameObject _player;

    public EnemeyWaveSpawnProgression WaveProgression;
    private EnemyWaveSpawner _enemyWaveSpawner;
    private int _currentWave = 1;

    private void Start()
    {
        _player = Instantiate(PlayerPrefab);
        var playerShootingBehaviour = _player.GetComponent<ShootingBehaviour>();
        playerShootingBehaviour.ShootingStrategy = new PlayerShootingStrategy();

        BulletBuilder.Instance.Initialize();

        _enemyWaveSpawner = new EnemyWaveSpawner(WaveProgression);
        _enemyWaveSpawner.SpawnEnemyWave(_currentWave);
        _enemyWaveSpawner.OnWaveCleared += StartNewWave;
    }

    private void StartNewWave()
    {
        BulletBuilder.Instance.ClearBullets();
        _enemyWaveSpawner.SpawnEnemyWave(++_currentWave);
        _player.transform.position = Vector3.zero;
        _player.GetComponent<Health>().RestoreHealth();
    }
}
