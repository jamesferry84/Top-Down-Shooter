using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfig;
    [SerializeField] private float delayBetweenSpawns = 0.5f;
    private float currentYposition;

    public WaveConfigSO GetWaveConfig()
    {
        return waveConfig;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentYposition = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("MainCamera"))
        {
            StartCoroutine(InstantiateEnemyDelay());

        }
    }

    IEnumerator InstantiateEnemyDelay()
    {
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            Debug.Log("Instantiating at y position: " + currentYposition);
            Instantiate(waveConfig.GetEnemyAtIndex(i), 
                new Vector3(waveConfig.GetStartingWaypoint().position.x,currentYposition,0),
                Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
}
