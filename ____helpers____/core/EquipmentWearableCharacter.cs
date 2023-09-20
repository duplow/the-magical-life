using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface EquipmentWearableCharacter
    {
        void Equip(EquipableObject equipment);

        void Unequip(EquipableObject equipment);
    }
}
