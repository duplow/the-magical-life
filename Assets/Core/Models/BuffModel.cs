using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BufferKind {
    POSITIVE,
    NEGATIVE,
}

public enum PropertyKind {
    HP,
    MP,
    SP,
    STR,
    HP_RecoveryRate,
    MP_RecoveryRate,
    SP_RecoveryRate,
    STR_RecoveryRate,
    MP_UsageRate,
    STR_UsageRate
}

public class BuffModel
{
    public string Icon;
    public string Code;
    public string Name;
    public string Description;
    public BufferKind Kind;
    public PropertyKind PropertyName;
    public float PropertyValue;
    public bool IsAbsolute;
}
