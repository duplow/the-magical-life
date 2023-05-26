using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float sensibility = 1f;

    [SerializeField]
    public float zoomSensibility = 1f;

    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    CinemachineComponentBase componentBase;
    float cameraDistance = 0f;

    CinemachineComponentBase GetCinemachineComponentBase()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        return componentBase;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= scroll * zoomSensibility;
            }
        }
    }

    void HandleAim()
    {
        float h = sensibility * Input.GetAxis("Mouse X");
        float v = sensibility * Input.GetAxis("Mouse Y");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.normalized.magnitude > 0)
        {
            // TODO: Rotate camera to look at direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetCinemachineComponentBase();
        HandleZoom();
        HandleAim();
    }
}
