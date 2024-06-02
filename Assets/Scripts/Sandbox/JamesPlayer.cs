using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;
using UnityEngine;

public class JamesPlayer : MonoBehaviour
{
    [SerializeField] public float shipSpeed = 1f;
    [SerializeField] public GameObject projectile;
    private SpriteRenderer renderer;
    private float widthOfPlayer;
    [SerializeField] private float firingDelay = 1f;
    private float timeUntilFireagain = 1f;
    private float maxX = 8.49f;
    private float minX = -8.49f;
    private float maxY = 4.65f;
    private float minY = -4.65f;
    
    public float FiringDelay
    {
        get => firingDelay;
        set => firingDelay = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        renderer = FindObjectOfType<SpriteRenderer>();
        widthOfPlayer = renderer.sprite.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilFireagain -= Time.deltaTime;
        Move();
        if (Input.GetButton("Fire1") && timeUntilFireagain < 0f)
        {
            StartCoroutine(Fire());
        }
    }

    void Move()
    {
        var vector3 = transform.position;
        
        
        vector3.y += Input.GetAxisRaw("Vertical") * shipSpeed * Time.deltaTime;
        vector3.x += Input.GetAxisRaw("Horizontal") * shipSpeed * Time.deltaTime;
        var newPos = vector3;
        newPos.x = Mathf.Clamp(vector3.x, minX, maxX);
        newPos.y = Mathf.Clamp(vector3.y, minY, maxY);
        
        transform.position = newPos;
    }

    IEnumerator Fire()
    {
        timeUntilFireagain = firingDelay;
        Instantiate(projectile, new Vector3(transform.position.x + 0.4f,transform.position.y + 0.3f, 0), Quaternion.identity);
        Instantiate(projectile, new Vector3(transform.position.x - 0.4f,transform.position.y + 0.3f, 0), Quaternion.identity);
        yield return new WaitForSeconds(firingDelay);
    }
}