using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 rawInput;

    private Vector2 minBounds;
    private Vector2 maxBounds;
    
    [SerializeField] float moveSpeed = .5f;

    private float paddingLeft;
    private float paddingRight;
    private float paddingTop;
    private float paddingBottom;
    private Animator animator;

    private Shooter shooter;
    private CameraShake cameraShake;
    public  Vector2 delta;

    private SpriteRenderer renderer;
    private Bounds bounds;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        animator = FindObjectOfType<Animator>();
        cameraShake = FindObjectOfType<CameraShake>();
        renderer = FindObjectOfType<SpriteRenderer>();
        bounds = renderer.bounds;
        paddingBottom = bounds.size.y / 2;
        paddingTop = bounds.size.y / 2;
        paddingLeft = bounds.size.x / 2;
        paddingRight = bounds.size.x / 2;
        
    }

    private void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(-1000, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1000, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GoBackwards();
    }

    void PlayAnimations()
    {
        if (rawInput.x < -0.1f)
        {
            animator.SetBool("isGoingLeft", true);
            animator.SetBool("isGoingRight", false);
        } else if (rawInput.x > 0.1f)
        {
            animator.SetBool("isGoingRight", true);
            animator.SetBool("isGoingLeft", false);
        }
        else
        {
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
    }

    void Move()
    {
        delta = rawInput * moveSpeed * Time.deltaTime;
        PlayAnimations();
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp((transform.position.y + delta.y), 
            (minBounds.y  + Camera.main.transform.position.y) + paddingBottom, (maxBounds.y + Camera.main.transform.position.y) - paddingTop);
        
        transform.position = newPos;

        if (transform.position.x <= -1)
        {
            var newCamPos = new Vector3();
            newCamPos.x = Camera.main.transform.position.x;
            newCamPos.x = Mathf.Clamp(transform.position.x + (delta.x / 2), (minBounds.x + paddingLeft) - 5f, maxBounds.x - paddingRight);
            newCamPos.z = -10f;
            Camera.main.transform.position = newCamPos;
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void GoBackwards()
    {
        if (Input.GetButton("Fire2"))
        {
            if (cameraShake != null)
            {
                cameraShake.moveSpeed *= -1;
            }
        }
    }
    
}
