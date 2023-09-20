using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors
{
    public enum MovingStatus {
        NONE = 0,
        WALKING = 1,
        RUNNING = 2,
        DASHING = 3,
    }

    internal class NpcBehavior
    {
        public MovingStatus MovingStatus = MovingStatus.NONE;
        public bool IsGrounded = false;
        public bool IsFlying = false;

        // public delegate event Event<string>OnUnderAttack() {}
    }
}
