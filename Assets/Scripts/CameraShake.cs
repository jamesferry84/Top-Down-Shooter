using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = .5f;
    [SerializeField] private float scrollSpeed = 1f;

    private Vector3 initialPosition;

    public float GetScrollingSpeed()
    {
        return scrollSpeed;
    }
   
    void Start()
    {
        initialPosition = transform.position;
    }
    
    void Update()
    {
        transform.position += new Vector3(0,scrollSpeed,0) * Time.deltaTime;
    }

    public void Play()
    {
        StartCoroutine(Shake());
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
}
