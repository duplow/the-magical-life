using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCaster : MonoBehaviour
{
    public Camera cam;
    public GameObject magic;
    public Transform originPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
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
    }
}
