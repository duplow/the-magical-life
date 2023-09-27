using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour, ICameraController
{
    [SerializeField]
    public Camera targetCamera;

    [SerializeField]
    public Transform lookAt;

    [SerializeField]
    public float cameraDistance = 5f;

    [SerializeField]
    public float defaultZoomLevel = 1f;

    [SerializeField]
    public float minZoomLevel = 0.5f;

    [SerializeField]
    public float maxZoomLevel = 3f;

    [SerializeField]
    private float zoomLevel = 1f;

    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    private GameObject _dynamicRootGameObject;

    private bool hasCinemachinePreviousConfig = false;
    private bool wasCinemachineSettedUp = false;
    private bool wasCinemachineDestroyed = false;
    private bool isDirty = false;

    #region Setup and Teardown
    void SaveCinemachinePreviousConfig()
    {
        var previousConfig = targetCamera.gameObject.GetComponent<CinemachineBrain>();

        if (previousConfig == null)
        {
            hasCinemachinePreviousConfig = false;
        }

        // TODO: Save cinemachine configs for restore during tear down
        hasCinemachinePreviousConfig = true;
    }

    void RestoreCinemachinePreviousConfig()
    {
        if (!hasCinemachinePreviousConfig) {
            Destroy(targetCamera.gameObject.GetComponent<CinemachineBrain>());
            return;
        }

        // TODO: Restore cinemachine configs
    }

    void ResolveCamera()
    {
        if (targetCamera == null) targetCamera = gameObject.GetComponent<Camera>();
        if (targetCamera == null) targetCamera = Camera.main;
    }

    bool IsReady()
    {
        return wasCinemachineSettedUp && !wasCinemachineDestroyed && targetCamera != null;
    }

    void ReadyOrFail()
    {
        if (!IsReady()) throw new System.Exception("Player camera controller component is not ready yet");
    }

    void SetupVirtualCamera()
    {
        wasCinemachineDestroyed = false;

        ResolveCamera();
        SaveCinemachinePreviousConfig();

        if (targetCamera.gameObject.GetComponent<CinemachineBrain>() == null) targetCamera.gameObject.AddComponent<CinemachineBrain>();
        _dynamicRootGameObject = new GameObject("DynamicPlayerCamera");
        _virtualCamera = _dynamicRootGameObject.AddComponent<CinemachineVirtualCamera>();

        if (lookAt != null)
        {
            _virtualCamera.Follow = lookAt;
            _virtualCamera.LookAt = lookAt;
        }

        // Body
        _virtualCamera.AddCinemachineComponent<Cinemachine3rdPersonFollow>();
        var bodyComp = (Cinemachine3rdPersonFollow)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        bodyComp.CameraDistance = cameraDistance + (cameraDistance - (cameraDistance * zoomLevel));

        // Aim
        _virtualCamera.AddCinemachineComponent<CinemachinePOV>();
        var aimComp = (CinemachinePOV)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        aimComp.m_RecenterTarget = CinemachinePOV.RecenterTargetMode.LookAtTargetForward;
        aimComp.m_HorizontalRecentering.m_enabled = true;
        aimComp.m_VerticalRecentering.m_enabled = true;

        wasCinemachineSettedUp = true;
    }

    void TeardownVirtualCamera()
    {
        wasCinemachineDestroyed = true;

        Destroy(_dynamicRootGameObject);
        RestoreCinemachinePreviousConfig();

        wasCinemachineSettedUp = false;
    }

    void OnEnable()
    {
        try
        {
            SetupVirtualCamera();
        }
        catch (System.Exception ex)
        {
            Debug.LogException(new System.Exception($"An unexpected exception occurred while setting up the virtual camera", ex));
        }
    }

    void OnDisable()
    {
        try
        {
            TeardownVirtualCamera();
        }
        catch (System.Exception ex)
        {
            Debug.LogException(new System.Exception($"An unexpected exception occurred while tearing down up the virtual camera", ex));
        }
    }

    #endregion

    #region Apply changes
    void Update()
    {
        if (!IsReady()) return;

        ApplyPendingChanges();
        ResetLookAtIfTooLongSinceLastInteraction();
    }

    // Applies pending settings changes
    void ApplyPendingChanges()
    {
        if (!isDirty) return;

        // Apply zoom
        var bodyComp = (Cinemachine3rdPersonFollow)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        bodyComp.CameraDistance = cameraDistance + (cameraDistance - (cameraDistance * zoomLevel));

        isDirty = false;
    }

    void ResetLookAtIfTooLongSinceLastInteraction()
    {
        // TODO: If too long without moving then reset look at certain rate
    }
    #endregion

    #region Public methods
    void Vibrate()
    {
        _virtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        var noiseComponent = (CinemachineBasicMultiChannelPerlin)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Noise);
        noiseComponent.m_NoiseProfile = ScriptableObject.CreateInstance<NoiseSettings>();
        noiseComponent.m_NoiseProfile.name = "6D Wobble";
        noiseComponent.ReSeed();
    }

    public Vector2 GetRotation()
    {
        Transform cameraTransform;

        if (targetCamera != null)
        {
            cameraTransform = targetCamera.transform;
        }
        else
        {
            cameraTransform = gameObject.transform;
        }

        return new Vector2(cameraTransform.rotation.x, cameraTransform.rotation.y);
    }

    public float GetZoomLevel()
    {
        return zoomLevel;
    }

    public void SetZoomLevel(float zoom)
    {
        if (zoom > maxZoomLevel) zoom = maxZoomLevel;
        if (zoom < minZoomLevel) zoom = minZoomLevel;
        zoomLevel = zoom;
        isDirty = true;
    }

    public void LookAt(Transform obj)
    {
        // ReadyOrFail();

        /*
        throw new System.NotImplementedException();

        Debug.Log(direction);
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed * Time.deltaTime;
        */
    }

    public void Rotate(Vector2 rotation)
    {
        ReadyOrFail();
        throw new System.NotImplementedException();
    }

    #endregion
}
