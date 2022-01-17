using System;

[Serializable]
public class EnemyWaveData
{
    public EnemyWaveData(int easy, int medium, int hard)
    {
        EasyEnemies = easy;
        MediumEnemies = medium;
        HardEnemies = hard;
    }

    public int EasyEnemies;
    public int MediumEnemies;
    public int HardEnemies;
}
