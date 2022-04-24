using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 6f;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float spawnTimeVarience = 0.3f;

    public Transform GetStartingWavePoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWavePoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;

    }


    public float GetEnemySpeed()
    {
        return enemyMoveSpeed;
    }


    public GameObject GetEnemy(int enemyIndex)
    {
        return enemyPrefabs[enemyIndex];
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public float GetRandomSpawnTime()
    {
        return Random.Range(spawnTime - spawnTimeVarience, spawnTime + spawnTimeVarience);
    }



}
