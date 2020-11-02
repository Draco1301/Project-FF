using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttack
{
    void DestoryThis();
    IEnumerator StartAction(PlayerBase player, CharacterBase target);

}
