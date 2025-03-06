using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float speed = 5f;
    private float horizontal;
    private float vertical;
    private Vector2 movement;
    [SerializeField] private Joystick joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        if(movement == Vector2.zero)
        {
            animator.SetBool("Idle", true);
        }
        if(movement != Vector2.zero)
        {
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetBool("Idle", false);
        }
    }
}
