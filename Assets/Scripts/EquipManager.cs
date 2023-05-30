using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject point;
    public GameObject equipament;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            //var spawned = new GameObject(equipament.name);
            var spawned = Instantiate(equipament, new Vector3(0, 0, 0), Quaternion.identity);
            //point.AddChild();
            spawned.transform.parent = point.transform;
            spawned.transform.localPosition = equipament.transform.localPosition;
            spawned.transform.localRotation = equipament.transform.localRotation;
            spawned.transform.localScale = equipament.transform.localScale;
        }
    }
}
