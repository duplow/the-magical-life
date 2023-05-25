using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCaster : MonoBehaviour
{
    public Camera cam;
    public GameObject magic;

    public Transform magicCirclePoint;
    public Transform magicSpawnPoint;
    public GameObject magicCircleObject;
    public GameObject magicSpellObject;

    public float castingDuration = 1f;
    public float maxDistance = 200f;
    public float speed = 30f;
    public bool debuging = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //ShootProjectile();
            StartCasting();
        }
    }

    void LogPosition(string text, Vector3 position)
    {
        if (debuging)
            Debug.Log(text + " position: " + $"{position.x}, {position.y}, {position.z}");
    }

    void StartCasting()
    {
        //RaycastHit hit;
        Vector3 targetPoint;
        Vector3 sourcePoint = magicSpawnPoint.position;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        targetPoint = ray.GetPoint(maxDistance);

        LogPosition("Camera position", cam.transform.position);
        LogPosition("Source position", sourcePoint);
        LogPosition("Target position", targetPoint);

        /*
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance))
        {
            targetPoint = hit.point;
            Debug.DrawRay(cam.transform.position, hit.point, Color.blue, 600f);
        }
        else
        {
            Debug.Log("Fallback");
            targetPoint = ray.GetPoint(maxDistance);
        }
        */

        if (debuging)
        {
            Debug.DrawRay(sourcePoint, targetPoint, Color.red, 600f);
            Debug.DrawLine(sourcePoint, targetPoint, Color.yellow, 600f);
        }

        var sourceObject = Instantiate(magicSpellObject, sourcePoint, Quaternion.identity) as GameObject;
        //var targetObject = Instantiate(magicSpellObject, targetPoint, Quaternion.identity) as GameObject;

        //sourceObject.transform.rotation = Quaternion.FromToRotation(sourcePoint, targetPoint);
        //sourceObject.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        sourceObject.GetComponent<Rigidbody>().velocity = (sourcePoint + targetPoint) * speed;
    }

    void ShootProjectile()
    {
        /*
        //new Vector3(0.5f, 0.5f, 0)
        Ray ray = cam.ViewportPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 destination;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        var projectileObj = Instantiate(magic, originPoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - originPoint.position).normalized * speed;
        */
    }
}
