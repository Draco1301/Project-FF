using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Fight : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public IEnumerator StartAction(PlayerBase player, CharacterBase target) {
        target.HP -= player.Strength - target.Strength;

        BattleMessage.setMessage(player.name + " Attacked " + target.name);
        BattleSystemManager.AttackInProgress = true;

        yield return new WaitForSeconds(1f);

        BattleMessage.closeMessage();
        BattleSystemManager.endAttack();
    }
}
