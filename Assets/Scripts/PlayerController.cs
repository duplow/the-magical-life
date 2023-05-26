using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 7f;
    public float jumpForce = 7f;
    public float turnSmoothTime = 0.1f;
    public float gravityForce = -9.8f;

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

    float currentJumpForce = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        //_rigidbody = GetComponent<Rigidbody>();
        colliderDistanceY = _collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isSpacePressed = Input.GetKeyDown("space");

        if (Input.GetKeyUp("left shift"))
        {
            isShiftPressed = false;
        }

        if (Input.GetKeyDown("left shift"))
        {
            isShiftPressed = true;
        }

        direction = new Vector3(horizontal, 0f, vertical);

        bool isMoving = direction.normalized.magnitude >= 0.1f;
        bool isRunning = isMoving && !isShiftPressed;
        bool isWalking = isMoving && !isRunning;

        if (currentJumpForce <= 0.1f)
        {
            //Debug.Log("Jumping ended");
            animator.SetBool("isJumping", false);
        }

        if (isSpacePressed)
        {
            Debug.Log("Jumping");
            isJumping = true;
            animator.SetBool("isJumping", true);
            currentJumpForce = (gravityForce * -1) + jumpForce;
            //currentJumpForce = Mathf.Lerp(gravityForce, (gravityForce * -1) + jumpForce, Time.deltaTime);
            //currentJumpForce = Mathf.Lerp(currentJumpForce, (gravityForce * -1) + jumpForce, Time.deltaTime);
            //Jump();
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
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        /*
        if (isJumping && controller.isGrounded)
        {
            Debug.Log("Grounded");
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        */

        if (isFlying)
        {
            Debug.Log("Flying");
        }

        //controller.Move(new Vector3(0f, gravityForce * Time.deltaTime));
        //_rigidbody.position += (new Vector3(0f, gravityForce * Time.deltaTime, 0f));

        if (!controller.isGrounded)
        {
            //Debug.Log("Gravity");
            currentJumpForce -= Mathf.Max((gravityForce * -1) + jumpForce * Time.deltaTime, 0);
            controller.Move(Vector3.up * (gravityForce + currentJumpForce) * Time.deltaTime);

            Debug.Log($"Jumping force: {currentJumpForce}");
            Debug.Log($"Upwards force: {gravityForce + currentJumpForce}");
        }
        else
        {
            //Debug.Log("Grounded");
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
        Debug.Log(direction);
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed * Time.deltaTime;
        
        //moveDirection.y = 0f;
        Debug.Log(moveDirection);
        controller.Move(moveDirection);

        //controller.SimpleMove(moveDirection * speed * Time.deltaTime);
        //controller.transform.position = moveDirection * speed * Time.deltaTime;
        // TODO: Fix moviment on jump
    }

    void Jump()
    {
        //_rigidbody.velocity += Vector3.up * jumpForce;
        //controller.Move(Vector3.up * jumpForce);
        //Vector3 moveDirection = new Vector3(0f, jumpForce, 0f) + direction;
        //controller.GetComponent<Rigidbody>().velocity = moveDirection;
        //controller.Move(moveDirection);
        //_rigidbody.position += (new Vector3(0f, jumpForce * Time.deltaTime * -1, 0f));
    }
}
