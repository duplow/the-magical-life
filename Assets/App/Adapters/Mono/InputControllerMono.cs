using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputControllerMono : MonoBehaviour
{
    // public CharacterController controller;
    // public Transform cam;

    private IAudioService audioService;
    private IInputService inputService; // TODO: Rename to IInputDectectorService?

    [Inject]
    public void Construct(IAudioService audioService, IInputService inputService)
    {
        this.audioService = audioService;
        this.inputService = inputService;
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
