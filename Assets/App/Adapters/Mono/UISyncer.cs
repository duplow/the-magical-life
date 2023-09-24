using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UISyncer : MonoBehaviour
{

    private ILoggerService loggerService;
    private IInputService inputService;

    [Inject]
    public void Construct(ILoggerService loggerService, IInputService inputService)
    {
        this.loggerService = loggerService;
        this.inputService = inputService;
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
        this.loggerService.Info($"Novo evento recebido do InputService {e.EventType.ToString()}");
    }
}
