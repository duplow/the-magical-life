using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemKind {
    WEARABLE,
    CONSUMIABLE
}

public enum GearSlot {
    HELMET,
    ARMOR,
    PANTS,
    GLOVES,
    BOOTS,
    WEAPON1,
    WEAPON2
}

public class ItemAttributes { // TODO: Maybe change to ItemProperties or ItemProps
    public float HP_Static;
    public float HP_Percentage;

    public float MP_Static;
    public float MP_Percentage;

    public float MAGIC_DEF_Static;
    public float MAGIC_DEF_Percentage;

    public float SWORD_DEF_Static;
    public float SWORD_DEF_Percentage;

    public float STR_ATK_Static;
    public float STR_ATK_Percentage;

    public float MP_ATK_Static;
    public float MP_ATK_Percentage;

    public int[] Buffs;
    public int[] Debuffs;

    public float Durability;
}

public class ItemModel
{
    public ItemKind Kind;
    public GearSlot GearSlot;
    public ItemAttributes Attributes;
    public GameObject GameObject;
}
