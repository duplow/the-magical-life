using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyboardInputService : IInputService
{
    //public event EventHandler<InputServiceEventArgs> OnInputReceived;
    //public delegate void OnInputReceivedHandler(InputEventType eventType, object data);
    //public event OnInputReceivedHandler OnInputReceived;

    private float lastUpPressed = 0f;
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
        this.logger.Info($"Input event dispatched from Input service [{eventType.ToString()}]: {data.ToString()}");

        var args = new InputServiceEventArgs { EventType = eventType, EventData = data };
        OnInputReceived(args);
    }

    public void GetEvents()
    {
        this.HandleKeyboardEvents();
        this.HandleMouseEvents();
    }

    private void HandleKeyboardEvents()
    {
        if (Input.GetKeyUp("w"))
        {
            // TODO: Store key up time for double press checking
        }

        // TODO: If double [space] = enable flying mode

        // Double press for enable hyper speed
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

        if (Input.GetKeyDown("i"))
        {
            DispatchEvent(InputEventType.PICKUP_ITEM, 1);
        }

        if (Input.GetKeyUp("left shift"))
        {
            DispatchEvent(InputEventType.SPEED_MODIFIER_SLOW, 1);
        }

        if (Input.GetKeyDown("left shift"))
        {
            DispatchEvent(InputEventType.SPEED_MODIFIER_FAST, 2);
        }

        if (Input.GetKeyUp("space"))
        {
            DispatchEvent(InputEventType.JUMP, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            DispatchEvent(InputEventType.JUMP, 1);
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

        if (Input.GetKeyDown("escape"))
        {
            DispatchEvent(InputEventType.ESCAPE, 1);
            // Application.Quit();
        }

        if (Input.GetKeyDown("enter"))
        {
            // TODO: open chat, send message and close chat (toogle chat and send message)
        }

        /*
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, yAxis, 0f).normalized;

        if (direction.magnitude > 0.1f)
        {
            DispatchEvent(InputEventType.MOVE_DIRECTION, direction);
        }
        */
    }

    private void HandleMouseEvents()
    {
        // Handle camera zoom (update camera zomm)
        float zoom = Input.GetAxis("Mouse ScrollWheel");

        if (Math.Abs(zoom) > 0.01f) {
            DispatchEvent(InputEventType.CHANGE_ZOOM, zoom);
            // (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= scroll * zoomSensibility;
        }

        // Handle camera aim (update camera view)
        float aimHorizontal = Input.GetAxis("Mouse X");
        float aimVertical = Input.GetAxis("Mouse Y");
        Vector3 cameraAim = new Vector3(aimHorizontal, 0f, aimVertical).normalized;

        if (cameraAim.magnitude > 0.1f)
        {
            DispatchEvent(InputEventType.CAMERA_VIEW_XY, cameraAim);
        }

        // Handle firing and charge events
        ChargingInput("Fire1", InputEventType.FIRE1, InputEventType.FIRE1_CHARGING);

        if (Input.GetButtonDown("Fire2"))
        {
            DispatchEvent(InputEventType.FIRE2, 1);
        }
    }

    private void ChargingInput(string key, InputEventType startType, InputEventType chargingType)
    {
        if (Input.GetButtonDown(key)) {
            DispatchEvent(startType, 1);
            return;
        }

        if (Input.GetButton(key)) {
            DispatchEvent(chargingType, 2);
            return;
        }
    }
}
