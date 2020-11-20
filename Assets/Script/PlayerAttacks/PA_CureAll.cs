using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PA_CureAll : MonoBehaviour
{
    public void DestoryThis() {
        Destroy(this);
    }

    public TargetType getTargetType() {
        return TargetType.partyMember;
    }

    public bool reqirementsMet() {
        return BattleSystemManager.currentPlayersTurn.MP >= 20;
    }

    public IEnumerator StartAction(PlayerInstance player, CharacterInstance target) {
        
        foreach (PlayerInstance pi in BattleSystemManager.getPlayers()) {
            pi.HP += 12;
            pi.HP = Mathf.Clamp(pi.HP, 0, pi.MAX_HP);
        }

        BattleMessage.setMessage(player.Name + " cast CURE on the whole party");
        BattleSystemManager.AttackInProgress = true;
        player.MP -= 20;

        yield return new WaitForSeconds(1f); //this is for the animation

        foreach (PlayerInstance pi in BattleSystemManager.getPlayers()) {
            DamageDisplay.DisplayDamage(pi, 12);
        }

        while (DamageDisplay.isDisplayingDamage) {
            yield return null;
        }

        BattleMessage.closeMessage();
        BattleSystemManager.endPlayerTurn();
        DestoryThis();
    }
}
