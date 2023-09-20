using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface ObjectStats
    {
        /// <summary>
        ///  If object is fixed at its localization
        /// </summary>
        /// <returns></returns>
        bool isStatic();

        string GetName();
        int GetX();
        int GetY();
        int GetZ();

        bool IsGrounded();
        bool IsFlying();


        int GetHP();
        int GetMaxHP();
        int GetMP();
        int GetMaxMP();
        int GetSP();
        int GetMaxSP();

        /// <summary>
        /// Raw power
        /// </summary>
        /// <returns></returns>
        int GetMaxAttack();

        /// <summary>
        /// Magic power (GetMaxMagicPower) (GetMaxManaPower)
        /// </summary>
        /// <returns></returns>
        int GetMaxMagicalAttack();

        int MaxDefense();

        int MaxMagicalDefense();
    }
}
