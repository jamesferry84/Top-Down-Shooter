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

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
    }

    void Start()
    {
        waveConfig = enemySpawner.getCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[currentWaypoint].position;
    }
    
    void Update()
    {
        FollowPath();
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
}
