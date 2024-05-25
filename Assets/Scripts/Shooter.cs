using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float firingRate = 0.5f;
    
    [Header("Conditions")]
    [SerializeField] private bool isPlayer;
    [SerializeField] private float minFiringDelay = 0f;
    [SerializeField] private float maxFiringDelay = 1f;

    [HideInInspector] public bool isFiring;

    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
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
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
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
                body.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(GetRandomSpawnTime());
        }
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(minFiringDelay, maxFiringDelay);
        return Mathf.Clamp(spawnTime, minFiringDelay, maxFiringDelay);
    }
}
