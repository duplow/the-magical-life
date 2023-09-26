using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatsController
{
    /// <summary>
    ///  If object is fixed at its localization
    /// </summary>
    /// <returns></returns>
    bool isStatic { get; }

    /// <summary>
    /// Tells if character is alive or dead
    /// </summary>
    bool isAlive { get; }

    /// <summary>
    /// Object name
    /// </summary>
    /// <returns></returns>
    string Name { get; }

    /// <summary>
    /// Current health points available
    /// </summary>
    /// <returns></returns>
    float HP { get; set; }

    /// <summary>
    /// Total health
    /// </summary>
    /// <returns></returns>
    float MaxHP { get; set; }

    /// <summary>
    /// Total mana points available
    /// </summary>
    /// <returns></returns>
    float MP { get; set; }

    /// <summary>
    /// Total mana
    /// </summary>
    /// <returns></returns>
    float MaxMP { get; set; }

    /// <summary>
    /// Current stamina available
    /// </summary>
    /// <returns></returns>
    float SP { get; set; }

    /// <summary>
    /// Total stamina
    /// </summary>
    /// <returns></returns>
    float MaxSP { get; set; }

    /// <summary>
    /// Current speed available
    /// </summary>
    /// <returns></returns>
    float Speed { get; set; }

    /// <summary>
    /// Total speed
    /// </summary>
    /// <returns></returns>
    float MaxSpeed { get; set; }


    /// <summary>
    /// Health recovery rate
    /// </summary>
    /// <returns></returns>
    float HP_RecoveryRate { get; set; }

    /// <summary>
    /// Mana recovery rate
    /// </summary>
    /// <returns></returns>
    float MP_RecoveryRate { get; set; }

    /// <summary>
    /// Stamina recovery rate
    /// </summary>
    /// <returns></returns>
    float SP_RecoveryRate { get; set; }

    /// <summary>
    /// Strength usage rate (How much strength you are able to spend at a time)
    /// </summary>
    /// <returns></returns>
    float SP_UsageRate { get; set; }

    /// <summary>
    /// Mana usage rate (How much mana you are able to spend at a time)
    /// </summary>
    /// <returns></returns>
    float MP_UsageRate { get; set; }


    // TODO: Create a Buff script for this
    List<BuffModel> Buffs { get; }

    List<BuffModel> Debuffs { get; }

    void LoadStats();

    void RestoreStats();

    void ResetStats();
}

public class StatsController : MonoBehaviour, IStatsController
{
    #region Common stats
    [SerializeField]
    public bool isStatic { get => GetIsStatic(); }

    [SerializeField]
    public bool isAlive { get => GetIsAlive(); }

    [SerializeField]
    public string Name { get => GetName(); }
    #endregion

    [SerializeField]
    [Tooltip("Current health")]
    public float HP
    {
        get { return GetPropertyValue("HP"); }
        set { SetPropertyValue("HP", value); }
    }

    [SerializeField]
    [Tooltip("Total health")]
    public float MaxHP { get => GetPropertyValue("MaxHP"); set => SetPropertyValue("MaxHP", value); }

    [SerializeField]
    public float MP { get => GetPropertyValue("MP"); set => SetPropertyValue("MP", value); }

    [SerializeField]
    public float MaxMP { get => GetPropertyValue("MaxMP"); set => SetPropertyValue("MaxMP", value); }

    [SerializeField]
    public float SP { get => GetPropertyValue("SP"); set => SetPropertyValue("SP", value); }

    [SerializeField]
    public float MaxSP { get => GetPropertyValue("MaxSP"); set => SetPropertyValue("MaxSP", value); }

    [SerializeField]
    public float Speed { get => GetPropertyValue("Speed"); set => SetPropertyValue("Speed", value); }

    [SerializeField]
    public float MaxSpeed { get => GetPropertyValue("MaxSpeed"); set => SetPropertyValue("MaxSpeed", value); }

    #region Rate stats
    public float HP_RecoveryRate { get => GetPropertyValue("HP_RecoveryRate"); set => SetPropertyValue("HP_RecoveryRate", value); }
    public float MP_RecoveryRate { get => GetPropertyValue("MP_RecoveryRate"); set => SetPropertyValue("MP_RecoveryRate", value); }
    public float SP_RecoveryRate { get => GetPropertyValue("SP_RecoveryRate"); set => SetPropertyValue("SP_RecoveryRate", value); }

    public float SP_UsageRate { get => GetPropertyValue("SP_UsageRate"); set => SetPropertyValue("SP_UsageRate", value); }
    public float MP_UsageRate { get => GetPropertyValue("MP_UsageRate"); set => SetPropertyValue("MP_UsageRate", value); }
    #endregion

    public List<BuffModel> Buffs => new List<BuffModel>();

    public List<BuffModel> Debuffs => new List<BuffModel>();

    private Dictionary<string, float> Stats = new Dictionary<string, float>();

    private void SetPropertyValue(string propName, float propValue)
    {
        if (propValue < 0) propValue = 0;

        Stats.Remove(propName);
        Stats.TryAdd(propName, propValue);
    }

    public float GetPropertyValue(string propName)
    {
        return Stats.GetValueOrDefault(propName, 0f);
    }

    private bool GetIsAlive()
    {
        return this.GetPropertyValue("HP") > 0;
    }

    protected bool GetIsStatic()
    {
        return true;
    }

    protected string GetName()
    {
        return "Unknown";
    }

    // Load character stats
    public void LoadStats()
    {
        this.HP = 50f;
        this.MaxHP = 100f;
        this.MP = 50f;
        this.MaxMP = 100f;
        this.SP = 50f;
        this.MaxSP = 100f;
        this.Speed = 1;
        this.MaxSpeed = 1;
        this.HP_RecoveryRate = 10f;
        this.MP_RecoveryRate = 10f;
        this.SP_RecoveryRate = 10f;
        this.MP_UsageRate = 10f;
        this.SP_UsageRate = 10f;
    }

    // Restore current stats to max stats
    public void RestoreStats()
    {
        var keys = new List<string>(Stats.Keys);

        foreach (var key in keys)
        {
            if (!key.StartsWith("Max") && Stats.ContainsKey("Max" + key)) {
                Stats.Remove(key);
                Stats.Add(key, Stats.GetValueOrDefault("Max" + key, 0f));
            }
        }
    }

    // Set all stats to zero
    public void ResetStats()
    {
        var keys = new List<string>(Stats.Keys);

        foreach (var key in keys)
        {
            Stats.Remove(key);
        }
    }

    void OnEnable()
    {
        this.LoadStats();
        // TODO: Register handlers
    }

    void OnDisable()
    {
        this.ResetStats();
        // TODO: Disconnect handlers
    }

    void Update()
    {
        // TODO: Detect if stats value changed and dispatch events
    }
}


public class CharacterStatsController : StatsController {
}
