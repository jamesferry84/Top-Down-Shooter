using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    private CameraShake cameraShake;

    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogError("CameraShake not found in the scene.");
        }
    }

    void Update()
    {
        if (cameraShake != null && cameraShake.ShouldSpawnBoss())
        {
            Destroy(gameObject);
            Debug.Log("DeSpawning: " + gameObject.name);
        }
    }
}
