using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttack
{
    void DestoryThis();
    void StartAction(PlayerBase player, CharacterBase target);
}
