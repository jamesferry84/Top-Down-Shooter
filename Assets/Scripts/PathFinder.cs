using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int currentWaypoint = 0;
    private Camera mainCamera;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        mainCamera = Camera.main; // Reference to the main camera
    }

    void Start()
    {
        waveConfig = enemySpawner.getCurrentWave();
        AdjustWaypointsToCurrentPosition();
        transform.position = waypoints[currentWaypoint].position;
    }
    
    void Update()
    {
        FollowPath();
    }

    public bool checkAllEnemiesDestroyed()
    {
        waveConfig.removeEnemy();
        return waveConfig.AllEnemiesDestroyed();
    }

    public int getNumOfEnemiesRemaining()
    {
        return waveConfig.GetEnemyCount();
    }

    void FollowPath()
    {
        if (currentWaypoint < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void AdjustWaypointsToCurrentPosition()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        for (int i = 0; i < waypoints.Count; i++)
        {
            Vector3 adjustedPosition = new Vector3(
                waypoints[i].position.x,
                waypoints[i].position.y + cameraPosition.y,
                waypoints[i].position.z
            );
            waypoints[i].position = adjustedPosition;
        }
    }
}