using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface PlayerAgent {
    void ExecuteCommand(InputEventType command, object data);
}

public class PlayerAgentMob : MonoBehaviour, PlayerAgent
{
    public void ExecuteCommand(InputEventType command, object data)
    {
        throw new System.NotImplementedException();
    }
}


// Remote player or server
public class PlayerAgentRemotePlayer : MonoBehaviour, PlayerAgent
{
    public void ExecuteCommand(InputEventType command, object data)
    {
        throw new System.NotImplementedException();
    }
}

public class PlayerAgentControllable : MonoBehaviour, PlayerAgent
{

    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public Camera Camera;

    [SerializeField]
    private Transform PlayerTransform;

    [SerializeField]
    private Camera PlayerCamera;

    [SerializeField]
    private MonoBehaviour PlayerCollider;

    [SerializeField]
    private MonoBehaviour PlayerBoxCollider;

    [SerializeField]
    private IMovementController PlayerMovementController;

    [SerializeField]
    private ICameraController PlayerCameraController;

    private ILoggerService loggerService;
    private IInputService inputService;

    [Inject]
    public void Construct(ILoggerService loggerService, IInputService inputService)
    {
        this.loggerService = loggerService;
        this.inputService = inputService;
    }

    void Start()
    {
        if (this.Player)
        {
            PlayerTransform = this.Player.GetComponent<Transform>();
            //var collider = this.Player.GetComponent<Collider>();
            //var boxCollider = this.Player.GetComponent<Collider>();

            PlayerCamera = this.Player.GetComponent<Camera>();
            PlayerMovementController = (IMovementController)this.Player.GetComponent(typeof(IMovementController));
            PlayerCameraController = (ICameraController)this.Player.GetComponent(typeof(ICameraController));

            if (PlayerCamera == null)
            {
                PlayerCamera = Camera.main;
            }
        }
    }

    void OnEnable()
    {
        if (this.inputService != null)
        {
            inputService.InputReceived += HandleInputEvents;
        }
    }

    void OnDisable()
    {
        if (this.inputService != null)
        {
            inputService.InputReceived -= HandleInputEvents;
        }
    }

    void HandleInputEvents(object sender, InputServiceEventArgs e)
    {
        ExecuteCommand(e.EventType, e.EventData);
    }

    public void ExecuteCommand(InputEventType command, object data)
    {
        try
        {
            // Rotate camera
            if (command == InputEventType.CAMERA_VIEW_XY)
            {
                //this.PlayerCameraController.Rotate((Vector2) data);
                if (PlayerCameraController != null) PlayerCameraController.LookAt(gameObject.transform);
            }

            // Change camera zoom
            if (command == InputEventType.CHANGE_ZOOM)
            {
                if (PlayerCameraController != null) PlayerCameraController.SetZoom(PlayerCameraController.GetZoom() + 0.1f);
            }

            // Move character
            if (command == InputEventType.MOVE_DIRECTION)
            {
                // TODO: Move camera together?
                if (PlayerMovementController != null) this.PlayerMovementController.Move((Vector3)data, 1f);
            }

            // Jump
            if (command == InputEventType.JUMP)
            {
                if (PlayerMovementController != null) this.PlayerMovementController.Jump();
            }

            this.loggerService.Info($"Evento recebido no player agent {command.ToString()}");
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            this.loggerService.Error($"Unexpected error while executing player commands:\n{ex.Message}");
            // throw new System.Exception($"Unexpected error while executing player commands:\n{ex.Message}");
        }
    }
}
