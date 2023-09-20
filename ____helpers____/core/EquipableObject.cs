using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface EquipableObject
    {
        void Equip(EquipmentWearableCharacter character);

        void Unequip(EquipmentWearableCharacter character);
    }
}
