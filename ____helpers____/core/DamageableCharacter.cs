using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface DamageableCharacter
    {
        void OnDamageReceived(float totalDamage);
    }
}
