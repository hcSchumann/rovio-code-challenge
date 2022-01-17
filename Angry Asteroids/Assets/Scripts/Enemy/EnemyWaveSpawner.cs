using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner
{
    public Action OnWaveCleared;
    private EnemeyWaveSpawnProgression _waveProgression;
    private List<EnemyFactory> _enemyFactories;
    private int _enemyCount = 0;


    public EnemyWaveSpawner(EnemeyWaveSpawnProgression waveSpawnProgression)
    {
        _waveProgression = waveSpawnProgression;

        _enemyFactories = new List<EnemyFactory>()
        {
            new EasyEnemyFactory(),
            new MediumEnemyFactory(),
            new HardEnemyFactory(),
        };
    }

    public void SpawnEnemyWave(int waveCount)
    {
        var enemyWaveData = GetEnemyWaveData(waveCount);

        _enemyCount = 0;
        SpawnEnemies( _enemyFactories[0], enemyWaveData.EasyEnemies);
        SpawnEnemies( _enemyFactories[1], enemyWaveData.MediumEnemies);
        SpawnEnemies( _enemyFactories[2], enemyWaveData.HardEnemies);
        
    }

    private EnemyWaveData GetEnemyWaveData(int waveCount)
    {
        if (_waveProgression.EnemyWaveOverrides.Count > 0)
        {
            foreach (var waveOverride in _waveProgression.EnemyWaveOverrides)
            {
                if (waveOverride.Wave == waveCount) return waveOverride.EnemyWaveData;
            }
        }

        var enemyWaveData = new EnemyWaveData(
            Mathf.FloorToInt(_waveProgression.EasyEnemiesMultiplier * waveCount),
            Mathf.FloorToInt(_waveProgression.MediumEnemiesMultiplier * waveCount),
            Mathf.FloorToInt(_waveProgression.HardEnemiesMultiplier * waveCount)
        );

        return enemyWaveData;
    }

    private void SpawnEnemies(EnemyFactory factory, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var enemyObject = factory.CreateEnemy();
            _enemyCount++;
            enemyObject.transform.position = ArenaBehaviour.GetRandomPositionInside();
            enemyObject.GetComponent<Health>().OnDie += () => 
            { 
                _enemyCount--;
                if(_enemyCount == 0)
                {
                    OnWaveCleared?.Invoke();
                }
            };
        }
    }
}
