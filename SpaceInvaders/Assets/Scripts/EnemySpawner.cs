using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{    
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] int repeatWave;

    WaveConfigSO currentWave;
    LevelManager levelManager;
          

    void Awake()
    {
        //currentWave = waveConfigs[0];
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {        
        StartCoroutine(SpawnEnemyWaves());        
    }

    IEnumerator SpawnEnemyWaves()
    {
        for(int x = 0; x < repeatWave; x++)
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < wave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemy(i),
                   currentWave.GetStartingWavePoint().position, Quaternion.identity // 3. paremeter: rotation
                   , transform); // 4. parameter: base transform

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }        
        levelManager.LoadNextLevel();
    }

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }

   

}
