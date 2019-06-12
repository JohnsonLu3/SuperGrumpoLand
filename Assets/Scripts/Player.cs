using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 25;
    public float jumpForce = 8;
    public float gravity = -8;

    private bool facingRight = true;
    private Rigidbody rb;
    private Animator animator;
    private bool canJump;
    private LayerMask groundLayers;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    } 

    private void Update()
    {
        

        movement();
    }

    void FixedUpdate() {

        

    }

    private void movement() {

        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHori, 0, 0);
        rb.AddForce(movement * moveSpeed);
        rb.AddForce(Vector3.down * gravity);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (true)
            {
                print("Jump");
                canJump = false;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
       
        else {

        }



        if (Input.GetAxis("Horizontal") > 0)
        {
            // Right
            //animator.Play("Running", 0);
            print("right");
            facingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            // Left
            if (facingRight)
            {
                // Rotate Grumpo
            }

            print("right");
            //animator.Play("Running", 0);
            facingRight = false;
        }
        else
        {
            //idle
        }
    }

    private bool IsGrounded() {

        Physics.CheckBox();
        return false;
    }

}
