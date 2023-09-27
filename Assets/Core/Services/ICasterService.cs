using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICasterService
{
    void CastMagicOrSpell(string name, GameObject caster, Vector3 direction);

    void CastSwordmanship(string name, GameObject caster, Vector3 direction);

    void CastBuff(string name, GameObject target);

    void CastDebuff(string name, GameObject target);
}
