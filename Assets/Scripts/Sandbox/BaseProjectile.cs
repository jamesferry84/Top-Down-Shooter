using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    [SerializeField] private float speed = 1f;

    [SerializeField] private int bulletsPerShot = 1;

    [SerializeField] private float firingRate;
    // Start is called before the first frame update

    public GameObject Projectile
    {
        get => projectile;
        set => projectile = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public int BulletsPerShot
    {
        get => bulletsPerShot;
        set => bulletsPerShot = value;
    }

    public float FiringRate
    {
        get => firingRate;
        set => firingRate = value;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
