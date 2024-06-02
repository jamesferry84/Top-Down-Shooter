using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private JamesPlayer target;
    [SerializeField] private float decreaseFiringDelayAmount = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<JamesPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision happened");
        if (other.tag.Equals("Player"))
        {
            target.FiringDelay -= decreaseFiringDelayAmount;
            Destroy(gameObject);
        }
    }

}
