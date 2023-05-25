using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Recovery : MonoBehaviour
{
    public bool isRecovering = false;
    public Material recoveryMaterial;

    public float health = 80f;
    public float maxHealth = 100f;
    public float recoveryRate = 0.1f;
    public string recoveryMaterialEnableProperty = "Vector_1";

    public VisualEffect recovery;

    GameObject mat;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Set initial status
        if (recovery != null)
        {
            recovery.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            // TODO: Activate recovery
            // recoveryMaterial.SetFloat(recoveryMaterialEnableProperty, 1f);
            
            isRecovering = true;

            if (recovery != null) {
                recovery.Play();
            }

            StartCoroutine(ResetBool(4f));
        }

        DealRecovery();
    }

    void DealRecovery()
    {
        
    }

    IEnumerator ResetBool (float delay = 0.1f)
    {
        yield return new WaitForSeconds(delay);
        isRecovering = !isRecovering;

        if (recovery != null)
        {
            recovery.Stop();
        }
    }
}
