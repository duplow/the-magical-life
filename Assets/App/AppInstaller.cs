using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("APP INSTALLER >>>");
        //Container.Bind<string>().FromInstance("Hello world");
        //Container.Bind<Greeter>().AsSingle().NonLazy();

        // Older style
        //Container.Bind<IAudioService>().To<AudioService>().AsSingle().IfNotBound();
        //Container.Bind<ILoggerService>().To<LoggerService>().AsSingle().IfNotBound();

        Container.Bind<AudioService>().AsSingle();
        Container.Bind<LoggerService>().AsSingle();
        Container.Bind<MouseKeyboardInputService>().AsSingle();
        Container.Bind<IAudioService>().To<AudioService>().FromResolve();
        Container.Bind<ILoggerService>().To<LoggerService>().FromResolve();
        Container.Bind<IInputService>().To<MouseKeyboardInputService>().FromResolve();
    }
}
