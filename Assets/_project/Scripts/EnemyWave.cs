using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Enemy Wave", fileName = "WaveX")]
public class EnemyWave : ScriptableObject
{
    [System.Serializable]
    public class WaveUnit
    {
        public CombatEnemy enemyPrefab; 
        public int lane;
        public int x;
    }

    public WaveUnit[] waveUnits;
}
