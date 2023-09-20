using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface ObjectStats
    {
        // bool IsGrounded();
        // bool IsFlying();
        // int GetX();
        // int GetY();
        // int GetZ();


        /// <summary>
        ///  If object is fixed at its localization
        /// </summary>
        /// <returns></returns>
        bool isStatic();

        /// <summary>
        /// Object name
        /// </summary>
        /// <returns></returns>
        string GetName();
 

        /// <summary>
        /// Current health points available
        /// </summary>
        /// <returns></returns>
        float GetHP();

        /// <summary>
        /// Total health
        /// </summary>
        /// <returns></returns>
        float GetMaxHP();

        /// <summary>
        /// Total mana points available
        /// </summary>
        /// <returns></returns>
        float GetMP();

        /// <summary>
        /// Total mana
        /// </summary>
        /// <returns></returns>
        float GetMaxMP();

        /// <summary>
        /// Current stamina available
        /// </summary>
        /// <returns></returns>
        float GetSP();

        /// <summary>
        /// Total stamina
        /// </summary>
        /// <returns></returns>
        float GetMaxSP();

        /// <summary>
        /// Current speed available
        /// </summary>
        /// <returns></returns>
        float GetSpeed();

        /// <summary>
        /// Total speed
        /// </summary>
        /// <returns></returns>
        float GetMaxSpeed();
    }
}
