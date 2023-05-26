using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    public float delay = 0.5f;
    float startTime;

    void Awake()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsed = Time.time - startTime;

        if (elapsed >= delay)
        {
            Destroy(gameObject);
        }
    }
}
