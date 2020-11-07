using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttack
{
    void DestoryThis();
    IEnumerator StartAction(PlayerInstance player, CharacterInstance target);

}
