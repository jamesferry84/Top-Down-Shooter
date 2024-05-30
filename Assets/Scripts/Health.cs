using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool applyCameraShake;
    private CameraShake _cameraShake;

    private AudioPlayer audioPlayer;
    private ScoreKeeper _scoreKeeper;
    private LevelManager levelManager;

    public int GetHealth()
    {
        return health;
    }
    

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            audioPlayer.PlayDamageClip();
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
        PathFinder pathFinder = GetComponent<PathFinder>();
        if (pathFinder != null)
        {
            if (pathFinder.checkAllEnemiesDestroyed())
            {
                Debug.Log("All enemies destroyed in wave!! congrats!");
            }
            else
            {
                Debug.Log(pathFinder.getNumOfEnemiesRemaining() + " more enemies to destroy");
            }
            
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!isPlayer)
            {
                _scoreKeeper.UpdateScore(score);
            }
            else
            { 
                levelManager.LoadGameOver();
            }
            
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (_cameraShake != null && applyCameraShake)
        {
            _cameraShake.Play();
        }
    }
}
