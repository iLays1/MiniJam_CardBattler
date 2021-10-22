using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private void Awake()
    {
        var wave = FindObjectOfType<WaveManager>().currentWave;
        
        foreach(var wu in wave.waveUnits)
        {
            var e = Instantiate(wu.enemyPrefab);
            e.laneIndex = wu.lane;
            e.x = wu.x;
        }
    }
}
