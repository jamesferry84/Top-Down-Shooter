using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigList;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping;
    [SerializeField] private Camera mainCamera; // Reference to the main camera

    WaveConfigSO currentWave;

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (var waveConfig in waveConfigList)
            {
                currentWave = waveConfig;
                Debug.Log("Enemy Count: " + currentWave.GetEnemyCount());
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Vector3 spawnPosition = GetSpawnPosition();
                    Debug.Log($"Spawning enemy {i} at position: {spawnPosition}");
                    Instantiate(currentWave.GetEnemyAtIndex(i), spawnPosition, Quaternion.Euler(0, 0, 180));
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        } while (isLooping);
    }

    Vector3 GetSpawnPosition()
    {
        // Get the current camera position
        Vector3 cameraPosition = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculate the spawning area in front of the camera
        float spawnX = Random.Range(cameraPosition.x - cameraWidth / 2, cameraPosition.x + cameraWidth / 2);
        float spawnY = cameraPosition.y + cameraHeight / 2 + Random.Range(1f, 3f);

        // Ensure enemies spawn in front of the camera's current position
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        return spawnPosition;
    }
}