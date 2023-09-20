using System;
using System.Collections.Generic;
using System.Text;
using NpcBehaviors.core;

namespace NpcBehaviors.core
{
    public interface CharacterStats : ObjectStats
    {
        MovingStatus HorizontalMoving();
        MovingStatus VerticalMoving();
        bool IsGrounded();
        bool IsFlying();
        int HP();
        int MaxHP();
    }
}
