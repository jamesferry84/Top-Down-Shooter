using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    private CameraShake cameraShake;

    private float moveSpeed;

    [SerializeField] bool slowCameraToZero = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        moveSpeed = cameraShake.moveSpeed;
        slowCameraToZero = false;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y += moveSpeed * Time.deltaTime;
        transform.position = pos;

        if (slowCameraToZero)
        {
            SlowCameraToZero();
        }
        else
        {
            SlowCameraToDefault();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("playerProjectile"))
        {
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("StopCamera"))
        {
            slowCameraToZero = true;
        }
    }

    void SlowCameraToZero()
    {
        if (cameraShake.moveSpeed >= 0.1f)
        {
            cameraShake.moveSpeed -= 0.1f;
        }
        
    }

    void SlowCameraToDefault()
    {
        if (cameraShake.moveSpeed <= cameraShake.defaultCameraMoveSpeed)
        {
            cameraShake.moveSpeed += 0.1f;
        }
    }
}
