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
    [SerializeField] private Player player;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
    }

    void Start()
    {
       // player = GetComponent<Player>();
        // waveConfig = enemySpawner.getCurrentWave();
        // waypoints = waveConfig.GetWaypoints();
        // transform.position = waypoints[currentWaypoint].position;
    }
    
    void Update()
    {
        if (waypoints != null)
        {
            FollowPath();
        }
        else
        {
            FollowPlayer();
        }

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

    void FollowPlayer()
    {

        if (player != null)
        {
            Debug.Log("inside follow player");
            //get position of player
            var playerPos = player.transform.position;
            var currentPos = transform.position;
            var difference = (playerPos - currentPos);
            
            float delta = 1f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(currentPos, playerPos, delta);
            
            Vector3 relativePos = difference;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward,relativePos);
            rotation.x = transform.rotation.x;
            rotation.y = transform.rotation.y;
            transform.rotation = rotation;
            //transform.rotation = Quaternion.RotateTowards();
            // Vector2 direction = (player.transform.position - transform.position).normalized;
            // body.velocity = direction * enemyProjectileSpeed;
        }
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
