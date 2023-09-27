using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : IAudioService
{
    private ILoggerService LoggerService;

    public AudioService(ILoggerService loggerService)
    {
        this.LoggerService = loggerService;
    }

    public void Play(string trackName, int duration = -1)
    {
        LoggerService.Debug($"Playing 2D audio track [{trackName}]");
    }

    public void PlayIn3D(string trackName, Vector3 sourcePosition, int duration = -1)
    {
        LoggerService.Debug($"Playing 3D audio track [{trackName}]");
    }
}
