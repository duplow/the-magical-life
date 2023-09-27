using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<string>().FromInstance("Hello world");
        //Container.Bind<Greeter>().AsSingle().NonLazy();
        //Container.Bind<ILoggerService>().To<LoggerService>().AsSingle();
        //Container.Bind<IInputService>().FromFactory<InputServiceFactory>();
    }
}
