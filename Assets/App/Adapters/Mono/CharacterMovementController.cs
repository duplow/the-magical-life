using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
    void Move(Vector3 direction, float speed = 1f);

    void Dash(Vector3 direction);

    void Jump();

    void GoUp();

    void GoDown();

    // TODO: Throw exception instead?
    void SetFlyMode(bool isActive);

    bool IsGrounded();

    bool IsFalling();

    bool IsFlying();

    bool CanLanding();

    bool IsValidMove(Vector3 direction, float speed = 1f);

    //bool DisableFlyMode();

    // TODO: Add events ex: OnMoved, OnFall, OnFalling, OnFly, OnGround, OnAir, OnDash, OnSpeedChanged, OnLanding
}

public class InvalidPositionException : System.Exception {
    public InvalidPositionException(string message) : base(message) { }
}

public class CharacterMovementController : MonoBehaviour, IMovementController
{
    #region Editor props
    [SerializeField]
    public GameObject Character;

    [SerializeField]
    public Transform CharacterTransform;

    [SerializeField]
    public CharacterController CharacterController;

    [SerializeField]
    public float AutoLandingDistance = 1f;

    [SerializeField]
    public float GroundDistanceClearance = 0.1f; // IsGrounded - Margin of error for ground clearance
    #endregion

    #region Internal props
    private Collider CharacterCollider;
    private bool _isFlying = false;
    #endregion Internal props

    private void Start()
    {
        if (Character == null)
        {
            throw new System.Exception("Character not component not defined");
        }

        CharacterCollider = Character.GetComponent<Collider>();

        if (CharacterTransform == null)
        {
            CharacterTransform = Character.GetComponent<Transform>();
        }

        if (CharacterController == null)
        {
            CharacterController = Character.GetComponent<CharacterController>();
        }
    }

    private float GetCharacterBoundsY()
    {
        return CharacterCollider.bounds.extents.y;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetCharacterBoundsY() + this.GroundDistanceClearance);
    }

    public bool IsFlying()
    {
        return _isFlying && !IsGrounded();
    }

    public bool IsFalling()
    {
        return !IsGrounded() && !IsFlying();
    }

    public void Takedown()
    {
        // TODO: Force character to fall on ground
    }

    public bool CanLanding()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetCharacterBoundsY() + this.AutoLandingDistance);
    }

    public void Dash(Vector3 direction)
    {
        // TODO: When dashing add smoke and wind effect
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        CharacterController.Move(Vector3.up * 1f);
        // Start jump coroutine (starts jump animation)
        // Can be interrupted
    }

    public bool IsValidMove(Vector3 direction, float speed)
    {
        try
        {
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Unexpected exception while checking if the character move is valid:\n{ex.Message}");
            return false;
        }
    }


    private Transform GetCameraTransform()
    {
        return Camera.main.transform;
    }

    public void Move(Vector3 direction, float speed = 1)
    {
        try
        {
            if (!IsValidMove(direction, speed))
            {
                throw new InvalidPositionException("Position invalid");
            }

            // Perform Collision checks?

            // Perform camera rotation? // TODO: Check if camera existis in character, if exists then rotate!

            // Perform movement
            float turnSmoothTime = 0.1f;
            float turnSmoothVelocity = 0;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GetCameraTransform().eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Character.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 eulerDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed * Time.deltaTime;

            // CharacterController.Move(direction * speed);
            CharacterController.Move(eulerDirection);

            /*
            Debug.Log(direction);
            

            //moveDirection.y = 0f;
            Debug.Log(moveDirection);
            controller.Move(moveDirection);
            */
        }
        catch (InvalidPositionException)
        {
            // Do nothing here
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            throw new System.Exception($"Unexpected exception while moving character error:\n{ex.Message}", ex);
        }
    }

    public void SetFlyMode(bool isActive)
    {
        // TODO: When hit, disable flymode,so player can fall .Takedown()
        throw new System.NotImplementedException();
    }

    public void GoUp()
    {
        // TODO: Check if is on ground
        // TODO: Check if can fly
        // TODO: Enable fly mode
        // TODO: Move Up
        throw new System.NotImplementedException();
    }

    public void GoDown()
    {
        // TODO: Check if is on air
        // TODO: Move Down
        // TODO: Check if can already landing
        // TODO: Disable fly mode
        // TODO: Land on ground
        throw new System.NotImplementedException();
    }

    void Update()
    {
        // TODO: Recompute states and dispatch events
        // TODO: Gravity
    }
}
