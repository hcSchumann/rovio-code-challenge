using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnProgressionData", menuName = "Enemy Spawn/new EnemeySpawnProgressionData")]
public class EnemeyWaveSpawnProgression : ScriptableObject
{
    public float EasyEnemiesMultiplier = 3;
    public float MediumEnemiesMultiplier = 0.5f;
    public float HardEnemiesMultiplier = 0.2f;

    public int EnemiesLimit = 30;

    [SerializeField]
    public List<EnemyWaveDataOverrideElement> EnemyWaveOverrides;

    [Serializable]
    public class EnemyWaveDataOverrideElement
    {
        public int Wave;
        public EnemyWaveData EnemyWaveData;
    }
}
