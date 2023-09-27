using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface CharacterStats : ObjectStats
    {

        /// <summary>
        /// Health recovery rate
        /// </summary>
        /// <returns></returns>
        float GetHP_RecoveryRate();

        /// <summary>
        /// Mana recovery rate
        /// </summary>
        /// <returns></returns>
        float GetMP_RecoveryRate();

        /// <summary>
        /// Strength usage rate (How much strength you are able to spend at a time)
        /// </summary>
        /// <returns></returns>
        float GetSTR_UsageRate();

        /// <summary>
        /// Mana usage rate (How much mana you are able to spend at a time)
        /// </summary>
        /// <returns></returns>
        float GetMP_UsageRate();

        //float GetATK();
        //float GetMagicalATK();

        //float GetMaxATK_UsageRate();
        //float GetMaxMATK_UsageRate();

        /// <summary>
        /// Raw power
        /// </summary>
        /// <returns></returns>
        //int GetMaxAttack();

        /// <summary>
        /// Magic power (GetMaxMagicPower) (GetMaxManaPower)
        /// </summary>
        /// <returns></returns>
        //int GetMaxMagicalAttack();
        //int MaxDefense();
        //int MaxMagicalDefense();
    }
}
