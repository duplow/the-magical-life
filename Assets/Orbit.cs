using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Move(new Vector3(0.5f, 0f, 0.5) * Time.deltaTime);
        transform.position += (Vector3.forward + Vector3.left) * 0.5f * Time.deltaTime;
    }
}
