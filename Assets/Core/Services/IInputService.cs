using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputEventType {
    MOVE_AXIS_X, // Move character and navigate UI X-Axis
    MOVE_AXIS_Y, // Move character and navigate UI Y-Axis
    MOVE_AXIS_Z, // Move character in Z-Axis (Only when FLY_MODE_ON)
    MOVE_DIRECTION, // Move character in XY and maybe Z axis
    VIEW_AXIS_X, // Camera X-Axis
    VIEW_AXIS_Y, // Camera Y-Axis
    CAMERA_VIEW_XY,
    SPEED_MODIFIER_SLOW, // Movement speed modifier = SLOW
    SPEED_MODIFIER_NORMAL,
    SPEED_MODIFIER_FAST, // Movement speed modifier = FAST
    FIRE1,
    FIRE1_CHARGING,
    FIRE2,
    JUMP,
    FLY_MODE_ON, // Enable character fly mode
    FLY_MODE_OFF, // Disable character fly mode
    PICKUP_ITEM,
    CHANGE_CAMERA_TYPE,
    CHANGE_ZOOM,
    CHAT_ON,
    CHAT_OFF,
    CHAT_FOCUS, // UI Focus on Chat bar
    SKILL_1, // Skill #1 shortcut
    SKILL_2, // Skill #2 shortcut
    SKILL_3, // Skill #3 shortcut
    SKILL_4, // Skill #4 shortcut
    SKILL_5, // Skill #5 shortcut
    SKILLBAR_FOCUS, // UI Focus on Skill bar
    ESCAPE, // Closes or reset focus UI
    CANCEL, // Same as ESCAPE
}

public class InputServiceEventArgs : EventArgs {
    public InputEventType EventType;
    public object EventData;
    // public readonly float EventForce;
}

public interface IInputService
{
    // void HandleInput(InputEventType eventType, float eventForce = 1f);
    // event EventHandler<InputServiceEventArgs> OnInputReceived;
    // delegate void OnEventEmitted(InputEventType eventType, object eventData);
    // event OnEventEmittedHandler OnEventEmitted;
    //delegate void OnInputReceivedHandler(InputEventType eventType, object data);
    //event OnInputReceivedHandler OnInputReceived;

    //event EventHandler<InputServiceEventArgs> OnInputReceived;
    event EventHandler<InputServiceEventArgs> InputReceived;

    void GetEvents();
}
