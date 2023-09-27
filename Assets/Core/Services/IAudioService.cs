using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioService
{
    void Play(string trackName, int duration = -1);

    void PlayIn3D(string trackName, Vector3 sourcePosition, int duration = -1);
}
