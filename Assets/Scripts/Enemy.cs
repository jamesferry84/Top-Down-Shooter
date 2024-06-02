using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform path;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private float spawnDelay;

    private List<Transform> waypoints = new List<Transform>();
    private int currentWaypoint = 0;
    private void Awake()
    {
        path = GameObject.Find("downLeftPath").transform;

        foreach (Transform child in path)
        {
            waypoints.Add(child);
        }
        
        transform.position = waypoints[0].position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        if (currentWaypoint < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            float delta = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
               // Debug.Log("updating waypoint");
                currentWaypoint++;
            }
        }
        else
        {
           // Debug.Log("Inside else");
            // Destroy(gameObject);
        }
    }

    void GenerateNewEnemy()
    {
        
    }
}
