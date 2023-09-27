using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerFactory : IFactory<PlayerModel> // TODO: Change to player class instead of model
{
    public PlayerModel Create()
    {
        throw new System.NotImplementedException();
    }
}
