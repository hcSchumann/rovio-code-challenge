using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public EnemeyWaveSpawnProgression WaveProgression;
    public UIWaveCounterBehaviour UIWaveCounterBehaviour;

    private GameObject _player;
    private EnemyWaveSpawner _enemyWaveSpawner;
    private int _currentWave = 0;

    private void Start()
    {
        InstantiatePlayer();
        BulletBuilder.Instance.Initialize();

        _enemyWaveSpawner = new EnemyWaveSpawner(WaveProgression);
        _enemyWaveSpawner.OnWaveCleared += StartNewWave;
        StartNewWave();
    }

    private void InstantiatePlayer()
    {
        _player = Instantiate(PlayerPrefab);
        _player.GetComponent<Health>().OnDie += PlayerDied;

        var playerController = _player.GetComponent<PlayerController>();
        playerController.MainCamera = Camera.main;
        var playerShootingBehaviour = _player.GetComponent<ShootingBehaviour>();
        var playerShootingStrategy = new PlayerShootingStrategy();
        playerShootingStrategy.PlayerController = playerController;
        playerShootingBehaviour.ShootingStrategy = playerShootingStrategy;
    }

    private void StartNewWave()
    {
        BulletBuilder.Instance.ClearBullets();
        _enemyWaveSpawner.SpawnEnemyWave(++_currentWave);
        _player.transform.position = Vector3.zero;
        _player.GetComponent<Health>().RestoreHealth();
        UIWaveCounterBehaviour.UpdateWaveCounterText(_currentWave);
    }

    private void PlayerDied()
    {
        BulletBuilder.Instance.ClearBullets();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
