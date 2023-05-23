using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 7f;
    public float jumpForce = 12f;
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    Vector3 direction;
    Animator animator;
    Collider _collider;
    Rigidbody _rigidbody;

    bool isShiftPressed = false;
    bool isJumping = false;
    bool isFlying = false;
    float colliderDistanceY = 0.1f;
    float landingDistance = 4f;

    void Start()
    {
        animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        colliderDistanceY = _collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //bool isShiftPressed = Input.GetKeyDown("left shift");
        bool isSpacePressed = Input.GetKeyDown("space");

        if (Input.GetKeyDown("left shift"))
        {
            isShiftPressed = true;
        }

        if (Input.GetKeyUp("left shift"))
        {
            isShiftPressed = false;
        }

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        bool isMoving = direction.magnitude >= 0.1f;
        bool isRunning = isMoving && !isShiftPressed;
        bool isWalking = isMoving && isShiftPressed;

        if (isSpacePressed)
        {
            isJumping = true;
            //animator.SetBool("isJumping", true);
            Jump();
        }

        if (isMoving)
        {
            Debug.Log("Moving");
            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isRunning", isRunning);
            Move(direction);
        }
        else
        {
            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isRunning", isRunning);
        }

        if (isJumping && controller.isGrounded)
        {
            Debug.Log("Grounded");
            isJumping = false;
            //animator.SetBool("isJumping", false);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, colliderDistanceY + 0.1f);
    }

    bool CanLanding()
    {
        return Physics.Raycast(transform.position, -Vector3.up, colliderDistanceY + landingDistance);
    }

    void Move(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        // TODO: Fix moviment on jump
    }

    void Jump()
    {
        Debug.Log("Jumping");
        Vector3 moveDirection = new Vector3(0f, jumpForce, 0f) + direction;
        //controller.GetComponent<Rigidbody>().velocity = moveDirection;
        controller.Move(moveDirection);
    }
}
