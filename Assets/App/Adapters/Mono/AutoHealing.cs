using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IStatsController))]
public class AutoHealing : MonoBehaviour
{
    [SerializeField]
    protected float healthTimer = 0;

    [SerializeField]
    protected float manaTimer = 0;

    [SerializeField]
    protected float staminaTimer = 0;

    [SerializeField]
    protected float interval = 3f;

    // Update is called once per frame
    void Update()
    {
        var statsController = GetComponent<IStatsController>();

        if (statsController == null) return;

        if (!statsController.isAlive) return;

        healthTimer += Time.deltaTime;
        manaTimer += Time.deltaTime;
        staminaTimer += Time.deltaTime;

        if (healthTimer >= interval && statsController.HP < statsController.MaxHP) ThrowBuff("HP");
        if (manaTimer >= interval && statsController.MP < statsController.MaxMP) ThrowBuff("MP");
        if (staminaTimer >= interval && statsController.SP < statsController.MaxSP) ThrowBuff("SP");
    }

    // Dispatch buff
    void ThrowBuff(string name)
    {

        var statsController = GetComponent<IStatsController>();

        if (statsController == null) return;

        // Update stats in stats controller
        if (name == "HP") statsController.HP += statsController.MaxHP * statsController.HP_RecoveryRate;
        if (name == "MP") statsController.MP += statsController.MaxMP * statsController.MP_RecoveryRate;
        if (name == "SP") statsController.SP += statsController.MaxSP * statsController.SP_RecoveryRate;

        ResetTimer(name);

        // TODO: Dispatch healing skill with target self and uncancelable
        // TODO: Run buff effect
    }

    void ResetTimer(string name)
    {
        if (name == "HP") healthTimer = 0;
        if (name == "MP") manaTimer = 0;
        if (name == "SP") staminaTimer = 0;
    }
}
