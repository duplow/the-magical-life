using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBuilder : MonoBehaviour
{
    // Build and starts the world
    void Start()
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

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
        cube.AddComponent<MagicBulletScript>(); // Precisa ser um monobehavior
        //cube.GetComponent<MagicBulletScript>().collisionEffect = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    void LoadUI(Core.PlayableCharacter player)
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
        // TODO: Code here
    }
}
