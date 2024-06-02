using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectile : MonoBehaviour
{
    [SerializeField] public float projectileSpeed = 1f;
    [SerializeField] private bool shootUp = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var vector3 = transform.position;
        if (shootUp)
        {
            vector3.y += projectileSpeed * Time.deltaTime;
        }
        else
        {
            vector3.y -= projectileSpeed * Time.deltaTime;
        }
       
        transform.position = vector3;
    }
}