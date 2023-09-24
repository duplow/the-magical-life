using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public string UID;
    public string Nickname;

    #region Stats

    public uint HP;
    public uint MaxHP;
    public int RecoveryRateHP;

    public int MP;
    public int MaxMP;
    public int RecoveryRateMP;

    public int SP;
    public int MaxSP;

    public int Speed;
    public int MaxSpeed;

    public CharacterStatsModel CurrentStats;
    public CharacterStatsModel NormalStats;
    public List<ItemModel> Equipments;
    public List<BuffModel> Buffs;

    #endregion

    #region Current stats

    public float PositionX;
    public float PositionY;
    public float PositionZ; // Or Vector3

    #endregion

    public void PositionFromVector3(Vector3 position)
    {
        this.PositionX = position.x;
        this.PositionY = position.y;
        this.PositionZ = position.z;
    }

    public Vector3 PositionToVector3()
    {
        return new Vector3(PositionX, PositionY, PositionZ);
    }
}
