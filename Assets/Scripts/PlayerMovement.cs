using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5f;
    public float SprintMultiplier = 2f;
    private float JumpForce = 60f;
    private float GroundCheckDistance = 1f;
    public float LookSensitivityX = 1f;
    public float LookSensitivityY = 1f;
    public float MinYLookAngle = -90f;
    public float MaxYLookAngle = 90f;
    public Transform PlayerCamera;
    private float Gravity = -30f;
    private Vector3 velocity;
    private float verticalRotation = 0;
    private CharacterController characterController;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        moveDirection.Normalize();

        float speed = WalkSpeed;

        if (Input.GetAxis("Sprint") > 0) {
            speed *= SprintMultiplier;
        }

        characterController.Move(moveDirection * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            velocity.y += JumpForce;
            Debug.Log(velocity.y);
            Debug.Log(velocity.y);
        } else {
            velocity.y = Gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);

        if (PlayerCamera != null) {
            float mouseX = Input.GetAxis("Mouse X") * LookSensitivityX;
            float mousey = Input.GetAxis("Mouse Y") * LookSensitivityY;

            verticalRotation -= mousey;
            verticalRotation = Mathf.Clamp(verticalRotation, MinYLookAngle, MaxYLookAngle);

            PlayerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    bool IsGrounded() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, GroundCheckDistance)) {
            return true;
        }
        return false;
    }
}
