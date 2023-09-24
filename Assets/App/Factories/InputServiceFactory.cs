using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputServiceFactory : IFactory<IInputService>
{
    public IInputService Create()
    {
        // Keyboard
        // Gamepad
        // Joystick
        // Mocked commands
        
        // throw new System.NotImplementedException();

        return new MouseKeyboardInputService(new LoggerService());
    }
}
