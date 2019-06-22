using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator ani;
    CapsuleCollider colli;
    Transform CameraT;

    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    

    public float runSpeed = 50;
    public float walkSpeed = 25;
    public float jumpForce = 100;
    public float gravity = 10;
    public float currentSpeed;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        colli = GetComponent<CapsuleCollider>();

        CameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.up * -gravity * Time.deltaTime);
        Move();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void Move() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero) {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + CameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKeyDown(KeyCode.LeftShift);

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        //ani.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }


    void Jump() {
        print("jump");
        rb.AddForce(transform.up * jumpForce * Time.deltaTime);
    }
}
