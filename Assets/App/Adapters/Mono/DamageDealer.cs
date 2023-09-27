using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace App
{
    public interface IDamageDealerService
    {
        void DealDamage(AttackableCharacter attacker, AttackableCharacter target, float damage);
    }

    public class DamageDealerService : IDamageDealerService
    {
        public void DealDamage(AttackableCharacter attacker, AttackableCharacter target, float damage)
        {
            // TODO: Deal with damage
        }
    }
}
