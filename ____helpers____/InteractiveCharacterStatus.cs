using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors
{
    public interface InteractiveCharacterStatus
    {
        MovingStatus HorizontalMoving();
        MovingStatus VerticalMoving();
        bool IsGrounded();
        bool IsFlying();
        int HP();
        int MaxHP();
    }
}
