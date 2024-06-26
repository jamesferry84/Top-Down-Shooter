using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;
    
    [Header("Damage")] 
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume = 1f;

    private static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }
    
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip,
                Camera.main.transform.position,
                shootingVolume);
        }
    }
    
    public void PlayDamageClip()
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip,
                Camera.main.transform.position,
                damageVolume);
        }
    }
}