using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraController
{
    float GetZoomLevel();

    void SetZoomLevel(float zoom);

    Vector2 GetRotation();

    void Rotate(Vector2 rotation);

    void LookAt(Transform obj);
}
