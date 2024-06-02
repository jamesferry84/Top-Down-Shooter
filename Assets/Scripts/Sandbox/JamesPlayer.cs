using System.Collections;
using System.Collections.Generic;
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
        transform.position = vector3;
    }

    IEnumerator Fire()
    {
        timeUntilFireagain = firingDelay;
        Instantiate(projectile, new Vector3(transform.position.x + 0.4f,transform.position.y + 0.3f, 0), Quaternion.identity);
        Instantiate(projectile, new Vector3(transform.position.x - 0.4f,transform.position.y + 0.3f, 0), Quaternion.identity);
        yield return new WaitForSeconds(firingDelay);
    }
}