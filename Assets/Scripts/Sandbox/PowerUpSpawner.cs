using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private bool testingMode = false;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] private GameObject powerUpToSpawn;
    private float currentTimer = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (testingMode)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                SpawnPowerUp();
            }
        }
    }
    
    void SpawnPowerUp()
    {
        currentTimer = spawnDelay;
        Instantiate(powerUpToSpawn, transform.position, quaternion.identity);
    }
}
