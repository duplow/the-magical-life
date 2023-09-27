using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisibleOnTexture : MonoBehaviour
{
    [SerializeField]
    public Material Percentage100;

    [SerializeField]
    public Material Percentage80;

    [SerializeField]
    public Material Percentage50;

    [SerializeField]
    public Material Percentage30;

    [SerializeField]
    public Material Percentage15;

    [SerializeField]
    public GameObject TargetGameObject;

    // When receive damage from BroadcastMessage or SendMessage
    void OnDamageReceived(float damageTotal = 0f)
    {
        UpdateMaterial();
    }

    // When auto healed (TODO: Change event to OnHPChanged)
    void OnAutoHealed(string statName)
    {
        Debug.Log($"OnAutoHealed called {statName}");
        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        // TODO: Calculate health percentage
        // TODO: Replace GameObject material with correspondent damageCounter
        float healthyPercentage = 0f;

        if (GetComponent<IStatsController>() != null)
        {
            if (GetComponent<IStatsController>().MaxHP > 0)
            {
                healthyPercentage = GetComponent<IStatsController>().HP / GetComponent<IStatsController>().MaxHP;
            }
        }


        var mat = this.Percentage100;

        if (healthyPercentage <= 0.8) mat = this.Percentage80;
        if (healthyPercentage <= 0.5) mat = this.Percentage50;
        if (healthyPercentage <= 0.3) mat = this.Percentage30;
        if (healthyPercentage <= 0.15) mat = this.Percentage15;

        this.TargetGameObject.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(mat);
    }
}
