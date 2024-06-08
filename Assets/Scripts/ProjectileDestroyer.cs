using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    private CameraShake cameraShake;

    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        moveSpeed = cameraShake.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y += moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("playerProjectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
