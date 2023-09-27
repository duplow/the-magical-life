using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    public float HP;

    [SerializeField]
    public float MaxHP;

    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public float GetHP()
    {
        return 100f;
    }
}
