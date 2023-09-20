using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface HittableObject
    {
        bool HasCollidedWithParticle(object particle);

        bool HasCollidedWithInAreaSpell(object spell);

        bool HasCollidedWithMeele(object meeleAttack);
    }
}
