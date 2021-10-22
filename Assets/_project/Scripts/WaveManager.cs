using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static int waveIndex = 0;
    public EnemyWave[] waves;
    public EnemyWave currentWave { get { return waves[waveIndex]; } }

    public void Awake()
    {
        TurnManager.OnBattleWin.AddListener(OnWin);
        PlayerLaneUnit.OnDeath.AddListener(() => waveIndex = 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            waveIndex = 0;
    }

    void OnWin()
    {
        waveIndex++;
        if(waveIndex >= waves.Length)
        {
            SceneLoader.instance.LoadScene(2);
            waveIndex = 0;
            return;
        }

        StartCoroutine(WinCoroutine());
    }
    IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneLoader.instance.LoadScene(1,1f);
    }
}
