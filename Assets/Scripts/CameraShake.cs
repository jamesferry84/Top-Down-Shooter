using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = .5f;
    [SerializeField] public bool cameraMove = false;
    [SerializeField] public float moveSpeed = 0.2f;
    [SerializeField] public float defaultCameraMoveSpeed = 1f;
    [SerializeField] private float finalYPosition = 138f;
    [SerializeField] private bool spawnBoss = false;

    private Vector3 initialPosition;

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
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    public void Move()
    {
        var pos = transform.position;
        pos.z = -10f;

        if (pos.y < finalYPosition)
        {
            pos.y += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            cameraMove = false;
            spawnBoss = true;
            Debug.Log("Final position reached. Ready to spawn the boss!");
        }
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

    public bool ShouldSpawnBoss()
    {
        return spawnBoss;
    }
}