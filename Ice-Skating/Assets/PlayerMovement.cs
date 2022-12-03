using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables 
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float moveSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;    
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    
    
    
    //References
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float moveZ = Input.GetAxis("Vertical");
        
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
       
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //WAlK
                walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //RUN
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //IDLE
                Idle();
            }
            moveDirection *= moveSpeed;
        }

        
        controller.Move(moveDirection * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f,Time.deltaTime );
    }

    private void walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 1, 0.1f,Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }
}

