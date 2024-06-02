using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private float firingDelay = 1f;

    [SerializeField] private int health = 100;

    [SerializeField] private GameObject target;

    [SerializeField] private GameObject projectile;
    // Start is called before the first frame update
    private float timeUntilFireagain;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilFireagain -= Time.deltaTime;
        if (timeUntilFireagain <= 0f)
        {
            Fire();
        }
    }
    
    IEnumerator Fire()
    {
        timeUntilFireagain = firingDelay;
        Instantiate(projectile, new Vector3(transform.position.x,transform.position.y - 0.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(firingDelay);
    }
}
