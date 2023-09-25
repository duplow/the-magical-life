using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputControllerMono : MonoBehaviour
{
    // public CharacterController controller;
    // public Transform cam;

    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public UnityEngine.Camera Camera;

    [SerializeField]
    private Transform PlayerTransform;

    [SerializeField]
    private Camera PlayerCamera;

    [SerializeField]
    private MonoBehaviour PlayerCollider;

    [SerializeField]
    private MonoBehaviour PlayerBoxCollider;

    private IAudioService audioService;
    private IInputService inputService; // TODO: Rename to IInputDectectorService?
    private ILoggerService loggerService;

    [Inject]
    public void Construct(IAudioService audioService, IInputService inputService, ILoggerService loggerService)
    {
        this.audioService = audioService;
        this.inputService = inputService;
        this.loggerService = loggerService;
    }

    void Start()
    {
        if (this.Player)
        {
            PlayerTransform = this.Player.GetComponent<Transform>();
            //var collider = this.Player.GetComponent<Collider>();
            //var boxCollider = this.Player.GetComponent<Collider>();

            UnityEngine.Camera cameraComp = null;

            if (!this.Player.TryGetComponent<Camera>(out cameraComp))
            {
                cameraComp = UnityEngine.Camera.main;
            }

            this.PlayerCamera = cameraComp;
        }
    }

    // Add event handlers
    void OnEnable()
    {
        this.loggerService.Info("On enable");
    }

    // Remove event handlers
    void OnDisable()
    {
        this.loggerService.Info("On disable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            this.audioService.Play("RIP");
        }

        if (null != inputService)
        {
            this.inputService.GetEvents();
        }
    }
}
