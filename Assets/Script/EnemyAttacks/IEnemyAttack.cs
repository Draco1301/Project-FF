using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttack
{
    void DestoryThis();
    IEnumerator StartAction(EnemyInstance enemy, PlayerInstance target);
}
