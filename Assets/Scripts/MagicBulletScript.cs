using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBulletScript : MonoBehaviour
{
    //public VisualEffect collisionEffect;
    public GameObject collisionEffect;
    public float timeToLive = 10f;
    public float collisionEffectDuration = 0.5f;
    public MeshRenderer renderer;
    
    float startTime;
    bool collided = false;
    bool isDestroyed = false;
    GameObject collisionObject;

    void Awake()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // TODO: Check elapsed time
        // TODO: Check is destroyed and call Destroy(gameObject);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision hit)
    {
        collided = true;
        collisionObject = Instantiate(collisionEffect, hit.contacts[0].point, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        //renderer.SetActive(false);
        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(collisionEffectDuration);
        Destroy(collisionObject);
        isDestroyed = true;
        
    }
}
