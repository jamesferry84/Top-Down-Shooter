using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : BaseProjectile
{

    Vector2 startPoint;
    [SerializeField] private int numberOfProjectiles;
    private float timeUntilShoot;
    private void Awake()
    {
        
    }

    void Start()
    {
        startPoint = transform.position;
        timeUntilShoot = FiringRate;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilShoot -= Time.deltaTime;
        if (timeUntilShoot <= 0f)
        {
            FireInACircle(numberOfProjectiles);
        }
        //Fire();
    }

    void Fire()
    {
        Instantiate(Projectile, transform.position, Quaternion.identity);
    }

    void FireInACircle(int numberOfProjectiles)
    {
        timeUntilShoot = FiringRate;
        float radius = 5f;
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projtileMoveDirection = (projectileVector - startPoint).normalized * Speed;

            var proj = Instantiate(Projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projtileMoveDirection.x, projtileMoveDirection.y);
            angle += angleStep;
        }
        
    }
}
