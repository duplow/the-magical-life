using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationService
{
    void Play(string animation);
}

public class CharacterController1 : UseCase<InputEventType, object>
{
    private IAudioService audioService;
    private ILoggerService loggerService;
    private IAnimationService animationService;

    public CharacterController1(ILoggerService loggerService, IAudioService audioService, IAnimationService animationService)
    {
        this.loggerService = loggerService;
        this.audioService = audioService;
        this.animationService = animationService;
    }

    public object Execute(InputEventType payload)
    {
        this.loggerService.Debug("Executing CharacterController...");

        // Make debouncer?

        if (payload == InputEventType.MOVE_AXIS_X)
        {
            // Move character position and handle animations
        }

        if (payload == InputEventType.MOVE_AXIS_Y)
        {
            // Move character position and handle animations
        }

        if (payload == InputEventType.FIRE1)
        {
            // Move character position and handle animations
            this.audioService.Play("Fire");
            this.animationService.Play("Fire");
        }

        if (payload == InputEventType.FIRE2)
        {
            // Move character position and handle animations
            this.audioService.Play("Fire");
            this.animationService.Play("Fire");
        }

        if (payload == InputEventType.CHANGE_ZOOM)
        {
            // Change zoom
        }

        return null;
    }
}
