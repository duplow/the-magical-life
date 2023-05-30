using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemClassification {
    Weapon,
    Healmet,
    Armor,
    Gloves,
    Pants,
    Boots,
    Ring,
    Pendant,
    Wings,
    Accessory
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Custom/Equipment")]
public class EquipmentItem : ScriptableObject
{
    public string name;

    public ItemClassification classification;

    public float damageAmount;

    public float speedIncreaseAmount;

    public GameObject gameObject;

    public int remainingUsages = 0;

    public int duration = 10;

    public bool isConsumable = false;

    public bool IsDualWielding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
