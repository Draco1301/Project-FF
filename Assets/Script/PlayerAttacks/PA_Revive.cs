using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_Revive : MonoBehaviour, IPlayerAttack
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.partyMember;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 15;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        BattleSystemManager.AttackInProgress = true;
        BattleMessage.setMessage(player.Name + "revived " + target.Name);
        player.MP -= 15;
        LeanAnimation.sideAnimation(player.gameObject, -0.2f);


        if (target.HP == 0){ 
            target.HP += target.MAX_HP / 4;
            target.HP = Mathf.Clamp(target.HP, 0, target.MAX_HP);
        }

        yield return new WaitForSeconds(1f); //this is for the animation

        if (target.HP == 0) {
            DamageDisplay.DisplayDamage(target, target.MAX_HP / 4, Color.green);
        } else {
            DamageDisplay.DisplayDamage(target, 0, Color.green);
        }

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
