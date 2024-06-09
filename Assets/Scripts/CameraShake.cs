using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = .5f;
    [SerializeField] public bool cameraMove = false;
    [SerializeField] public float moveSpeed = 0.2f;
    [SerializeField] public float defaultCameraMoveSpeed = 1f;

    private Vector3 initialPosition;

    private bool slowCameraToZero = false;
    
    
   
    void Start()
    {
        initialPosition = transform.position;
    }
    
    void Update()
    {
        if (cameraMove)
        {
            Move();
        }

        if (slowCameraToZero)
        {
            SlowCameraToZero();
        }
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    public void Move()
    {
        var pos = transform.position;
        pos.z = -10f;
        pos.y += moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
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
        if (moveSpeed > 0.1f)
        {
            moveSpeed -= 0.1f;
        }
    }
}
