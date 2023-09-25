using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour, ICameraController
{
    [SerializeField]
    public Camera camera;

    [SerializeField]
    public Transform lookAt;

    [SerializeField]
    public float defaultZoomLevel = 1f;

    [SerializeField]
    public float minZoomLevel = 0.1f;

    [SerializeField]
    public float maxZoomLevel = 3f;

    [SerializeField]
    public float cameraDistance = 5f;

    [SerializeField]
    private float _zoomLevel;

    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    private GameObject _dynamicRootGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null) camera = gameObject.GetComponent<Camera>();
        if (camera == null) camera = Camera.main;

        SetupVirtualCamera();
    }

    void SetupVirtualCamera()
    {
        camera.gameObject.AddComponent<CinemachineBrain>();
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
        bodyComp.CameraDistance = cameraDistance;

        // Aim
        _virtualCamera.AddCinemachineComponent<CinemachinePOV>();
        var aimComp = (CinemachinePOV)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        aimComp.m_RecenterTarget = CinemachinePOV.RecenterTargetMode.LookAtTargetForward;
        aimComp.m_HorizontalRecentering.m_enabled = true;
        aimComp.m_VerticalRecentering.m_enabled = true;
    }

    void TeardownVirtualCamera()
    {
        Destroy(_dynamicRootGameObject);
        Destroy(camera.gameObject.GetComponent<CinemachineBrain>());
    }

    void Vibrate()
    {
        _virtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        var noiseComponent = (CinemachineBasicMultiChannelPerlin)_virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Noise);
        noiseComponent.m_NoiseProfile = ScriptableObject.CreateInstance<NoiseSettings>();
        noiseComponent.m_NoiseProfile.name = "6D Wobble";
        noiseComponent.ReSeed();
    }

    void OnDisable()
    {
        try
        {
            TeardownVirtualCamera();
        }
        catch (System.Exception)
        {
            // Ignore
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: If too long without moving then reset look at certain rate
    }

    public Vector2 GetRotation()
    {
        return new Vector2(camera.transform.rotation.x, camera.transform.rotation.y);
    }

    public float GetZoom()
    {
        return _zoomLevel;
    }

    public void SetZoom(float zoom)
    {
        _zoomLevel = zoom;
        //componentBase.CameraDistance = cameraDistance; // 1 + (cameraDistance * _zoomLevel)
    }

    public void SetZoomRelative(float zoom)
    {
        _zoomLevel += zoom;
    }

    public void LookAt(Transform obj)
    {
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
        throw new System.NotImplementedException();
    }
}
