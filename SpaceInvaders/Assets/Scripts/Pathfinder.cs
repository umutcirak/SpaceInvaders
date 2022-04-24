using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;    
    List<Transform> wavePoints;
    int wavePointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.getCurrentWave();
        wavePoints = waveConfig.GetWavePoints();
        transform.position = wavePoints[wavePointIndex].position;
        
        
    }
        
    void Update()
    {
        FollowPath();
    }

   void FollowPath()
    {
       if(wavePointIndex < wavePoints.Count)
        {
            float deltaSpeed = waveConfig.GetEnemySpeed() * Time.deltaTime;
            Vector3 targetPosition = wavePoints[wavePointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, deltaSpeed);
            if(transform.position == targetPosition)
            {
                wavePointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
