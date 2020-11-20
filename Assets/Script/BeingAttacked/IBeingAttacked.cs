using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBeingAttacked
{
    

    int DamageChange(float damage);

    IEnumerator Action(CharacterInstance attacker);

    bool hasAction();

    bool IsActionActive();
}
