using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationCharacterController
{
    void StartAnimation(string animation);

    void StopAnimation(string animation);

    void CancelAnimation(string animation);
}

public class AnimationController : MonoBehaviour, IAnimationCharacterController
{
    // TODO: Add editor props and configs

    private bool isRunning = false; // Repeating
    private bool isWalking = false; // Repeating
    private bool isDashing = false; // Repeating
    private bool isFlying = false; // Repeating
    private bool isFalling = false; // Repeating
    private bool isIdle = false; // Repeating

    private bool isJumping = false; // Indeterminate +/-
    private bool isAttacking = false; // Indeterminate
    private bool isChargingAttack = false; // Indeterminate

    [SerializeField]
    public Transform referencePoint;

    [SerializeField]
    Animator animatorComponent;

    public void CancelAnimation(string animation)
    {
        throw new System.NotImplementedException();
    }

    public void StartAnimation(string animation)
    {
        Debug.Log($"Start animation {animation}");
    }

    public void StopAnimation(string animation)
    {
        Debug.Log($"Stop animation {animation}");
    }

    void HandleAnimations()
    {
        if (animatorComponent == null)
        {
            if (!TryGetComponent<Animator>(out animatorComponent))
            {
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

    void Start()
    {
        Debug.Log($"Animation controller started!");
    }

    void _Update()
    {
        // TODO: Check if character status changed then apply changes (stop current animations and start new animations)
        var characterMovementController = (IMovementController)GetComponent<IMovementController>();

        if (characterMovementController == null) return;

        var oldStats = new Dictionary<string, bool>();
        var newStats = new Dictionary<string, bool>();

        oldStats.Add("isRunning", this.isRunning);
        newStats.Add("isRunning", characterMovementController.isRunning());

        /*
        oldStats.Add("isRunning", this.isRunning);
        newStats.Add("isRunning", characterMovementController.IsFalling());

        oldStats.Add("isWalking", this.isRunning);
        newStats.Add("isWalking", characterMovementController.isWalking);

        oldStats.Add("isJumping", this.isRunning);
        newStats.Add("isJumping", characterMovementController.isJumping);
        */

        HandleChangesIfExists(oldStats, newStats);
    }

    void HandleChangesIfExists(Dictionary<string, bool> oldStats, Dictionary<string, bool> newStats)
    {
        HandleAnimationChanges(oldStats, newStats, "isRunning");
        //HandleAnimationChanges(oldStats, newStats, "isWalking");
        //HandleAnimationChanges(oldStats, newStats, "isJumping");
    }

    void HandleAnimationChanges(Dictionary<string, bool> oldStats, Dictionary<string, bool> newStats, string key)
    {
        bool oldStatus = false;
        bool newStatus = false;

        oldStats.TryGetValue(key, out oldStatus);
        newStats.TryGetValue(key, out newStatus);

        bool wasUpdated = oldStatus == newStatus;

        if (!wasUpdated) return;

        if (newStatus) CancelAnimation(key);

        StartAnimation(key);
    }
}
