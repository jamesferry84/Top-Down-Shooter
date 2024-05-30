using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float firingDelay = 10f;
    
    [Header("Conditions")]
    [SerializeField] private bool isPlayer;
    [SerializeField] private float minFiringDelay = 0f;
    [SerializeField] private float maxFiringDelay = 1f;
    [SerializeField] private Transform target;

    [HideInInspector] public bool isFiring;

    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;
    private float elapsedTime = 0f;
    private float currentFiringDelay;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        currentFiringDelay = firingDelay;
    }

    void Start()
    {
        if (!isPlayer)
        {
            isFiring = true;
        }
    }
    
    
    void Update()
    {
         currentFiringDelay -= Time.deltaTime;
         if (currentFiringDelay <= 0f)
         {
            Fire();
         }
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
            currentFiringDelay = firingDelay;
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D body = instance.GetComponent<Rigidbody2D>();
            if (body != null)
            {
                if (target != null)
                {
                    Vector2 direction = (target.transform.position - transform.position).normalized;
                    body.velocity = direction * projectileSpeed;
                }
                else
                {
                    body.velocity = transform.up * projectileSpeed; //test
                }
                
            }
            Destroy(instance, projectileLifeTime);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(firingDelay);
        }
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(minFiringDelay, maxFiringDelay);
        return Mathf.Clamp(spawnTime, minFiringDelay, maxFiringDelay);
    }
}
