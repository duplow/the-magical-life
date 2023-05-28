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

    [SerializeField]
    private Vector3 targetPoint;

    [SerializeField]
    private Vector3 sourcePoint;

    [SerializeField]
    private RaycastHit hitPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCasting();
        }
    }

    void StartCasting()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        sourcePoint = magicSpawnPoint.position;
        targetPoint = ray.GetPoint(maxDistance);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitPoint, maxDistance))
        {
            targetPoint = hitPoint.point;
            Debug.DrawRay(cam.transform.position, hitPoint.point, Color.blue, maxDistance);
        }

        var sourceObject = Instantiate(magicSpellObject, sourcePoint, Quaternion.identity) as GameObject;

        //var targetObject = Instantiate(magicSpellObject, targetPoint, Quaternion.identity) as GameObject;
        //sourceObject.transform.rotation = Quaternion.FromToRotation(sourcePoint, targetPoint);
        //sourceObject.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;

        Rigidbody sourceObjectRigidbodyComponent;

        var direction = (targetPoint - sourcePoint).normalized;

        //Debug.DrawRay(sourcePoint, direction, Color.red, maxDistance);
        Debug.DrawLine(sourcePoint, targetPoint, Color.yellow, maxDistance);

        if (sourceObject.TryGetComponent<Rigidbody>(out sourceObjectRigidbodyComponent))
        {
            //sourceObjectRigidbodyComponent.velocity = (sourcePoint + targetPoint) * speed;
            //sourceObjectRigidbodyComponent.AddForce(targetPoint * maxDistance);
            sourceObjectRigidbodyComponent.transform.LookAt(targetPoint);
            sourceObjectRigidbodyComponent.AddForce(direction * speed * maxDistance);
        }
    }
}
