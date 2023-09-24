using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsModel
{
    /// <summary>
    /// Health points
    /// </summary>
    public uint HP;

    /// <summary>
    /// Health points recovery rate (Amount of HP the character recovers over time)
    /// </summary>
    public int RecoveryRateHP;

    /// <summary>
    /// Mana points
    /// </summary>
    public int MP;

    /// <summary>
    /// Mana points recovery rate (Amount of MP the character recovers over time)
    /// </summary>
    public int RecoveryRateMP;

    /// <summary>
    /// Strength points or Swordmanship points
    /// </summary>
    public int STR;

    /// <summary>
    /// Strength recovery rate (Amoutnt de STR the character recovers over time)
    /// </summary>
    public int RecoveryRateSTR;

    /// <summary>
    /// Stamina points
    /// </summary>
    public int SP;

    /// <summary>
    /// Stamina points recovery rate (Amount of SP the character recovers over time)
    /// </summary>
    public int RecoveryRateSP;

    /// <summary>
    /// Basic movements speed
    /// </summary>
    public int Speed;

    /// <summary>
    /// Strength usage rate (How much strength you are able to spend at a time)
    /// </summary>
    public float STR_UsageRate;

    /// <summary>
    /// Mana usage rate (How much mana you are able to spend at a time)
    /// </summary>
    public float MP_UsageRate;
}
