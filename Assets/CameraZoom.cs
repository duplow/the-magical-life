using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
    public float sensibility = 1f;
    float cameraDistance = 0f;

    // Update is called once per frame
    void Update()
    {
        if (componentBase == null) {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                Debug.Log("Is 3rd person!");
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= scroll * sensibility;
            }
        }
    }
}
