using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterInput {
    protected static Dictionary<string, float> LastPressedTime = new Dictionary<string, float>();
    protected static Dictionary<string, bool> IsPressed = new Dictionary<string, bool>();

    public static bool GetButtonDoubleDown(string button, float maxTime = 0)
    {
        //float lastPressedTime = 0;
        //LastPressedTime.TryGetValue(button, out lastPressedTime);

        return false;

        /*
        if (Input.GetButtonDown(button))
        {
            DispatchEvent(startType, 1);
            return;
        }

        if (Input.GetButton(button))
        {
            DispatchEvent(chargingType, 2);
            return;
        }
        */
    }

    public static bool GetButtonHold(string button)
    {
        return false;
    }

    /// <summary>
    /// Check if button is being pressed
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public static bool IsButtonPressing(string button)
    {
        return false;
    }

    /// <summary>
    /// Check if button was pressed then released and pressed again
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public static bool IsButtonDashing(string button)
    {
        return false;
    }
}

public class MouseKeyboardInputService : IInputService
{
    private ILoggerService logger;

    protected virtual void OnInputReceived(InputServiceEventArgs e)
    {
        EventHandler<InputServiceEventArgs> handler = InputReceived;

        if (handler != null)
        {
            handler(this, e);
        }
    }

    public event EventHandler<InputServiceEventArgs> InputReceived;

    public MouseKeyboardInputService(ILoggerService loggerService)
    {
        this.logger = loggerService;
    }

    private void DispatchEvent(InputEventType eventType, object data)
    {
        this.logger.Debug($"Input event dispatched from Input service [{eventType.ToString()}]: {data.ToString()}");
        OnInputReceived(new InputServiceEventArgs { EventType = eventType, EventData = data });
    }

    /// <summary>
    /// Register keys and emit events
    /// </summary>
    public void GetEvents()
    {
        this.HandleMoveEvents();
        this.HandleCameraEvents();
        this.HandleActionEvents();
        this.HandleNavigationEvents();
    }

    /// <summary>
    /// Move handler
    /// </summary>
    private void HandleMoveEvents()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveX, 0f, moveY).normalized;
        //Vector3.forward + Vector3.right * new Vector3();

        if (direction.magnitude > 0.1f)
        {
            // TODO: Double press to hyper speed (dash)
            DispatchEvent(InputEventType.MOVE_DIRECTION, direction);
        }

        if (Input.GetButtonDown("Jump"))
        {
            // TODO: Double jump to enable fly
            DispatchEvent(InputEventType.JUMP, 0);
        }

        if (Input.GetKeyUp("left shift"))
        {
            DispatchEvent(InputEventType.SPEED_MODIFIER_SLOW, 1);
        }

        if (Input.GetKeyDown("left shift"))
        {
            DispatchEvent(InputEventType.SPEED_MODIFIER_FAST, 2);
        }

        /*
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            DispatchEvent(InputEventType.MOVE_AXIS_Y, 1);
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            DispatchEvent(InputEventType.MOVE_AXIS_Y, -1);
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            DispatchEvent(InputEventType.MOVE_AXIS_X, -1);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            DispatchEvent(InputEventType.MOVE_AXIS_X, 1);
        }
        */
    }

    /// <summary>
    /// Camera zoom and rotation
    /// </summary>
    private void HandleCameraEvents()
    {
        // Handle camera zoom (update camera zomm)
        float zoom = Input.GetAxis("Mouse ScrollWheel");

        if (Math.Abs(zoom) > 0.01f)
        {
            DispatchEvent(InputEventType.CHANGE_ZOOM, zoom);
            // (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= scroll * zoomSensibility;
        }

        // Handle camera aim (update camera view)
        float cameraHorizontal = Input.GetAxis("Camera X");
        float cameraVertical = Input.GetAxis("Camera Y");

        Vector3 cameraDirection = new Vector2(cameraHorizontal, cameraVertical).normalized;

        if (cameraDirection.magnitude > 0.1f)
        {
            if (IsMouseOnScreen())
            {
                DispatchEvent(InputEventType.CAMERA_VIEW_XY, cameraDirection);
            }
        }
    }

    /// <summary>
    /// Fire, deffend and others actions
    /// </summary>
    private void HandleActionEvents()
    {
        // Handle firing and charge events
        if (BetterInput.GetButtonDoubleDown("Fire1"))
        {
            DispatchEvent(InputEventType.FIRE1_CHARGING, 2);
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                DispatchEvent(InputEventType.FIRE1, 1);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            DispatchEvent(InputEventType.FIRE2, 1);
        }
    }

    /// <summary>
    /// UI Navigation and shortcuts
    /// </summary>
    private void HandleNavigationEvents()
    {
        if (Input.GetKeyDown("p"))
        {
            DispatchEvent(InputEventType.PICKUP_ITEM, 1);
        }

        if (Input.GetKeyDown("q"))
        {
            DispatchEvent(InputEventType.FLY_MODE_ON, 1);
        }

        if (Input.GetKeyDown("e"))
        {
            DispatchEvent(InputEventType.FLY_MODE_OFF, 0);
        }

        if (Input.GetKeyDown("1"))
        {
            DispatchEvent(InputEventType.SKILL_1, 1);
        }

        if (Input.GetKeyDown("2"))
        {
            DispatchEvent(InputEventType.SKILL_2, 2);
        }

        if (Input.GetKeyDown("3"))
        {
            DispatchEvent(InputEventType.SKILL_3, 3);
        }

        if (Input.GetKeyDown("4"))
        {
            DispatchEvent(InputEventType.SKILL_4, 4);
        }

        if (Input.GetKeyDown("5"))
        {
            DispatchEvent(InputEventType.SKILL_5, 5);
        }

        // Close invertory, chat or exit
        if (Input.GetKeyDown("escape"))
        {
            DispatchEvent(InputEventType.ESCAPE, 1);
        }

        // Toggle chat
        if (Input.GetKey(KeyCode.DoubleQuote) || Input.GetKey(KeyCode.Quote))
        {
            DispatchEvent(InputEventType.CHAT_FOCUS, "TOOGLE_CHAT");
        }

        if (Input.GetKeyDown("enter"))
        {
            // TODO: open chat, send message and close chat (toogle chat and send message)
        }
    }

    /// <summary>
    /// Check if mouse position is outside the current screen
    /// </summary>
    /// <returns></returns>
    private bool IsMouseOnScreen()
    {
        var view = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        return !(view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1);
    }
}
