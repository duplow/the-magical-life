using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerService
{
    string GetID();
    string GetName();
    float GetHP();
    float GetMaxHP();

    void Spawn();
    void Kill(string killedById = null);

    void SetPlayer(PlayerModel player);
}
