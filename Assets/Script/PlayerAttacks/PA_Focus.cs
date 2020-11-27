using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Focus : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.self;
    }

    public bool reqirementsMet() {
        return true;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + " increased their focus ");
        player.focus += 1;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        yield return new WaitForSeconds(1f); //this is for the animation


        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
