using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMovement {

    bool IsGrounded();
    bool CanLanding();
    bool IsFlying { get; } // TODO: If flying mode is enabled
    bool IsWalking { get; }
    bool IsRunning { get; }
    bool IsJumping { get; }
    bool IsFalling { get; }

    void DoLanding(); // Only when in free fall
    void DoWalk(Vector3 direction);
    void DoRun(Vector3 direction);
    void DoMove(Vector3 direction, float speed); // TODO: Replace Walk and Run? (can be used in flying mode too) speed 2f = dodge?
    void DodgeToLeft(); // Side-walking
    void DodgeToRight(); // Side-walking
    void DodgeToBack();
    void DoJump();
    void EnableFlyingMode();
    void DisableFlyingMode();
    void FollowPath(List<Vector3> directions, float duration);
}

public class MovementController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float runSpeed = 1f;
    public float walkSpeed = 0.4f;
    public float jumpForce = 2f;
    public float gravityForce = 2f;
    public float groundPrecision = 0.1f; // Taxa de erro para isGrounded
    public float landingMinDistance = 1.5f;

    bool isLeftShiftPressed = false;
    bool isRightShiftPressed = false;
    bool isSpacePressed = false;

    [SerializeField]
    bool isShiftPressed = false;

    [SerializeField]
    bool isWalking = false;

    [SerializeField]
    bool isRunning = false;

    [SerializeField]
    bool isJumping = false;

    [SerializeField]
    bool isFalling = false;

    [SerializeField]
    bool isFlying = false; // Turn on / turn off

    [SerializeField]
    float currentJumpForce = 0f; // Player relative gravity

    [SerializeField]
    float computedGravity = 0f;

    [SerializeField]
    float computedSpeed = 0f;

    [SerializeField]
    Vector3 direction = new Vector3(0f, 0f, 0f);

    [SerializeField]
    Vector3 direction3d = new Vector3(0f, 0f, 0f);

    Animator animatorComponent;

    void Awake()
    {
        computedGravity = gravityForce * -1;
        direction = new Vector3(0f, 0f, 0f);
        computedSpeed = walkSpeed;
    }

    void HandleInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyUp("left shift"))
        {
            isShiftPressed = false;
        }

        if (Input.GetKeyDown("left shift"))
        {
            isShiftPressed = true;
        }

        if (Input.GetKeyUp("space"))
        {
            isSpacePressed = false;
        }

        if (Input.GetKeyDown("space"))
        {
            isSpacePressed = true;

            if (!isFlying) {
                OnJumpStart();
            }
        }

        if (Input.GetKeyDown("q"))
        {
            isFlying = true;
        }

        if (Input.GetKeyDown("e"))
        {
            isFlying = false;
        }

        direction = new Vector3(horizontal, 0f, vertical);

        if (isFlying && isSpacePressed)
        {
            direction = direction + Vector3.up;
        }

        if (direction.normalized.magnitude >= 0.1f)
        {
            // TOOD: Handle move
            // TriggerMove(); // TODO: Maybe move to handleEffects
            OnWalkStart();
        }
    }

    float ComputeGravity()
    {
        if (isFlying) {
            return 0;
        }

        return (gravityForce * -1) + currentJumpForce;
    }

    void HandleEffects()
    {
        float deltaGravity = Mathf.Max(gravityForce * -1, (gravityForce * -1) + currentJumpForce) * Time.deltaTime;

        computedSpeed = isShiftPressed ? walkSpeed : runSpeed;
        computedGravity = ComputeGravity();
        isFalling = !controller.isGrounded && currentJumpForce <= 0.1f && !isFlying;
        direction3d = (direction + Vector3.up * computedGravity) * computedSpeed * Time.deltaTime;

        bool isDoingHorizontalMove = Mathf.Abs(direction.x) + Mathf.Abs(direction.z) > 0.1f;

        isWalking = isShiftPressed && isDoingHorizontalMove;
        isRunning = !isShiftPressed && isDoingHorizontalMove;

        // After effects
        if (currentJumpForce > 0)
        {
            float maxGravity = gravityForce + jumpForce;
            currentJumpForce = Mathf.Max(currentJumpForce - (maxGravity * Time.deltaTime), 0); // Decrease jump force
        }

        if (currentJumpForce <= 0.1f && isJumping)
        {
            isJumping = false; // Is fallen forever?
            OnJumpEnd();
        }

        controller.Move(direction3d);
    }

    void OnWalkStart()
    {
        // Debug.Log("Walk started");
    }

    void OnWalkEnd()
    {
        // Debug.Log("Walk ended");
    }

    void OnRunStart()
    {
    
    }

    void OnRunEnd()
    {
    
    }

    void OnLandingStart()
    {
    
    }

    void OnLandingEnd()
    {
    
    }

    void OnJumpStart()
    {
        //Debug.Log("Jump start");
        isJumping = true;
        //animator.SetBool("isJumping", true);
        currentJumpForce = gravityForce + jumpForce;
    }

    void OnJumpEnd()
    {
        //Debug.Log("Jump end");
    }

    void OnTouchGround()
    {
    
    }

    void OnFlyStart()
    {
    
    }

    void OnFlyEnd()
    {
    
    }

    bool IsGrounded()
    {
        //return Physics.Raycast(transform.position, -Vector3.up, colliderDistanceY + 0.1f);
        return controller.isGrounded;
    }

    bool CanLanding()
    {
        Collider playerCollider;

        if (TryGetComponent<Collider>(out playerCollider))
        {
            return Physics.Raycast(transform.position, -Vector3.up, playerCollider.bounds.extents.y + landingMinDistance);
        }

        return false;
    }

    void HandleAnimations()
    {
        if (animatorComponent == null)
        {
            if (!TryGetComponent<Animator>(out animatorComponent)) {
                Debug.LogWarning("Animator not found!");
            }
        }

        if (animatorComponent != null)
        {
            if (animatorComponent.GetBool("isJumping") != isJumping)
            {
                animatorComponent.SetBool("isJumping", isJumping);
            }

            if (animatorComponent.GetBool("isWalking") != isWalking)
            {
                animatorComponent.SetBool("isWalking", isWalking);
            }

            if (animatorComponent.GetBool("isRunning") != isRunning)
            {
                animatorComponent.SetBool("isRunning", isRunning);
            }

            if (animatorComponent.GetBool("isFlying") != isFlying)
            {
                animatorComponent.SetBool("isFlying", isFlying);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        HandleEffects();
        HandleAnimations();

        /*
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
            //Move(direction);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

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

        currentJumpForce -= Mathf.Max((gravityForce * -1) + jumpForce * Time.deltaTime, 0);
        var upwardsDirection = Vector3.up * (gravityForce + currentJumpForce) * Time.deltaTime;

        Debug.Log($"Jumping force: {currentJumpForce}");
        Debug.Log($"Upwards force: {gravityForce + currentJumpForce}");

        Move(direction + upwardsDirection);
        */
    }
}
