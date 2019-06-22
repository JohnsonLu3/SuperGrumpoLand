using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public bool cursorLock = true;
    public float distFromTarget = 5;
    public Transform target;

    float yaw;
    float pitch;
    float MouseSensitivity = 2.5f;
    float RotationSmooth = .12f;

    Vector2 pitch_MaxMin = new Vector2(-30, 75);
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private void Start()
    {
        if (cursorLock) {
            lockCursor();
        }
    }

    private void Update()
    {
        checkCursorLock();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitch_MaxMin.x, pitch_MaxMin.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, RotationSmooth);

        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * distFromTarget;
    }


    void checkCursorLock() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (cursorLock)
            {
                lockCursor();
            }
            else
            {
                unlockCursor();
            }
        }
    }

    void unlockCursor() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void lockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
