using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraController
{
    float GetZoom();

    Vector2 GetRotation();

    void SetZoom(float zoom);

    void Rotate(Vector2 rotation);

    void LookAt(Transform obj);
}
