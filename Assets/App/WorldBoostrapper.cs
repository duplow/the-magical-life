using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

// Our World loader
public class WorldBoostrapper : MonoBehaviour
{
    // Build and starts the world
    void _Start()
    {
        // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);

        // Create DI container
        // Register services and dependencies
        // Load user settings
        // Start server connection
        // Facade input control adapter
        // Load UI
        // Load map
        // Load player skin and data
        // Create mobs

        // Register DI into? GlobalDI.GetInstance(); to allows calls from anywhere

        var container = new DiContainer();
        container.Bind<AudioService>().AsSingle();
        container.Bind<LoggerService>().AsSingle();
        container.Bind<IAudioService>().To<AudioService>().FromResolve();
        container.Bind<ILoggerService>().To<LoggerService>().FromResolve();

        //container.Bind(typeof(IAudioService)).To(typeof(AudioService));
        //container.BindInterfacesAndSelfTo(typeof(AudioService));

        //var audioService = container.Instantiate<AudioService>();
        //var audioService = container.Instantiate<IAudioService>();
        var audioService = container.Resolve<IAudioService>();

        audioService.Play("Screeen 1");
        audioService.PlayIn3D("Screen 2", Vector3.forward);

        var prefab = Resources.Load("Prefabs/Magic_Bullet"); // Resolves to Assets/Resources/Prefabs/Magic_Bullet

        var prefabInstance = container.InstantiatePrefab(prefab);

        Debug.Log("Done!");

        //GameObject.Find("magic");
        //container.Bind<Foo>().FromNewComponentOnNewGameObject().WithGameObjectName("Foo1");
        //container.InstantiatePrefabResource("");

        /*
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
        // cube.AddComponent<MagicBulletScript>(); // Precisa ser um monobehavior
        cube.AddComponent<CharacterStatsMonoBehaviour>();
        cube.AddComponent<InputControllerMono>();
        //cube.GetComponent<MagicBulletScript>().collisionEffect = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // GameObject.Find("");
        */
    }

    GameObject LoadUI(GameObject player)
    {
        CharacterStatsMonoBehaviour stats;
        GameObject ui = new GameObject();

        player.TryGetComponent<CharacterStatsMonoBehaviour>(out stats);
        ui.AddComponent(stats.GetType());
        stats.HP = 100;
        stats.MaxHP = 200;
        stats.Player = ui;

        return ui;
    }

    void _LoadUI(Core.PlayableCharacter player)
    {
        // TODO: Code here
        player.GetHP();
        player.GetMaxHP();
    }

    void LoadMap()
    {
        // TODO: Code here
    }

    void LoadPlayerCharacter()
    {
        // TODO: Facade player skin and load player data
    }
}
