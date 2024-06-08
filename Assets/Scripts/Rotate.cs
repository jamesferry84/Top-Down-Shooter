using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform parentTransform;

    [SerializeField] float rotationSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0, rotationSpeed) * Time.deltaTime);
        //transform.RotateAround(parentTransform.localPosition, Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
