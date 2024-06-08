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

    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    private Animator animator;

    private Shooter shooter;


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        animator = FindObjectOfType<Animator>();

    }

    private void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        PlayAnimations();
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp((transform.position.y + delta.y), minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        
        transform.position = newPos;
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
}
