using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{    
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves;
    WaveConfigSO currentWave;

    void Awake()
    {
        currentWave = waveConfigs[0];
    }
    void Start()
    {        
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        while (true)
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

    }

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }

   

}
