using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigList;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    WaveConfigSO currentWave;

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }

    void Start()
    {
         StartCoroutine(SpawnEnemyWaves());
       // SpawnEnemyWaves();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("MainCamera"))
        {
            Debug.Log("Collided with main camera");
        }
    }


    IEnumerator SpawnEnemyWaves()
    {

        // do
        // {
            foreach (var waveConfig in waveConfigList)
            {
                currentWave = waveConfig;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyAtIndex(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.Euler(0,0,180),
                        transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
             }
             yield return new WaitForSeconds(timeBetweenWaves);
        } //while (isLooping);
        
    
}